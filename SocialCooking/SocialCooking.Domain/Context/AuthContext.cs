﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using SocialCooking.Domain.Entity;

namespace SocialCooking.Domain.Context
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext() 
            : base("SCContext")
        {
        }

        public DbSet<AppClient> AppClients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}