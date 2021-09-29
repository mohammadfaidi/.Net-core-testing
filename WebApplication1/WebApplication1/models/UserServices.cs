using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.models
{
    public class UserServices : IUser
    {
        private readonly AppDBContext _context;
        public UserServices(AppDBContext context)
        {
            _context = context;
        }
        List<Users> us = new List<Users>()
        {
            new Users() { id = 1000, name = "ali", email = "ali@gmail.com", phone = "0098", date = "2021/09/23" },
            new Users() { id = 1001, name = "basel", email = "basel@gmail.com", phone = "0123", date = "2021/09/23" },
            new Users() { id = 1002, name = "samar", email = "samar@gmail.com", phone = "0981", date = "2021/09/23" },
            new Users() { id = 1003, name = "mohamad", email = "mohamad@gmail.com", phone = "0093", date = "2021/09/23" },
            new Users() { id = 1004, name = "zyan", email = "zyan@gmail.com", phone = "1241", date = "2021/09/23" },

        };
       // [HttpPost]
        public void addUser([FromBody]Users u)
        {
            us.Add(u);

        }
       // [HttpDelete("{id}")]
        public void DeleteUser(int x)
        {
            var delus = us.SingleOrDefault(item =>item.id==x);
            if (delus != null)
                us.Remove(delus);
               
        }

     //   [HttpGet("{id}")]
        public Users get(int id)
        {
            return us.SingleOrDefault(item => item.id == id);
        }
      //  [HttpGet]
        public List<Users> getall()
        {
            _context.users.Add(new Users() { id = 1000, name = "ali", email = "ali@gmail.com", phone = "0098", date = "2021/09/23" });
            _context.SaveChanges();
            return us;
        }
    }
}
