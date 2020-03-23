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
    //[Route("api/[controller]")]
    [Route("[controller]/[action]/{id?}")]
    [ApiController]

    public class PlacesController : ApiController
    {
        private readonly IPlaceService _placeService;

        public PlacesController(IPlaceService service)
        {
            _placeService = service;
        }
        [HttpGet]
        public ActionResult GetAllPlaces()
        {
            var places = _placeService.GetPlaces();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PlaceDTO, PlaceViewModel>()).CreateMapper();
            var result = mapper.Map<IEnumerable<PlaceDTO>, List<PlaceViewModel>>(places);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        //[HttpGet("{id}")]
        public ActionResult GetPlace(int id)
        {
            var place = _placeService.GetPlace(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PlaceDTO, PlaceViewModel>()).CreateMapper();
            var result = mapper.Map<PlaceDTO, PlaceViewModel>(place);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult CreatePlace(PlaceViewModel place)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PlaceViewModel, PlaceDTO>()).CreateMapper();
            PlaceDTO result = mapper.Map<PlaceViewModel, PlaceDTO>(place);
            try
            {
                _placeService.InsertPlace(result);
                return Ok();
            }
            catch
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }
        [HttpPut]
        public ActionResult UpdatePlace(int id, PlaceViewModel place)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PlaceViewModel, PlaceDTO>()).CreateMapper();
            PlaceDTO result = mapper.Map<PlaceViewModel, PlaceDTO>(place);
            result.Id = id;
            try
            {
                _placeService.UpdatePlace(result);
                return Ok();
            }
            catch
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [HttpDelete]
        // [Route("Delete")]
        public ActionResult DeletePlace(int id)
        {
            try
            {
                _placeService.DeletePlace(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
        }

    }
}