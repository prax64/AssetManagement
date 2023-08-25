using AssetManagement.Web.Application.Services;
using AssetManagement.Web.Definitions.Identity;
using Calabonga.AspNetCore.AppDefinitions;

namespace AssetManagement.Web.Definitions.DependencyContainer
{
    /// <summary>
    /// Dependency container definition
    /// </summary>
    public class ContainerDefinition : AppDefinition
    {
        public override void ConfigureServices(IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ApplicationUserClaimsPrincipalFactory>();
        }
    }
}