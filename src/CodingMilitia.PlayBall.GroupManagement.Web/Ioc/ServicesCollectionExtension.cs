using CodingMilitia.PlayBall.GroupManagement.Business.Impl.Services;
using CodingMilitia.PlayBall.GroupManagement.Business.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesCollectionExtension
    {
        public static void AddBusiness(this IServiceCollection services)
        {
            services.AddSingleton<IGroupService, InMemoryGroupService>();
        }
    }
}
