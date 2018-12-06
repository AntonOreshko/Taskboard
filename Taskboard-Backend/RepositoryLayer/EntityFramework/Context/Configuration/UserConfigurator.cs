﻿using DomainModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.EntityFramework.Context.Configuration
{
    public class UserConfigurator : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            builder.Property(e => e.Email)
                .HasColumnName("EMAIL")
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(e => e.FullName)
                .HasColumnName("FULL_NAME")
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(e => e.Created)
                .HasColumnName("CREATED")
                .IsRequired();

            builder.Property(e => e.CreatedById)
                .HasColumnName("CREATED_BY");

            builder.Property(e => e.PasswordHash)
                .HasColumnName("PASSWORD_HASH")
                .IsRequired();

            builder.Property(e => e.PasswordSalt)
                .HasColumnName("PASSWORD_SALT")
                .IsRequired();

            builder.HasMany(e => e.UserBoards)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);

            builder.HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasKey(e => e.Id);

            builder.ToTable("USERS");
        }

    }
}
