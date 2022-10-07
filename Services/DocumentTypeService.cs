using AutoMapper;
using eUrzad.Entities;
using eUrzad.Exceptions;
using eUrzad.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace eUrzad.Services
{
    public interface IDocumentTypeService
    {
        int Create(int institutionId, CreateDocumentTypeDto dto);
        DocumentTypeDto GetById(int institutionId, int documentTypeId);
        List<DocumentTypeDto> GetAll(int institutionId);
        void RemoveAll(int institutionId);
        void RemoveById(int institutionId, int documentTypeId);
        void Update(UpdateDocumentTypeDto dto, int institutionId, int documentTypeId);
    }

    public class DocumentTypeService : IDocumentTypeService
    {
        private readonly InstitutionDbContext _dbContext;
        private readonly IMapper _mapper;

        public DocumentTypeService(InstitutionDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public int Create(int institutionId, CreateDocumentTypeDto dto)
        {
            var institution = _dbContext.Institutions.FirstOrDefault(x => x.Id == institutionId);
            if (institution is null)
                throw new NotFoundException("Institution not found");

            var institutionEntity = _mapper.Map<DocumentType>(dto);

            institutionEntity.InstitutionId = institutionId;

            _dbContext.DocumentTypes.Add(institutionEntity);
            _dbContext.SaveChanges();

            return institutionEntity.Id;
        }

        public List<DocumentTypeDto> GetAll(int institutionId)
        {
            var institution = _dbContext
                .Institutions
                .Include(x => x.DocumentTypes)
                .FirstOrDefault(x => x.Id == institutionId);

            if (institution is null)
                throw new NotFoundException("Institution not found");

            var documentDtos = _mapper.Map<List<DocumentTypeDto>>(institution.DocumentTypes);

            return documentDtos;
        }

        public DocumentTypeDto GetById(int institutionId, int documentTypeId)
        {
            var institution = _dbContext.Institutions.FirstOrDefault(x => x.Id == institutionId);
            if (institution is null)
                throw new NotFoundException("Institution not found");

            var document = _dbContext.DocumentTypes.FirstOrDefault(x => x.Id == documentTypeId);
            if (document is null || document.InstitutionId != institutionId)
            {
                throw new NotFoundException("Customer not found");
            }

            var documentDto = _mapper.Map<DocumentTypeDto>(document);
            return documentDto;
        }

        public void RemoveAll(int institutionId)
        {
            var institution = _dbContext
                .Institutions
                .Include(x => x.DocumentTypes)
                .FirstOrDefault(x => x.Id == institutionId);

            if (institution is null)
                throw new NotFoundException("Institution not found");


            _dbContext.RemoveRange(institution.DocumentTypes);
            _dbContext.SaveChanges();
        }

        public void RemoveById(int institutionId, int documentTypeId)
        {
            var institution = _dbContext.Institutions.FirstOrDefault(x => x.Id == institutionId);
            if (institution is null)
                throw new NotFoundException("Institution not found");

            var document = _dbContext.DocumentTypes.FirstOrDefault(x => x.Id == documentTypeId);
            if (document is null || document.InstitutionId != institutionId)
            {
                throw new NotFoundException("Customer not found");
            }

            _dbContext.Remove(document);
            _dbContext.SaveChanges();
        }

        public void Update(UpdateDocumentTypeDto dto, int institutionId, int documentTypeId)
        {
            var institution = _dbContext.Institutions.FirstOrDefault(x => x.Id == institutionId);
            if (institution is null)
                throw new NotFoundException("Institution not found");

            var document = _dbContext.DocumentTypes.FirstOrDefault(x => x.Id == documentTypeId);
            if (document is null || document.InstitutionId != institutionId)
            {
                throw new NotFoundException("Customer not found");
            }

            document.Name = dto.Name;

            _dbContext.SaveChanges();
        }
    }
}
