using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OryxBudgetWeb
{
  public class Config
  {
    // scopes define the resources in your system
    public static IEnumerable<IdentityResource> GetIdentityResources()
    {
      return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
    }

    public static IEnumerable<ApiResource> GetApiResources()
    {
      return new List<ApiResource>
            {
                new ApiResource("api1", "My API"),
                new ApiResource("payslipEmailApi", "Payslip Email Api"),
                 new ApiResource("OryxBudget", "Oryx Budget"),
            };
    }

    // clients want to access resources (aka scopes)
    public static IEnumerable<Client> GetClients()
    {
      // client credentials client
      return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("F621F470-9731-4A25-80EF-67A6F7C5F4B8".Sha256())
                    },
                    AllowedScopes = { "api1" , "payslipEmailApi" }
                },

                // resource owner password grant client
                new Client
                {
                    ClientId = "payslipApiClient",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("F621F470-9731-4A25-80EF-67A6F7C5F4B8".Sha256())
                    },
                    AllowedScopes = { "api1", "payslipEmailApi" }
                },

                 new Client
                {
                    ClientId = "OryxBudgetPassword",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret("F621F470-9731-4A25-80EF-67A6F7C5F4B8".Sha256())
                    },
                     AllowedScopes = new List<string>
                    {
                       IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "OryxBudget"
                    }
                },

                // OpenID Connect hybrid flow and client credentials client (MVC)
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

                    RequireConsent = false,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    RedirectUris = { "http://localhost:5002/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    },
                    AllowOfflineAccess = true
                },

                 new Client
                {
                    ClientId = "OryxBudget",
                    ClientName = "Oryx Budget",
                    AccessTokenType = AccessTokenType.Jwt,
                    //AccessTokenLifetime = 600, // 10 minutes, default 60 minutes
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RequireConsent = false,
                    AllowAccessTokensViaBrowser = true,
                   RedirectUris = new List<string>
                    {
                        "http://localhost:3000/",
                        "http://localhost:4200/",
                        "http://10.211.55.2:4200/",


                    },
                   // PostLogoutRedirectUris = new List<string>
                   // {
                   //     "http://localhost:3000/unauthorized.html",
                   //     "http://localhost:4200/home",
                   //     "http://10.211.55.2:4200/unauthorized.html",
                   // },
                    //RedirectUris = { "http://localhost:4200/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:4200/unauthorised" },
                     AllowedScopes = new List<string>
                    {
                       IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "OryxBudget"
                    },
                    AllowedCorsOrigins = new List<string>
                    {

                        "http://localhost:3000",
                        "http://localhost:4200",
                        "http://10.211.55.2:4200"
                    }
                },
            };
    }
  }
}
