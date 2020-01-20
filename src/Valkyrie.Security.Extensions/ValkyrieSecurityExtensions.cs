using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Valkyrie.Security.Extensions
{
    public static class ValkyrieSecurityExtensions
    {
        public static IServiceCollection UseAuthentication(this IServiceCollection serviceCollection, Action<SecurityOptions> options)
        {

//            var securityOptions  = new SecurityOptions();
//            options?.Invoke(securityOptions);

//            serviceCollection.AddAuthentication("Bearer")
//                .AddIdentityServerAuthentication(options =>
//                {
//                    options.Authority = adminApiConfiguration.IdentityServerBaseUrl;
//                    options.ApiName = adminApiConfiguration.OidcApiName;
//#if DEBUG
//                    options.RequireHttpsMetadata = false;
//#else
//                    options.RequireHttpsMetadata = true;
//#endif
//                });

            //serviceCollection.AddAuthentication(o =>
            //    {
            //        o.DefaultScheme = securityOptions.AuthenticationScheme;
            //        o.DefaultChallengeScheme = securityOptions.DefaultChallengeScheme;
            //    })
            //    .AddCookie("Cookies")
            //    .AddOpenIdConnect(securityOptions.DefaultChallengeScheme, o =>
            //    {
            //        o.Authority = securityOptions.IdentityServerUrl;
            //        o.RequireHttpsMetadata = securityOptions.RequireHttpsMetadata;

            //        //options.ClientId = "genric_api";
            //        //options.ClientSecret = "lzRy4sv91lG93FErH2RUCJqo/0bkg6Q/lB58l0YDoxA=";
            //        //options.ResponseType = "code";

            //        o.SaveTokens = securityOptions.SaveTokens;

            //        if (securityOptions.Scopes == null || !securityOptions.Scopes.Any()) return;
            //        foreach (var item in securityOptions.Scopes)
            //        {
            //            o.Scope.Add(item);
            //        }

            //    });

            return serviceCollection;
        }
    }
}
