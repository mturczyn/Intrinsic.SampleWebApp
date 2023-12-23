using Microsoft.EntityFrameworkCore;

namespace Intrinsic.SampleWebApp.DAL.Repositories;

public class FeedbackRepository : IFeedbackRepository
{
    private readonly IntrinsicWebAppDbContext _context;

    public FeedbackRepository(IntrinsicWebAppDbContext context)
    {
        _context = context;
    }

    public async Task<Feedback[]> GetRecentFeedbacksAsync(int take, CancellationToken cancellationToken)
    {
        return await _context.Feedbacks
            .OrderByDescending(x => x.Created)
            .Take(take)
            .ToArrayAsync(cancellationToken);
    }

    public async Task AddNewFeedbackAsync(Feedback feedback, CancellationToken cancellationToken)
    {
        _context.Feedbacks.Add(feedback);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
