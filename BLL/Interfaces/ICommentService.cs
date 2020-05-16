using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface ICommentService
    {
        IEnumerable<CommentDTO> GetComments();
        CommentDTO GetComment(int? id);
        void InsertComment(CommentDTO place);
        void UpdateComment(CommentDTO place);
        void DeleteComment(int? id);
        IEnumerable<ComentPersonDTO> GetCommentsByPlaceId(int id);
    }
}
