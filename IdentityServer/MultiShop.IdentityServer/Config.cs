﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog"){ Scopes = {"CatalogFullPermission", "CatalogReadPermission"} },

            new ApiResource("ResourceDiscount"){ Scopes = {"DiscountFullPermission"} },

            new ApiResource("ResourceOrder"){ Scopes = {"OrderFullPermission"} },

            new ApiResource("ResourceCargo"){ Scopes = {"CargoFullPermission"} },

            new ApiResource("ResourceBasket"){ Scopes = {"BasketFullPermission"} },

            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission", "Full Authority For Catalog Operations"),
            new ApiScope("CatalogReadPermission", "Reading Authority For Catalog Operations"),
            new ApiScope("DiscountFullPermission", "Full Authority For Discount Operations"),
            new ApiScope("OrderFullPermission", "Full Authority For Order Operations"),
            new ApiScope("CargoFullPermission", "Full Authority For Cargo Operations"),
            new ApiScope("BasketFullPermission", "Full Authority For Basket Operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor Client
            new Client
            {
                ClientId = "MultiShopVisitorId",
                ClientName = "Multi Shop Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("multishopsecret".Sha256()) },
                AllowedScopes = { "CatalogReadPermission" }
            },

            //Manager Client
            new Client
            {
                ClientId = "MultiShopManagerId",
                ClientName = "Multi Shop Manager User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("multishopsecret".Sha256()) },
                AllowedScopes = { "CatalogFullPermission", "CatalogReadPermission" }
            },

            //Admin Client
            new Client
            {
                ClientId = "MultiShopAdminId",
                ClientName = "Multi Shop Admin User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("multishopsecret".Sha256()) },
                AllowedScopes = { "CatalogFullPermission", "CatalogReadPermission", "DiscountFullPermission", 
                    "OrderFullPermission", 
                    "CargoFullPermission",
                    "BasketFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile},
                AccessTokenLifetime = 600
            }
        };
    }
}