using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMovieReservationSystem.Domain.Models;
namespace OnlineMovieReservationSystem.Persistence.Configurations
{
    public class MovieEntityTypeConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(b => b.Title)
                .HasMaxLength(5)
                .IsRequired();
        }
    }
}
