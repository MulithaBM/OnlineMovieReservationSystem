using MediatR;
using OnlineMovieReservationSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMovieReservationSystem.Application.Queries.MovieQueries
{
    public record GetMovieByIdQuery(int Id) : IRequest<ServiceResponse<Movie>>;
}
