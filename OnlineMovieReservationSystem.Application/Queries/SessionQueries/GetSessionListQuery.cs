using MediatR;
using OnlineMovieReservationSystem.Domain.Models;

namespace OnlineMovieReservationSystem.Application.Queries.SessionQueries
{
    public record GetSessionListQuery : IRequest<ServiceResponse<List<Session>>>;
}
