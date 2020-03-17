using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    class CommentRepository:GenericRepository<CommentRepository>
    {
        public CommentRepository(DbContext context):base(context)
        {

        }
    }
}
