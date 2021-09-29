using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.models
{
    public class Users :IModelBase
    {

        public int id { get; set; } 
        public string name { get; set; } 
        public string email { get; set; } 
        public string phone { get; set; } 
        public string date { get; set; }
        public ICollection<Posts> posts { get; set; }
        //  public Posts Posts { get; set; }
        /*
        List<Posts> Lst = new List<Posts>();
        public List<Posts> GetSetPost
        {   get
            {
                return Lst;
            }
            set
            {
                Lst = value;
            }

        }
        */
    }
        
}

            /*string name;
        string phone;
        string dob;
        string email;
        int id;

        public Users()
        {
        }

        public Users(string name, string ph, string date, string email, int id)
        {
            this.name = name;
            this.phone = ph;
            this.dob = date;
            this.email = email;
            this.id = id;
        }
        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Dob { get => dob; set => dob = value; }
        public string Email { get => email; set => email = value; }
        public int Id { get => id; set => id = value; }
    }

        */