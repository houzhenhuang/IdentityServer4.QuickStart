﻿using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
            };
        }

        //交互式用户：以当前登录到系统的用户确定对象的身份(当前必须有用户登录到系统, 如果用户注销那么对象也会被销毁)
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client{
                    ClientId = "client",
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    //no interactive user, use the clientid/secret for authentication
                    ClientSecrets = 
                    {
                        new Secret("secret".Sha256())
                    },
                    //scopes that client has access to
                    AllowedScopes={ "api1" }
                }
            };
        }
    }
}
