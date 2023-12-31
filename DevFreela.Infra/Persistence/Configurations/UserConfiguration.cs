﻿using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infra.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
            .ToTable("users")
            .HasKey(p => p.Id);

            builder
             .HasMany(u => u.Skills)
             .WithOne()
             .HasForeignKey(u => u.IdSkill)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
