using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IPersonService
    {
        IEnumerable<PersonDTO> GetPeople();
        PersonDTO GetPerson(int? id);
        void InsertPerson(PersonDTO person);
        void UpdatePerson(PersonDTO person);
        void DeletePerson(int? id);



        string GetPerson(string nickname);

    }
}
