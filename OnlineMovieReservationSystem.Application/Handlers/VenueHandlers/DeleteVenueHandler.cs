using MediatR;
using OnlineMovieReservationSystem.Application.Commands.VenueCommands;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;
using OnlineMovieReservationSystem.Persistence.Repositories;

namespace OnlineMovieReservationSystem.Application.Handlers.VenueHandlers
{
    public class DeleteVenueHandler : IRequestHandler<DeleteVenueCommand, ServiceResponse<Venue>>
    {
        private readonly IVenueService _venueService;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteVenueHandler(IVenueService venueService, IUnitOfWork unitOfWork)
        {
            _venueService = venueService;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<Venue>> Handle(DeleteVenueCommand request, CancellationToken cancellationToken)
        {
            var venue = await _venueService.DeleteVenue(request.Id);
            await _unitOfWork.SaveChangesAsync();
            return venue;
        }
    }
}
