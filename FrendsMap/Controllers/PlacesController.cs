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
namespace FrendsMap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly IPlaceService placeService;

        public PlacesController(IPlaceService service)
        {
            placeService = service;
        }

        // GET: api/Places
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Place>>> GetPlace()
        {
            IEnumerable<PlaceDTO> placeDtos = placeService.GetPlaces();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PlaceDTO, PlaceViewModel>()).CreateMapper();
            var places = mapper.Map<IEnumerable<PlaceDTO>, List<PlaceViewModel>>(placeDtos);
            if (places == null)
                return NotFound();
            return Ok(places);
        }

       // GET: api/Places/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Place>> GetPlace(int id)
        //{
        //     var place = await placeService.Place.FindAsync(id);

        //    if (place == null)
        //    {
        //        return NotFound();
        //    }

        //    return place;
        //}

        // PUT: api/Places/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPlace(int id, Place place)
        //{
        //    if (id != place.Id)
        //    {
        //        return BadRequest();
        //    }

        //  //  placeService.Entry(place).State = EntityState.Modified;

        //    try
        //    {
        //      //  await placeService.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PlaceExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Places
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Place>> PostPlace(PlaceViewModel place)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PlaceViewModel, PlaceDTO>()).CreateMapper();
            PlaceDTO result = mapper.Map<PlaceViewModel, PlaceDTO>(place);
            try
            {
                placeService.InsertPlace(result);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(Convert.ToInt32(HttpStatusCode.NoContent));
            }
        }

        // DELETE: api/Places/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Place>> DeletePlace(int id)
        //{
        //   // //var place = await placeService.Place.FindAsync(id);
        //   // if (place == null)
        //   // {
        //   //     return NotFound();
        //   // }

        //   // //placeService.Place.Remove(place);
        //   //// await placeService.SaveChangesAsync();

        //    return place;
        //}

        //private bool PlaceExists(int id)
        //{
        //    return placeService.Any(e => e.Id == id);
        //}
    }
}
