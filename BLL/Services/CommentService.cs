using BLL.DTO;
using BLL.Exceptions;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class CommentService : BaseService<CommentDTO, Comment>, ICommentService
    {
        public CommentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void DeleteComment(int? id)
        {
            if (id == null)
                throw new ValidationException("Argument is null", nameof(id));

            UnitOfWork.Comment.Delete(id.Value);
            UnitOfWork.Save();
        }

        public CommentDTO GetComment(int? id)
        {
            if (id == null)
                throw new ValidationException("Argmunet is null", nameof(id));

            var comment = UnitOfWork.Comment.Get(id.Value);

            if (comment == null)
                throw new ValidationException("Place not found", nameof(comment));

            return ToBllEntity(comment);
        }

        public IEnumerable<CommentDTO> GetComments()
        {
            return ToBllEntity(UnitOfWork.Comment.GetAll());
        }

        public void InsertComment(CommentDTO comment)
        {
            if (comment == null)
                throw new ValidationException("Argument is null", nameof(comment));

            Comment commentEntity = ToDalEntity(comment);
            UnitOfWork.Comment.Create(commentEntity);
            UnitOfWork.Save();
        }

        public void UpdateComment(CommentDTO comment)
        {
            if (comment == null)
                throw new ValidationException("Argument is null", nameof(comment));
            comment.DateTimeOfAdding = DateTime.UtcNow;

            Comment commentEntity = ToDalEntity(comment);
            UnitOfWork.Comment.Update(commentEntity);
            UnitOfWork.Save();
        }
    }
}
