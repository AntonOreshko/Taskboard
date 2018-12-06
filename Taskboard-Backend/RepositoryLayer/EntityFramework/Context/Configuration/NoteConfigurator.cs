using DomainModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.EntityFramework.Context.Configuration
{
    public class NoteConfigurator : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
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

            builder.Property(e => e.BoardId)
                .HasColumnName("BOARD_ID")
                .IsRequired();

            builder.HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasKey(e => e.Id);

            builder.ToTable("NOTES");
        }
    }
}
