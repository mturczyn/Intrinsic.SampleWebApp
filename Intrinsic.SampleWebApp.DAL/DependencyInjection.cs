using Intrinsic.SampleWebApp.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Intrinsic.SampleWebApp.DAL;

public static class DependencyInjection
{
    public static void AddDataAccessLayer(
        this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<IntrinsicWebAppDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IFeedbackRepository, FeedbackRepository>();
    }
}
