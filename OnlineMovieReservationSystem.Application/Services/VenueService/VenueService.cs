using AutoMapper;
using OnlineMovieReservationSystem.Persistence.Data;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;
using OnlineMovieReservationSystem.Domain.Dtos.Venue;
using OnlineMovieReservationSystem.Persistence.Repository;

namespace OnlineMovieReservationSystem.Application.Services.VenueService
{
    public class VenueService : IVenueService
    {
        private readonly UnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public VenueService(DataContext context, IMapper mapper)
        {
            unitOfWork = new UnitOfWork(context);
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<Venue>>> GetAllVenues()
        {
            var response = new ServiceResponse<List<Venue>>();

            try
            {
                var venues = (List<Venue>) await unitOfWork.VenueRepository.Get();

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
                var venue = await unitOfWork.VenueRepository.GetById(id);

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

                await unitOfWork.VenueRepository.Add(venue);
                unitOfWork.Save();

                response.Data = (List<Venue>) await unitOfWork.VenueRepository.Get();
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

                await unitOfWork.VenueRepository.AddRange(venues);
                unitOfWork.Save();

                response.Data = (List<Venue>) await unitOfWork.VenueRepository.Get();
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
                var venue = await unitOfWork.VenueRepository.GetById(id);

                if (venue == null)
                {
                    response.Success = false;
                    response.Message = "Venue not found";

                    return response;
                }

                await unitOfWork.VenueRepository.Remove(venue);
                unitOfWork.Save();

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
