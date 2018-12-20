using DomainModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.EntityFramework.Context.Configuration
{
    public class ContactRequestConfigurator : IEntityTypeConfiguration<ContactRequest>
    {
        public void Configure(EntityTypeBuilder<ContactRequest> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            builder.Property(e => e.SenderId)
                .HasColumnName("SENDER_ID")
                .IsRequired();

            builder.Property(e => e.ReceiverId)
                .HasColumnName("RECEIVER_ID")
                .IsRequired();

            builder.HasOne(e => e.Sender)
                .WithMany(e => e.ContactRequests)
                .HasForeignKey(e => e.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasKey(e => e.Id);

            builder.ToTable("CONTACT_REQUESTS");
        }
    }
}