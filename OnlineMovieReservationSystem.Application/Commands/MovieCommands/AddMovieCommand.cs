using MediatR;
using OnlineMovieReservationSystem.Domain.Dtos.Movie;
using OnlineMovieReservationSystem.Domain.Models;

namespace OnlineMovieReservationSystem.Application.Commands.MovieCommands
{
    public record AddMovieCommand(MovieDto Movie) : IRequest<ServiceResponse<List<Movie>>>;

    //string Title, string Destination, string Director, string Cast, string Type, int Duration, string ReleaseDate

    //public class AddMovieCommand : IRequest<List<Movie>>
    //{
    //    public string Title { get; set; }
    //    public string Destination { get; set; }
    //    public string Director { get; set; }
    //    public string Cast { get; set; }
    //    public string Type { get; set; }
    //    public int Duration { get; set; }
    //    public string ReleaseDate { get; set; }
    //}
}
