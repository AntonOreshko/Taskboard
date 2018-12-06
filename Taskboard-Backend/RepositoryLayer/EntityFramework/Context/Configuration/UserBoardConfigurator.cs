using DomainModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.EntityFramework.Context.Configuration
{
    public class UserBoardConfigurator : IEntityTypeConfiguration<UserBoard>
    {
        public void Configure(EntityTypeBuilder<UserBoard> builder)
        {
            builder.Ignore(e => e.Id);

            builder.Property(e => e.UserId)
                .HasColumnName("USER_ID")
                .IsRequired();

            builder.Property(e => e.BoardId)
                .HasColumnName("BOARD_ID")
                .IsRequired();

            builder.HasKey(e => new { e.UserId, e.BoardId });

            builder.ToTable("USER_BOARDS");
        }
    }
}
