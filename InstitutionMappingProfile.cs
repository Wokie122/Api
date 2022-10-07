using eUrzad.Entities;
using eUrzad.Models;
using AutoMapper;

namespace eUrzad
{
    public class InstitutionMappingProfile : Profile
    {
        public InstitutionMappingProfile()
        {
            CreateMap<Institution, InstitutionDto>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<DocumentType, DocumentTypeDto>();

            CreateMap<CreateInstitutionDto, Institution>();
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<CreateDocumentTypeDto, DocumentType>();
        }
    }
}
