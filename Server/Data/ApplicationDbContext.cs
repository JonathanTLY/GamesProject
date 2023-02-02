using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesProject.Server.Models;
using GamesProject.Server.Configurations.Entities;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using GamesProject.Shared.Domain;

namespace GamesProject.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet <Game> Games { get; set; }
        public DbSet <Genre> Genres { get; set; }
        public DbSet <AgeRating> AgeRatings { get; set; }
        public DbSet <Booking> Bookings { get; set; }
        public DbSet <GamePublisher> GamePublishers { get; set; }
        public DbSet <Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AgeRatingSeedConfiguration());
            builder.ApplyConfiguration(new GamePublisherSeedConfiguration());
            builder.ApplyConfiguration(new GenreSeedConfiguration());
            builder.ApplyConfiguration(new RoleSeedConfiguration());
            builder.ApplyConfiguration(new UserSeedConfiguration());
            builder.ApplyConfiguration(new UserRoleSeedConfiguration());

        }

    }
}
