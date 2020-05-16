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
    public class CommentsController:ApiController
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService service)
        {
            _commentService = service;
        }

        [HttpGet]
        public ActionResult GetAllComments()
        {
            var comments = _commentService.GetComments();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CommentDTO, CommentViewModel>()).CreateMapper();
            var result = mapper.Map<IEnumerable<CommentDTO>, List<CommentViewModel>>( comments);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public ActionResult GetComment(int id)
        {
            var comment = _commentService.GetComment(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CommentDTO, CommentViewModel>()).CreateMapper();
            var result = mapper.Map<CommentDTO, CommentViewModel>(comment);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult CreateComment(CommentViewModel place)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CommentViewModel, CommentDTO>()).CreateMapper();
            CommentDTO result = mapper.Map<CommentViewModel, CommentDTO>(place);
            try
            {
                _commentService.InsertComment(result);
                return Ok();
            }
            catch
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [HttpPut]
        public ActionResult UpdateComment(CommentViewModel place)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CommentViewModel, CommentDTO>()).CreateMapper();
            CommentDTO result = mapper.Map<CommentViewModel, CommentDTO>(place);

            try
            {
                _commentService.UpdateComment(result);
                return Ok();
            }
            catch
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [HttpDelete]
        // [Route("Delete")]
        public ActionResult DeleteComment(int id)
        {
            try
            {
                _commentService.DeleteComment(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
        }

        [HttpGet]
        public ActionResult GetCommentByPlaceId(int id)
        {
            var comments = _commentService.GetCommentsByPlaceId(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ComentPersonDTO, ComentPersonViewModel>()).CreateMapper();
            var result = mapper.Map<IEnumerable<ComentPersonDTO>, List<ComentPersonViewModel>>(comments);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
