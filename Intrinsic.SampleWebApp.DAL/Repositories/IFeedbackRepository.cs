namespace Intrinsic.SampleWebApp.DAL.Repositories;

public interface IFeedbackRepository
{
    Task AddNewFeedbackAsync(Feedback feedback, CancellationToken cancellationToken);

    Task<Feedback[]> GetRecentFeedbacksAsync(int take, CancellationToken cancellationToken);
}