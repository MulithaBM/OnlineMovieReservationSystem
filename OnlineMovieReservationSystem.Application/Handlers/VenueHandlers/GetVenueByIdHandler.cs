using MediatR;
using OnlineMovieReservationSystem.Application.Queries.VenueQueries;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;

namespace OnlineMovieReservationSystem.Application.Handlers.VenueHandlers
{
    public class GetVenueByIdHandler : IRequestHandler<GetVenueByIdQuery, ServiceResponse<Venue>>
    {
        private readonly IVenueService _venueService;

        public GetVenueByIdHandler(IVenueService venueService)
        {
            _venueService = venueService;
        }

        public async Task<ServiceResponse<Venue>> Handle(GetVenueByIdQuery request, CancellationToken cancellationToken)
        {
            return await _venueService.GetVenueById(request.Id);
        }
    }
}
