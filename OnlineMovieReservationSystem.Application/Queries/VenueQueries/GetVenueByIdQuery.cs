using MediatR;
using OnlineMovieReservationSystem.Domain.Models;

namespace OnlineMovieReservationSystem.Application.Queries.VenueQueries
{
    public record GetVenueByIdQuery(int Id) : IRequest<ServiceResponse<Venue>>;
}
