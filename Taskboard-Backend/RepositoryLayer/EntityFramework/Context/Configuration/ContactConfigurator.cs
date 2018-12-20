using DomainModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.EntityFramework.Context.Configuration
{
    public class ContactConfigurator : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            builder.Property(e => e.FirstUserId)
                .HasColumnName("FIRST_USER_ID")
                .IsRequired();

            builder.Property(e => e.SecondUserId)
                .HasColumnName("SECOND_USER_ID")
                .IsRequired();

            builder.HasOne(e => e.FirstUser)
                .WithMany(e => e.Contacts)
                .HasForeignKey(e => e.FirstUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasKey(e => e.Id);

            builder.ToTable("CONTACTS");
        }
    }
}
