using Intrinsic.SampleWebApp.DAL;
using Intrinsic.SampleWebApp.DAL.Repositories;
using Intrinsic.SampleWebApp.Presentation.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Intrinsic.SampleWebApp.Presentation.Pages;

public class IndexModel : PageModel
{
    public const int FEEDBACKS_LIST_SIZE = 100;

    private readonly ILogger<IndexModel> _logger;
    private readonly IFeedbackRepository _feedbackRepository;

    public IndexModel(
        ILogger<IndexModel> logger,
        IFeedbackRepository feedbackRepository)
    {

        _logger = logger;
        _feedbackRepository = feedbackRepository;
    }

    public Feedback[] Feedbacks { get; private set; }

    public async Task OnPost(CreateFeedbackDto feedback, CancellationToken cancellationToken)
    {
        await _feedbackRepository.AddNewFeedbackAsync(
            new Feedback()
            {
                Content = feedback.FeedbackContent,
                Author = feedback.FeedbackAuthor,
            },
            cancellationToken);

        await GetRecentFeedbacksAsync(cancellationToken);
    }

    public async Task OnGet(CancellationToken cancellationToken)
    {
        await GetRecentFeedbacksAsync(cancellationToken);
    }

    private async Task GetRecentFeedbacksAsync(CancellationToken cancellationToken)
    {
        Feedbacks = await _feedbackRepository.GetRecentFeedbacksAsync(FEEDBACKS_LIST_SIZE, cancellationToken);
    }
}
