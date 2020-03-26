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
    public class PhotosController:ApiController
    {
        private IPhotoService _photoService;

        public PhotosController(IPhotoService service)
        {
            _photoService = service;
        }

        [HttpGet]
        public ActionResult GetAllPhotos()
        {
            var photos = _photoService.GetPhotos();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PhotoDTO, PhotoViewModel>()).CreateMapper();
            var result = mapper.Map<IEnumerable<PhotoDTO>, List<PhotoViewModel>>(photos);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        //[HttpGet("{id}")]
        public ActionResult GetPhoto(int id)
        {
            var photo = _photoService.GetPhoto(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PhotoDTO, PhotoViewModel>()).CreateMapper();
            var result = mapper.Map<PhotoDTO, PhotoViewModel>(photo);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult CreatePhoto(PhotoViewModel photo)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PhotoViewModel, PhotoDTO>()).CreateMapper();
            PhotoDTO result = mapper.Map<PhotoViewModel, PhotoDTO>(photo);
            try
            {
                _photoService.InsertPhoto(result);
                return Ok();
            }
            catch
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [HttpPut]
        public ActionResult UpdatePhoto(int id, PhotoViewModel place)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PhotoViewModel, PhotoDTO>()).CreateMapper();
            PhotoDTO result = mapper.Map<PhotoViewModel, PhotoDTO>(place);
            result.Id = id;
            try
            {
                _photoService.UpdatePhotoe(result);
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
                _photoService.DeletePhoto(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
        }

    }
}
