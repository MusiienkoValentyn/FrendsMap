using BLL.DTO;
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

            Person personEntity = ToDalEntity(person);
            UnitOfWork.Person.Update(personEntity);
            UnitOfWork.Save();
        }


        private List<int> GetPersonIdAndAmountOfImagesByNickname(string nick)
        {
            if (nick == null)
                throw new ValidationException("Argmunet is null", nameof(nick));

            var person = from pers in UnitOfWork.Person.GetAll()
                         where pers.NickName == nick
                         select pers;

            int personId = 0;
            foreach (var p in person)
            {
                personId = p.Id;
            };

            var AmountImages = from photo in UnitOfWork.Photo.GetAll()
                               where photo.PersonId == personId
                               select photo.Id;

            List<int> list = new List<int>();
            list.Add(personId);
            list.Add(AmountImages.Count());

            if (list == null)
                throw new ValidationException("Person not found", nameof(list));

            return list;
        }

    }
}
