﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer
{
    public class Config
    {
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1001",
                    Username = "hhz",
                    Password = "password",

                    Claims = new []
                    {
                        new Claim("name", "Hhz"),
                        new Claim("website", "https://Hhz.com")
                    }
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Address(),
                new IdentityResources.Email(),
                new IdentityResources.Phone(),
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                // OpenID Connect implicit flow client (MVC)
                new Client
                {
                    ClientId = "js",
                    ClientName = "JavaScript Client",
                    ClientUri="http://localhost:5003",
                    LogoUri="https://camo.githubusercontent.com/92e69cbbb01c0407b2e702ced9551f09cd81dcbf/68747470733a2f2f646f746e6574666f756e646174696f6e2e6f72672f696d616765732f6c6f676f5f6269672e737667",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce=true,
                    RequireClientSecret=false,

                   // where to redirect to after login
                    RedirectUris = { "http://localhost:5003/callback.html" },
                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "http://localhost:5003/index.html" },
                    //允许跨域访问的url
                    AllowedCorsOrigins =     { "http://localhost:5003" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    },
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API1"),
                new ApiResource("api2", "My API2")
            };
        }

    }
}
