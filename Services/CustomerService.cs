using AutoMapper;
using eUrzad.Entities;
using eUrzad.Exceptions;
using eUrzad.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace eUrzad.Services
{
    public interface ICustomerService
    {
        int Create(int institutionId, CreateCustomerDto dto);
        CustomerDto GetById(int institutionId, int customerId);
        List<CustomerDto> GetAll(int institutionId);
        void RemoveAll(int institutionId);
        void RemoveById(int institutionId, int customerId);
        void Update(UpdateCustomerDto dto, int institutionId, int customerId);
    }

    public class CustomerService : ICustomerService
    {

        private readonly InstitutionDbContext _dbContext;
        private readonly IMapper _mapper;

        public CustomerService(InstitutionDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int Create(int institutionId, CreateCustomerDto dto)
        {
            var institution = _dbContext.Institutions.FirstOrDefault(x => x.Id == institutionId);
            if (institution is null)
                throw new NotFoundException("Institution not found");

            var institutionEntity = _mapper.Map<Customer>(dto);

            institutionEntity.InstitutionId = institutionId;

            _dbContext.Customers.Add(institutionEntity);
            _dbContext.SaveChanges();

            return institutionEntity.Id;
        }

        public CustomerDto GetById(int institutionId, int customerId)
        {
            var institution = _dbContext.Institutions.FirstOrDefault(x => x.Id == institutionId);
            if (institution is null)
                throw new NotFoundException("Institution not found");

            var customer = _dbContext.Customers.FirstOrDefault(x => x.Id == customerId);
            if (customer is null || customer.InstitutionId != institutionId)
            {
                throw new NotFoundException("Customer not found");
            }

            var customerDto = _mapper.Map<CustomerDto>(customer);
            return customerDto;
        }

        public List<CustomerDto> GetAll(int institutionId)
        {
            var institution = _dbContext
                .Institutions
                .Include(x => x.Customers)
                .FirstOrDefault(x => x.Id == institutionId);
            
            if (institution is null)
                throw new NotFoundException("Institution not found");

            var customerDtos = _mapper.Map<List<CustomerDto>>(institution.Customers);

            return customerDtos;
        }

        public void RemoveAll(int institutionId)
        {
            var institution = _dbContext
                   .Institutions
                   .Include(x => x.Customers)
                   .FirstOrDefault(x => x.Id == institutionId);

            if (institution is null)
                throw new NotFoundException("Institution not found");

            _dbContext.RemoveRange(institution.Customers);
            _dbContext.SaveChanges();

        }

        public void RemoveById(int institutionId, int customerId)
        {
            var institution = _dbContext.Institutions.FirstOrDefault(x => x.Id == institutionId);
            if (institution is null)
                throw new NotFoundException("Institution not found");

            var customer = _dbContext.Customers.FirstOrDefault(x => x.Id == customerId);
            if (customer is null || customer.InstitutionId != institutionId)
            {
                throw new NotFoundException("Customer not found");
            }

            _dbContext.Remove(customer);
            _dbContext.SaveChanges();
        }

        public void Update(UpdateCustomerDto dto, int institutionId, int customerId)
        {
            var institution = _dbContext.Institutions.FirstOrDefault(x => x.Id == institutionId);
            if (institution is null)
                throw new NotFoundException("Institution not found");

            var customer = _dbContext.Customers.FirstOrDefault(x => x.Id == customerId);
            if (customer is null || customer.InstitutionId != institutionId)
            {
                throw new NotFoundException("Customer not found");
            }

            customer.Name = dto.Name;
            customer.SecoundName = dto.SecoundName;
            customer.LastName = dto.LastName;
            customer.Age = dto.Age;
            customer.Pesel = dto.Pesel;
            customer.PhoneNumber = dto.PhoneNumber;
            customer.ContactEmail = dto.ContactEmail;
            customer.Voicodeship = dto.Voicodeship;
            customer.City = dto.City;
            customer.Street = dto.Street;
            customer.PostalCode = dto.PostalCode;
            customer.BuldingNumber = dto.BuldingNumber;
            customer.ApartmentNumber = dto.ApartmentNumber;

            _dbContext.SaveChanges();
        }
    }
}
