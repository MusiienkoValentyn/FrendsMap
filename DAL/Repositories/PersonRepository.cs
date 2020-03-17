using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    class PersonRepository:GenericRepository<PersonRepository>
    {
        public PersonRepository(DbContext context):base(context)
        {

        }
    }
}
