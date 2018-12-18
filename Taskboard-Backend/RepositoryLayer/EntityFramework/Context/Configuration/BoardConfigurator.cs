using DomainModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.EntityFramework.Context.Configuration
{
    public class BoardConfigurator : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            builder.Property(e => e.Created)
                .HasColumnName("CREATED")
                .IsRequired();

            builder.Property(e => e.CreatedById)
                .HasColumnName("CREATED_BY")
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName("NAME")
                .IsRequired();

            builder.Property(e => e.Description)
                .HasColumnName("DESCRIPTION")
                .IsRequired(false);

            builder.HasMany(e => e.UserBoards)
                .WithOne(e => e.Board)
                .HasForeignKey(e => e.BoardId);

            builder.HasMany(e => e.Tasks)
                .WithOne(e => e.Board)
                .HasForeignKey(e => e.BoardId);

            builder.HasMany(e => e.Notes)
                .WithOne(e => e.Board)
                .HasForeignKey(e => e.BoardId);

            builder.HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasKey(e => e.Id);

            builder.ToTable("BOARDS");
        }
    }
}
