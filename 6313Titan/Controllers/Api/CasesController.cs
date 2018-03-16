using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _6313Titan.Models;
using _6313Titan.DTOs;
using AutoMapper;

namespace _6313Titan.Controllers.Api
{
    public class CasesController : ApiController
    {

        private ApplicationDbContext _context;

        public CasesController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<CaseDTO> GetCases()
        {
            return _context.Cases.ToList().Select(Mapper.Map<Case,CaseDTO>);
        }

        public IHttpActionResult GetCase(Guid Id)
        {
            var Case = _context.Cases.SingleOrDefault(c => c.Id == Id);

            if (Case == null)
                return NotFound();

            return Ok( Mapper.Map<Case,CaseDTO>(Case));
        }

        [HttpPost]
        public IHttpActionResult CreateCase(CaseDTO CaseDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Case = Mapper.Map<CaseDTO,Case> (CaseDto);
            Case.Id = Guid.NewGuid(); 
            _context.Cases.Add(Case);
            _context.SaveChanges();

            CaseDto.Id = Case.Id;
            return Created(new Uri (Request.RequestUri + "/" + Case.Id),CaseDto);
        }

        public void UpdateCase(Guid Id, CaseDTO CaseDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var CaseInDb = _context.Cases.SingleOrDefault(c => c.Id == Id);

            if (CaseInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(CaseDto,CaseInDb);

            _context.SaveChanges();
        }
    }
}
