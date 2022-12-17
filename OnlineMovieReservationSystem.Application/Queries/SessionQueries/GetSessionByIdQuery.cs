using MediatR;
using OnlineMovieReservationSystem.Domain.Models;

namespace OnlineMovieReservationSystem.Application.Queries.SessionQueries
{
    public record GetSessionByIdQuery(int Id) : IRequest<ServiceResponse<Session>>;
}
