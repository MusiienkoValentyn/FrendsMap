﻿using BLL.DTO;
using BLL.Exceptions;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FreeImageAPI;
using System.Collections;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using NLog.Internal;
using System.Configuration;
using FreeImageAPI.Metadata;

namespace BLL.Services
{
    public class PersonService : BaseService<PersonDTO, Person>, IPersonService
    {
        private IUnitOfWork _unitOfWork;
        public PersonService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void DeletePerson(int? id)
        {
            if (id == null)
                throw new ValidationException("Argument is null", nameof(id));

            UnitOfWork.Person.Delete(id.Value);
            UnitOfWork.Save();
        }


        public IEnumerable<PersonDTO> GetPeople()
        {
            return ToBllEntity(UnitOfWork.Person.GetAll());
        }

        public PersonDTO GetPerson(int? id)
        {
            if (id == null)
                throw new ValidationException("Argmunet is null", nameof(id));

            var person = UnitOfWork.Person.Get(id.Value);

            if (person == null)
                throw new ValidationException("Person not found", nameof(person));

            return ToBllEntity(person);
        }
        public PersonDTO GetPersonByGoogleId(string id)
        {
            if (id == null)
                throw new ValidationException("Argmunet is null", nameof(id));

            var res = (from person in UnitOfWork.Person.GetAll()
                       where person.IDUserOfGoogle == id
                       select person).FirstOrDefault();

            if (res == null)
                throw new ValidationException("Person not found", nameof(res));

            return ToBllEntity(res);
        }

        public bool GetPerson(string nickname)
        {
            if (nickname == null)
                throw new ValidationException("Argmunet is null", nameof(nickname));

            var res = (from person in UnitOfWork.Person.GetAll()
                       where person.NickName == nickname
                       select person.NickName).ToList();

            if (res.Count > 0)
                return true;
            else
                return false;
        }
        public bool GetPersonIDUserOfGoogle(string id)
        {
            if (id == null)
                throw new ValidationException("Argmunet is null", nameof(id));

            var res = (from person in UnitOfWork.Person.GetAll()
                       where person.IDUserOfGoogle == id
                       select person.IDUserOfGoogle).ToList();

            if (res.Count > 0)
                return true;
            else
                return false;
        }

        public void InsertPerson(PersonDTO person)
        {
            if (person == null)
                throw new ValidationException("Argument is null", nameof(person));

            
            Person personEntity = ToDalEntity(person);
            personEntity.Avatar = $"{personEntity.NickName}Avatar";
            UnitOfWork.Person.Create(personEntity);

            MemoryStream ms = new MemoryStream(person.Image.GetBytes().Result);

            Task.Run(() => AddImage.UploadFile(ms,  personEntity.Avatar));
            UnitOfWork.Save();
        }

       

        public void UpdatePerson(PersonDTO person)
        {
            if (person == null)
                throw new ValidationException("Argument is null", nameof(person));

            var gId = (from p in UnitOfWork.Person.GetAll() where p.IDUserOfGoogle == person.IDUserOfGoogle select p).FirstOrDefault();

            
            Person personEntity = ToDalEntity(person);
            personEntity.Id = gId.Id;
            personEntity.Avatar = $"{personEntity.NickName}Avatar";
            personEntity.Rating = gId.Rating;
           
            UnitOfWork.Person.Update(personEntity);

            MemoryStream ms = new MemoryStream(person.Image.GetBytes().Result);

            Task.Run(() => AddImage.UploadFile(ms, personEntity.Avatar));
            UnitOfWork.Save();
        }

        public object GetRecommendedPlaces(int id)
        {

            var res2 = (from p in UnitOfWork.Person.GetAll()
                        join rp in UnitOfWork.RankingOfFriend.GetAll()
                        on p.Id equals rp.FriendId
                        
                        join t in UnitOfWork.TypeOfPlace.GetAll()
                        on rp.TypeOfPlaceId equals t.Id

                        join pl in UnitOfWork.Place.GetAll() 
                        on t.Id equals pl.TypeOfPlaceId

                        join r in UnitOfWork.Ranking.GetAll()
                        on pl.Id equals r.PlaceId  
                       
                        where rp.PersonId == id where r.PersonId == rp.FriendId
                        
                        group new { p, rp, r, pl } by new { pl.Name } into result
                        let qq = result.FirstOrDefault()
                        let place = qq.pl.Name
                        let PlaceId=qq.pl.Id
                        
                        select new
                        {
                            a=result.Average(q=>q.r.Mark*q.rp.Mark),
                           place,
                           PlaceId
                       }
                       
                   ).OrderByDescending(x=>x.a).ToList();

            return res2;
        }

        public IEnumerable<PersonDTO> GetFriends(int id)
        {
            var res= (from f in UnitOfWork.Person.GetAll()
                    join rf in UnitOfWork.RankingOfFriend.GetAll()
                    on f.Id equals rf.FriendId
                    where rf.PersonId == id
                    select f).Distinct().ToList();
            
           return ToBllEntity(res);
        }
        
    }
}
