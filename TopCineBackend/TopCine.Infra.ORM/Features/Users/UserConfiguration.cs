using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TopCine.Domain.Features.Users;

namespace TopCine.Infra.ORM.Features.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("TBUsers");
            builder.HasKey(c => c.Id).HasName("Id");
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).HasColumnName("Name").HasMaxLength(100);
            builder.Property(c => c.Email).HasColumnName("Email").HasMaxLength(30);
            builder.Property(c => c.AccessLevel).HasColumnName("AccessLevel");
            builder.Property(c => c.Password).HasColumnName("Password").HasMaxLength(500);
            builder.Property(c => c.InsertDate).HasColumnName("InsertDate").HasDefaultValueSql("GETDATE()");
            builder.Property(c => c.UpdateDate).HasColumnName("UpdateDate");
            builder.Ignore(c => c.Token);

            builder.HasData(new User(1, "Admin", "admin.test@printwayy.com", "827ccb0eea8a706c4c34a16891f84e7b", AccessLevelEnum.Manager));
        }
    }
}
