using MediatR;
using OnlineMovieReservationSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMovieReservationSystem.Application.Commands.MovieCommands
{
    public record DeleteMovieCommand(int Id) : IRequest<ServiceResponse<Movie>>;
}
