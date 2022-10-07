using AutoMapper;
using eUrzad.Entities;
using eUrzad.Exceptions;
using eUrzad.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace eUrzad.Services
{
    public interface IInstitutionService
    {
        IEnumerable<InstitutionDto> GetAll();
        InstitutionDto GetById(int id);
        int Create(CreateInstitutionDto dto);
        void Delete(int id);
        void Update(UpdateInstitutionDto dto, int id);
    }

    public class InstitutionService : IInstitutionService
    {
        private readonly InstitutionDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<InstitutionService> _logger;

        public InstitutionService(InstitutionDbContext dbContext, IMapper mapper, ILogger<InstitutionService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public InstitutionDto GetById(int id)
        {
            var institution = _dbContext
                .Institutions
                .Include(p => p.Employees)
                .Include(p => p.Customers)
                .Include(p => p.DocumentTypes)
                .FirstOrDefault(r => r.Id == id);

            if (institution == null)
            {
               throw new NotFoundException("Institution not found");
            }

            var result = _mapper.Map<InstitutionDto>(institution);
            return result;
        }

        public IEnumerable<InstitutionDto> GetAll()
        {
            var institution = _dbContext
                .Institutions
                .Include(p => p.Employees)
                .Include(p => p.Customers)
                .Include(p => p.DocumentTypes)
                .ToList();

            var institutionsDtos = _mapper.Map<List<InstitutionDto>>(institution);

            return institutionsDtos;
        }

        public int Create(CreateInstitutionDto dto)
        {
            var institution = _mapper.Map<Institution>(dto);
            _dbContext.Institutions.Add(institution);
            _dbContext.SaveChanges();

            return institution.Id;
        }

        public void Update(UpdateInstitutionDto dto, int id)
        {
            var institution = _dbContext
                .Institutions
                .FirstOrDefault(r => r.Id == id);

            if (institution == null)
                throw new NotFoundException("Institution not found"); ;

            institution.Name = dto.Name;
            institution.Description = dto.Description;
            institution.Category = dto.Category;
            institution.OpeningHours = dto.OpeningHours;
            institution.ContactEmail = dto.ContactEmail;
            institution.PhoneNumber = dto.PhoneNumber;
            institution.Voicodeship = dto.Voicodeship;
            institution.City = dto.City;
            institution.Street = dto.Street;
            institution.PostalCode = dto.PostalCode;
            institution.BuldingNumber = dto.BuldingNumber;
            institution.ApartmentNumber = dto.ApartmentNumber;

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _logger.LogWarning($"Institution with id: {id} delete action invoked");

            var institution = _dbContext
                .Institutions
                .FirstOrDefault(r => r.Id == id);

            if (institution == null)
                throw new NotFoundException("Institution not found");

            _dbContext.Institutions.Remove(institution);
            _dbContext.SaveChanges();
        }
    }
}
