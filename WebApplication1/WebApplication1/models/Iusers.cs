using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.models
{
  public  interface IUser
    {
        Users get(int id);
        List<Users> getall();
        void addUser(Users u);

        void DeleteUser(int x);
    }
}
