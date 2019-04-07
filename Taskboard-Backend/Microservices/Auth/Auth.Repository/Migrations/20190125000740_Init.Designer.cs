﻿// <auto-generated />
using System;
using Auth.Repository.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Auth.Repository.Migrations
{
    [DbContext(typeof(AuthContext))]
    [Migration("20190125000740_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Auth.DomainModels.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<DateTime>("Created")
                        .HasColumnName("CREATED");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("EMAIL")
                        .HasMaxLength(256);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnName("FULL_NAME")
                        .HasMaxLength(256);

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnName("PASSWORD_HASH");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnName("PASSWORD_SALT");

                    b.HasKey("Id");

                    b.ToTable("USERS");
                });
#pragma warning restore 612, 618
        }
    }
}