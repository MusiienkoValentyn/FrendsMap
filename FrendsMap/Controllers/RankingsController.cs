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
    public class RankingsController : ApiController
    {
        private readonly IRankingService _rankingService;

        public RankingsController(IRankingService service)
        {
            _rankingService = service;
        }

        [HttpGet]
        public ActionResult GetAllRankings()
        {
            var rankings = _rankingService.GetRankings();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RankingDTO, RankingViewModel>()).CreateMapper();
            var result = mapper.Map<IEnumerable<RankingDTO>, List<RankingViewModel>>(rankings);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public ActionResult GetRanking(int id)
        {
            var ranking = _rankingService.GetRanking(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RankingDTO, RankingViewModel>()).CreateMapper();
            var result = mapper.Map<RankingDTO, RankingViewModel>(ranking);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult CreateRanking(RankingViewModel ranking)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RankingViewModel, RankingDTO>()).CreateMapper();
            RankingDTO result = mapper.Map<RankingViewModel, RankingDTO>(ranking);
            try
            {
                _rankingService.InsertRanking(result);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [HttpPut]
        public ActionResult UpdateRanking(RankingViewModel ranking)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RankingViewModel, RankingDTO>()).CreateMapper();
            RankingDTO result = mapper.Map<RankingViewModel, RankingDTO>(ranking);

            try
            {
                _rankingService.UpdateRanking(result);
                return Ok();
            }
            catch
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [HttpDelete]
        public ActionResult DeleteRanking(int id)
        {
            try
            {
                _rankingService.DeleteRanking(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
        }
    }
}
