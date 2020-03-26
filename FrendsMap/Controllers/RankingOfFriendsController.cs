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
    public class RankingOfFriendsController: ApiController
    {
        private readonly IRankingOfFriendService _rankingOfFriendService;

        public RankingOfFriendsController(IRankingOfFriendService service)
        {
            _rankingOfFriendService = service;
        }

        [HttpGet]
        public ActionResult GetAllRankingOfFriends()
        {
            var rankingOfFriend = _rankingOfFriendService.GetRankingOfFriends();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RankingOfFriendDTO, RankingOfFriendViewModel>()).CreateMapper();
            var result = mapper.Map<IEnumerable<RankingOfFriendDTO>, List<RankingOfFriendViewModel>>(rankingOfFriend);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        //[HttpGet("{id}")]
        public ActionResult GetRankingOfFriend(int id)
        {
            var rankingOfFriend = _rankingOfFriendService.GetRankingOfFriend(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RankingOfFriendDTO, RankingOfFriendViewModel>()).CreateMapper();
            var result = mapper.Map<RankingOfFriendDTO, RankingOfFriendViewModel>(rankingOfFriend);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult CreateRankingOfFriend(RankingOfFriendViewModel ranking)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RankingOfFriendViewModel, RankingOfFriendDTO>()).CreateMapper();
            RankingOfFriendDTO result = mapper.Map<RankingOfFriendViewModel, RankingOfFriendDTO>(ranking);
            try
            {
                _rankingOfFriendService.InsertRankingOfFriend(result);
                return Ok();
            }
            catch
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [HttpPut]
        public ActionResult UpdateRankingOfFriend(int id, RankingOfFriendViewModel ranking)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RankingOfFriendViewModel, RankingOfFriendDTO>()).CreateMapper();
            RankingOfFriendDTO result = mapper.Map<RankingOfFriendViewModel, RankingOfFriendDTO>(ranking);
            result.Id = id;
            try
            {
                _rankingOfFriendService.UpdateRankingOfFriend(result);
                return Ok();
            }
            catch
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [HttpDelete]
        // [Route("Delete")]
        public ActionResult DeleteRankingOfFriend(int id)
        {
            try
            {
                _rankingOfFriendService.DeleteRankingOfFriend(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
        }

    }
}
