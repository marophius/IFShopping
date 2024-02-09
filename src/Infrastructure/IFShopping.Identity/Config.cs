// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IFShopping.Identity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("catalogapi"),
                new ApiScope("basketapi"),
                new ApiScope("catalogapi.read"),
                new ApiScope("catalogapi.write"),
                new ApiScope("ifshoppinggateway")
            };

        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("Catalog", "Catalog.API")
            {
                Scopes = {"catalogapi.read", "catalogapi.write"}
            },
            new ApiResource("Basket", "Basket.API")
            {
                Scopes = {"basketapi"}
            },
            new ApiResource("IFShoppingGateway", "IFShopping Gateway")
            {
                Scopes = {"ifshoppinggateway"}
            },
            new ApiResource("IFShoppingAngular", "IFShopping Angular")
            {
                Scopes = {"ifshoppinggateway", "catalogapi.read", "catalogapi.write", "basketapi", "catalogapi.read"}
            }
        };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientName = "Catalog API Client",
                    ClientId = "CatalogAPIClient",
                    ClientSecrets = {new Secret("89ac1abf-4106-4acd-945c-7bb52d9c0181".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"catalogapi"}
                },
                new Client
                {
                    ClientName = "Basket API Client",
                    ClientId = "BasketAPIClient",
                    ClientSecrets = {new Secret("89aa4abf-4106-4acd-945c-7bb52d9c0181".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"basketapi"}
                },
                new Client
                {
                    ClientName = "IFShopping Gateway Client",
                    ClientId = "IFShoppingGatewayClient",
                    ClientSecrets = {new Secret("ad5287f0-2c16-4ca4-9f50-c804d14db97d".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"ifshoppinggateway"}
                },
                new Client
                {
                    ClientName = "Angular-Client",
                    ClientId = "angular-client",
                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = new List<string>
                        {
                            "http://localhost:4200/signin-callback",
                            "http://localhost:4200/assets/silent-callback.html",
                            "https://localhost:9009/signin-oidc"
                        },
                    RequirePkce = true,
                    AllowAccessTokensViaBrowser = true,
                    Enabled = true,
                    UpdateAccessTokenClaimsOnRefresh = true,

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "eshoppinggateway"
                    },
                    AllowedCorsOrigins = {"http://localhost:4200"},
                    RequireClientSecret = false,
                    AllowRememberConsent = false,
                    //PostLogoutRedirectUris = new List<string> {"http://localhost:4200/signout-callback"},
                    RequireConsent = false,
                    AccessTokenLifetime = 3600,
                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://localhost:4200/signout-callback",
                        "https://localhost:9009/signout-callback-oidc"
                    },
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("5c6eb3b4-61a7-4668-ac57-2b4591ec26d2".Sha256())
                    }
                }
            };
    }
}