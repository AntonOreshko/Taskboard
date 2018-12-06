using DomainModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.EntityFramework.Context.Configuration
{
    public class TaskConfigurator : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
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

            builder.Property(e => e.Completed)
                .HasColumnName("COMPLETED")
                .IsRequired();

            builder.Property(e => e.CompletedById)
                .HasColumnName("COMPLETED_BY")
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

            builder.HasMany(e => e.Subtasks)
                .WithOne(e => e.Task)
                .HasForeignKey(e => e.TaskId);

            builder.HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.CompletedBy)
                .WithMany()
                .HasForeignKey(e => e.CompletedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasKey(e => e.Id);

            builder.ToTable("TASKS");
        }
    }
}
