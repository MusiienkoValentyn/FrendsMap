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
    public class TypeOfPlacesController : ApiController
    {
        private readonly ITypeOfPlaceService _typeOfPlaceService;

        public TypeOfPlacesController(ITypeOfPlaceService placeService)
        {
            _typeOfPlaceService = placeService;
        }

        [HttpGet]
        public ActionResult GetAllTypeOfPlaces()
        {
            var typeOfPlaces = _typeOfPlaceService.GetTypeOfPlaces();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TypeOfPlaceDTO, TypeOfPlaceViewModel>()).CreateMapper();
            var result = mapper.Map<IEnumerable<TypeOfPlaceDTO> , List<TypeOfPlaceViewModel>>(typeOfPlaces);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        public ActionResult GetTypeOfPlace(int id)
        {
            var typeOfPlaces = _typeOfPlaceService.GetTypeOfPlace(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TypeOfPlaceDTO, TypeOfPlaceViewModel>()).CreateMapper();
            var result = mapper.Map<TypeOfPlaceDTO, TypeOfPlaceViewModel>(typeOfPlaces);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult CreateTypeOfPlace(TypeOfPlaceViewModel typeOfPlaces)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TypeOfPlaceViewModel, TypeOfPlaceDTO>()).CreateMapper();
            TypeOfPlaceDTO result = mapper.Map<TypeOfPlaceViewModel, TypeOfPlaceDTO>(typeOfPlaces);
            try
            {
                _typeOfPlaceService.InsertTypeOfPlace(result);
                return Ok();
            }
            catch
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }
        [HttpPut]
        public ActionResult UpdateTypeOfPlace(int id, TypeOfPlaceViewModel typeOfPlaces)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TypeOfPlaceViewModel, TypeOfPlaceDTO>()).CreateMapper();
            TypeOfPlaceDTO result = mapper.Map<TypeOfPlaceViewModel, TypeOfPlaceDTO>(typeOfPlaces);
            result.Id = id;
            try
            {
                _typeOfPlaceService.UpdateTypeOfPlace(result);
                return Ok();
            }
            catch
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [HttpDelete]
        // [Route("Delete")]
        public ActionResult DeleteTypeOfPlace(int id)
        {
            try
            {
                _typeOfPlaceService.DeleteTypeOfPlace(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
        }

    }
}
