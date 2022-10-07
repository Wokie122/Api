using AutoMapper;
using eUrzad.Entities;
using eUrzad.Exceptions;
using eUrzad.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace eUrzad.Services
{
    public interface IEmployeeService
    {
        int Create(int institutionId, CreateEmployeeDto dto);
        EmployeeDto GetById(int institutionId, int employeeId);
        List<EmployeeDto> GetAll(int institutionId);
        void RemoveAll(int institutionId);
        void RemoveById(int institutionId, int employeeId);
        void Update(UpdateEmployeeDto dto, int institutionId, int employeeId);
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly InstitutionDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmployeeService(InstitutionDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int Create(int institutionId, CreateEmployeeDto dto)
        {
            var institution = _dbContext.Institutions.FirstOrDefault(x => x.Id == institutionId);
            if (institution is null)
                throw new NotFoundException("Institution not found");

            var institutionEntity = _mapper.Map<Employee>(dto);

            institutionEntity.InstitutionId = institutionId;

            _dbContext.Employees.Add(institutionEntity);
            _dbContext.SaveChanges();

            return institutionEntity.Id;
        }

        public List<EmployeeDto> GetAll(int institutionId)
        {
            var institution = _dbContext
                .Institutions
                .Include(x => x.Employees)
                .FirstOrDefault(x => x.Id == institutionId);

            if (institution is null)
                throw new NotFoundException("Institution not found");

            var employeesDtos = _mapper.Map<List<EmployeeDto>>(institution.Employees);

            return employeesDtos;
        }

        public EmployeeDto GetById(int institutionId, int employeeId)
        {
            var institution = _dbContext.Institutions.FirstOrDefault(x => x.Id == institutionId);
            if (institution is null)
                throw new NotFoundException("Institution not found");

            var employee = _dbContext.Employees.FirstOrDefault(x => x.Id == employeeId);
            if (employee is null || employee.InstitutionId != institutionId)
            {
                throw new NotFoundException("Employee not found");
            }

            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return employeeDto;
        }

        public void RemoveAll(int institutionId)
        {
            var institution = _dbContext
                .Institutions
                .Include(x => x.Employees)
                .FirstOrDefault(x => x.Id == institutionId);

            if (institution is null)
                throw new NotFoundException("Institution not found");

            _dbContext.RemoveRange(institution.Employees);
            _dbContext.SaveChanges();
        }

        public void RemoveById(int institutionId, int employeeId)
        {
            var institution = _dbContext.Institutions.FirstOrDefault(x => x.Id == institutionId);
            if (institution is null)
                throw new NotFoundException("Institution not found");

            var employee = _dbContext.Employees.FirstOrDefault(x => x.Id == employeeId);
            if (employee is null || employee.InstitutionId != institutionId)
            {
                throw new NotFoundException("Employee not found");
            }

            _dbContext.Remove(employee);
            _dbContext.SaveChanges();

        }

        public void Update(UpdateEmployeeDto dto, int institutionId, int employeeId)
        {
            var institution = _dbContext.Institutions.FirstOrDefault(x => x.Id == institutionId);
            if (institution is null)
                throw new NotFoundException("Institution not found");

            var employee = _dbContext.Employees.FirstOrDefault(x => x.Id == employeeId);
            if (employee is null || employee.InstitutionId != institutionId)
            {
                throw new NotFoundException("Employee not found");
            }

            employee.Postion = dto.Postion;
            employee.Name = dto.Name;
            employee.SecoundName = dto.SecoundName;
            employee.LastName = dto.LastName;
            employee.Age = dto.Age;
            employee.Pesel = dto.Pesel;
            employee.PhoneNumber = dto.PhoneNumber;
            employee.ContactEmail = dto.ContactEmail;
            employee.Voicodeship = dto.Voicodeship;
            employee.City = dto.City;
            employee.Street = dto.Street;
            employee.PostalCode = dto.PostalCode;
            employee.BuldingNumber = dto.BuldingNumber;
            employee.ApartmentNumber = dto.ApartmentNumber;

            _dbContext.SaveChanges();
        }
    }
}
