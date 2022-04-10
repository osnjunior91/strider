using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Strider.Infra.Data.Model;
using System;

namespace Strider.Infra.Data.Configuration
{
    public class FollowersConfiguration : IEntityTypeConfiguration<Followers>
    {
        public void Configure(EntityTypeBuilder<Followers> builder)
        {
            builder.ToTable("followers").HasKey(x => x.Id);
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
            builder.HasMany(x => x.FollowersList).WithOne();
        }
    }
}
