using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineMovieReservationSystem.Application.Data;
using OnlineMovieReservationSystem.Domain.Models;
using OnlineMovieReservationSystem.Domain.Services;
using OnlineMovieReservationSystem.Domain.Dtos.Venue;

namespace OnlineMovieReservationSystem.Application.Services.VenueService
{
    public class VenueService : IVenueService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public VenueService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<Venue>>> GetAllVenues()
        {
            var response = new ServiceResponse<List<Venue>>();

            try
            {
                var venues = await _context.Venues.ToListAsync();

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
                var venue = await _context.Venues.FirstOrDefaultAsync(v => v.Id == id);

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

                await _context.Venues.AddAsync(venue);
                await _context.SaveChangesAsync();

                response.Data = await _context.Venues.ToListAsync();
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

                await _context.Venues.AddRangeAsync(venues);
                await _context.SaveChangesAsync();

                response.Data = await _context.Venues.ToListAsync();
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
                var venue = await _context.Venues.FirstOrDefaultAsync(v => v.Id == id);

                if(venue == null)
                {
                    response.Success = false;
                    response.Message = "Venue not found";

                    return response;
                }

                _context.Venues.Remove(venue);
                await _context.SaveChangesAsync();

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
