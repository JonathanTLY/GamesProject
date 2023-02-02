using GamesProject.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesProject.Server.Configurations.Entities
{
    public class AgeRatingSeedConfiguration : IEntityTypeConfiguration<AgeRating>
    {
        public void Configure(EntityTypeBuilder<AgeRating> builder)
        {
            builder.HasData(
                new AgeRating
                {
                    Id = 1,
                    Name = "PEGI 3",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new AgeRating
                {
                    Id = 2,
                    Name = "PEGI 7",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new AgeRating
                {
                    Id = 3,
                    Name = "PEGI 12",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new AgeRating
                {
                    Id = 4,
                    Name = "PEGI 16",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new AgeRating
                {
                    Id = 5,
                    Name = "PEGI 18",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                }
                );


        }
    }
}
