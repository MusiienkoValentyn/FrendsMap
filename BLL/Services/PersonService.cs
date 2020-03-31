using BLL.DTO;
using BLL.Exceptions;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public class PersonService : BaseService<PersonDTO, Person>, IPersonService
    {
        public PersonService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
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
                throw new ValidationException("Place not found", nameof(person));

            return ToBllEntity(person);
        }

        public void InsertPerson(PersonDTO person)
        {
            if (person == null)
                throw new ValidationException("Argument is null", nameof(person));

            Person personEntity = ToDalEntity(person);
            UnitOfWork.Person.Create(personEntity);
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






        public string GetPerson(string nickname)
        {

            var res = (from person in UnitOfWork.Person.GetAll()
                       where person.NickName == nickname
                       select person.NickName).ToList();

            if (res.Count > 0)
                return "Already here";
            else
                return "Ok";

        }

    }
}
