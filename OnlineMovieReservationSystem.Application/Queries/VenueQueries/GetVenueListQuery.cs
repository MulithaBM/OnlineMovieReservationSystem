using MediatR;
using OnlineMovieReservationSystem.Domain.Models;

namespace OnlineMovieReservationSystem.Application.Queries.VenueQueries
{
    public record GetVenueListQuery : IRequest<ServiceResponse<List<Venue>>>;
}
