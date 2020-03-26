using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using BLL.Interfaces;
using BLL.DTO;
using AutoMapper;
using FrendsMap.Models;
using BLL.Services;
using DAL.Entities;
using System.Net;
using BLL.Infrastructure;
using System.Web.Http;
namespace FrendsMap.Controllers
{
    [Route("[controller]/[action]/{id?}")]
    [ApiController]
    public class PeopleController: ApiController
    {
        private readonly IPersonService _personService;

        public PeopleController(IPersonService service)
        {
            _personService = service;
        }
        [HttpGet]
        public ActionResult GetAllPeople()
        {
            var people = _personService.GetPeople();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PersonDTO, PersonViewModel>()).CreateMapper();
            var result = mapper.Map<IEnumerable<PersonDTO>, List<PersonViewModel>>(people);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        //[HttpGet("{id}")]
        public ActionResult GetPerson(int id)
        {
            var person = _personService.GetPerson(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PersonDTO, PersonViewModel>()).CreateMapper();
            var result = mapper.Map<PersonDTO, PersonViewModel>(person);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult CreatePerson(PersonViewModel person)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PersonViewModel, PersonDTO>()).CreateMapper();
            PersonDTO result = mapper.Map<PersonViewModel, PersonDTO>(person);
            try
            {
                _personService.InsertPerson(result);
                return Ok();
            }
            catch
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }
        [HttpPut]
        public ActionResult UpdatePerson(int id, PersonViewModel person)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PersonViewModel, PersonDTO>()).CreateMapper();
            PersonDTO result = mapper.Map<PersonViewModel, PersonDTO>(person);
            result.Id = id;
            try
            {
                _personService.UpdatePerson(result);
                return Ok();
            }
            catch
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [HttpDelete]
        // [Route("Delete")]
        public ActionResult DeletePerson(int id)
        {
            try
            {
                _personService.DeletePerson(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
        }
    }
}
