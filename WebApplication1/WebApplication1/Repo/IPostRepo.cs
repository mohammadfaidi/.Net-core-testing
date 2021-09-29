using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.models;

namespace WebApplication1.Repo
{
    public interface IPostServ : IGenRepo<Posts>
    {

        public List<Posts> GetMyPosts();
      //  public Posts GetPostWithUsr();
        /*
        Posts Get(int id);
        IEnumerable<Posts> Get();
        void Add(Posts post);
        */
    }

    public class PostServ : GenRepo<Posts>, IPostServ
    {
        private readonly AppDBContext _dbContext;
        public PostServ(AppDBContext dBContext) : base(dBContext)
        {
            _dbContext = dBContext;
        }
        public List<Posts> GetMyPosts()
        {
            return _dbContext.posts.ToList();
        }
        /*
         //Question 
         public List<Posts>  GetPostWithUsr()
         {
             return _dbContext.posts.Include(p => p.User.posts);
         }
         */
    }
    /*
    public Posts Get(int id)
    {
        return _dbcontext.posts.FirstOrDefault(c=>c.id ==id);

    }
    public IEnumerable <Posts> Get()
    {
        return _dbcontext.posts.ToList();
    }

    public void Add(Posts post)
    {
        ///
    }

}
    */
}
