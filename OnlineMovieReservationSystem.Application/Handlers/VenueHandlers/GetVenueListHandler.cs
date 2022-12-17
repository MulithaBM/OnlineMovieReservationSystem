using MediatR;
using OnlineMovieReservationSystem.Application.Queries.VenueQueries;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMovieReservationSystem.Application.Handlers.VenueHandlers
{
    public class GetVenueListHandler : IRequestHandler<GetVenueListQuery, ServiceResponse<List<Venue>>>
    {
        private readonly IVenueService _venueService;

        public GetVenueListHandler(IVenueService venueService)
        {
            _venueService = venueService;
        }

        public async Task<ServiceResponse<List<Venue>>> Handle(GetVenueListQuery request, CancellationToken cancellationToken)
        {
            return await _venueService.GetAllVenues();
        }
    }
}
