using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity.Configuration;
using Owin;
using System;
using System.Configuration;
using Unity;

[assembly: OwinStartup(typeof(CensusDataDigitalization.Presentation.Startup))]
namespace CensusDataDigitalization.Presentation
{
    public class Startup
    {
        /// <summary>
        /// Configures the settings on StartUp like cross origin requests and token expire time token generation
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {

            var container = new UnityContainer();
            var unitySection = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            unitySection.Configure(container);

            app.UseCors(CorsOptions.AllowAll);
            var OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = container.Resolve<IOAuthAuthorizationServerProvider>(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(20),
                AllowInsecureHttp = true
            };
            app.UseOAuthBearerTokens(OAuthOptions);
            app.UseOAuthAuthorizationServer(OAuthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

    }
}





