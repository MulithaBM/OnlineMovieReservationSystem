using AutoMapper;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;
using OnlineMovieReservationSystem.Domain.Dtos.Venue;
using OnlineMovieReservationSystem.Domain.Repositories.VenueRepository;

namespace OnlineMovieReservationSystem.Application.Services.VenueService
{
    public class VenueService : IVenueService
    {
        private readonly IVenueQueryRepository _venueQueryRepository;
        private readonly IVenueCommandRepository _venueCommandRepository;
        private readonly IMapper _mapper;

        public VenueService(IVenueQueryRepository venueQueryRepository, IVenueCommandRepository venueCommandRepository, IMapper mapper)
        {
            _venueQueryRepository = venueQueryRepository;
            _venueCommandRepository = venueCommandRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<Venue>>> GetAllVenues()
        {
            var response = new ServiceResponse<List<Venue>>();

            try
            {
                var venues = (List<Venue>)await _venueQueryRepository.Get();

                if (!venues.Any())
                {
                    response.Success = false;
                    response.Message = "No venues available";

                    return response;
                }

                response.Data = venues;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<Venue>> GetVenueById(int id)
        {
            var response = new ServiceResponse<Venue>();

            try
            {
                var venue = await _venueQueryRepository.GetById(id);

                if (venue == null)
                {
                    response.Success = false;
                    response.Message = "Venue not found";

                    return response;
                }

                response.Data = venue;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Venue>>> AddVenue(VenueDto newVenue)
        {
            var response = new ServiceResponse<List<Venue>>();

            try
            {
                var venue = _mapper.Map<Venue>(newVenue);

                await _venueCommandRepository.Add(venue);

                response.Data = (List<Venue>)await _venueQueryRepository.Get();
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Venue>>> AddMultipleVenues(List<VenueDto> newVenues)
        {
            var response = new ServiceResponse<List<Venue>>();

            try
            {
                var venues = newVenues.Select(v => _mapper.Map<Venue>(v)).ToList();

                await _venueCommandRepository.AddRange(venues);

                response.Data = (List<Venue>) await _venueQueryRepository.Get();
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<Venue>> DeleteVenue(int id)
        {
            var response = new ServiceResponse<Venue>();

            try
            {
                var venue = await _venueQueryRepository.GetById(id);

                if (venue == null)
                {
                    response.Success = false;
                    response.Message = "Venue not found";

                    return response;
                }

                await _venueCommandRepository.Remove(venue);

                response.Data = venue;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }
    }
}
