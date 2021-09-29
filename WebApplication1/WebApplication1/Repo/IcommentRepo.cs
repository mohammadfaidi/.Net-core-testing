using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.models;

namespace WebApplication1.Repo
{
    interface IcommentRepo:IGenRepo<Comment>
    {


    }

    class CommentRepo:GenRepo<Comment>, IcommentRepo
    {
    public CommentRepo(AppDBContext dBContext) : base(dBContext)
        {
            
        }
    }
}
