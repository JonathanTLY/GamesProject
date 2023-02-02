using GamesProject.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesProject.Server.Configurations.Entities
{
    public class GamePublisherSeedConfiguration : IEntityTypeConfiguration<GamePublisher>
    {
        public void Configure(EntityTypeBuilder<GamePublisher> builder)
        {
            builder.HasData(
                new GamePublisher
                {
                    Id = 1,
                    Name = "Bandai Games",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new GamePublisher
                {
                    Id = 2,
                    Name = "Koei",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new GamePublisher
                {
                    Id = 3,
                    Name = "Konami",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new GamePublisher
                {
                    Id = 4,
                    Name = "Namco",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new GamePublisher
                {
                    Id = 5,
                    Name = "Square Enix",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                }
                );


        }
    }
}