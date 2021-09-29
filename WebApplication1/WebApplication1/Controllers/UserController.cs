
using WebApplication1.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Repo;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        //   private readonly AppDBContext _dbContext;
        private readonly IPostServ _postServ;
        private readonly IUserServ _userServ;
        private readonly IMapper _mapper;
        

        // IUser InjectDep = null;
        /*
                public UserController(IUser Iu)
                {
                    this.InjectDep = Iu;
                   // _dbContext = new AppContext();
                }
        */
        /*
        public UserController(AppDBContext dbContext)
        {
             
            this._dbContext = dbContext;
            // _dbContext = new AppContext();
        }*/

        public UserController(IUserServ userServ,IMapper mapper, IPostServ postServ)
        {
            _userServ = userServ;
            _mapper = mapper;
            _postServ = postServ;
        }
        /*
        [HttpGet("Error")]
        public IEnumerable<string> Get() => throw new NullReferenceException("Null Reference exception!");
        */
        /*
        public IActionResult Get()
        {
            try
            {
                var data = GetData(); //Assume you get some data here which is also likely to throw an exception in certain cases.
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        
        }
        */
        [HttpGet("GetUserWithPosts")]
        public Users GetUserWithPosts()
        {
            return _userServ.GetWithPosts();

        }
        [HttpGet("GetPosts")]

        public List< Posts> GetPosts()
        {
            return _postServ.GetMyPosts();

        }
        /*
        [HttpGet("GetPostsWithUser")]

        public Users GetPostsWithUse()
        {
            return _postServ.GetPostWithUsr();

        }
        */

        [HttpGet("GetPage/{size}/{index}")]
        public Task <IEnumerable<Users>> GetPage(int size,int index)
        {
            return _userServ.GetPage(size, index);
        }

        [HttpGet]
        ///to fix bugs neet to convert User to UserView model as generic 
        ///to fix bugs neet to convert User to UserView model as generic 
        public async Task <IEnumerable<UserViewModel>> getall()
        {
            //IEnumerable ===List


            // Users user = new Users();
            //  var UVM = _mapper.Map<UserViewModel>(user);

             throw new Exception("This is a exception that will be handler by middleware");
            var u =  _mapper.Map<IEnumerable<UserViewModel>>(await _userServ.Get()).Skip(1).Take(2);
            // await Task.WhenAll((IEnumerable<Task>)u);
            return u; 


            //return (IEnumerable<Users>)UVM;
            // return _userServ.Get();
            // return _dbContext.users.ToList();

            //How can I get all post in Users

            /*   List<Posts> List = new List<Posts>();

               Posts a = new Posts();

               a.body = "ssdddssssss";
               a.id = 1234;
               a.title = "Hello";



               Posts b = new Posts();

               a.body = "Assdalto";
               a.id = 4444;
               a.title = "word";


               List.Add(a);

               List.Add(b);



               Users p = new Users();

               p.id = 0598178584;

               p.name = "Kayal";
               p.email = "moha@gg";

               p.phone = "09312";
               p.date = "2010";

               p.GetSetPost = List;
               //  _dbContext.users.Add(new Users() { id = 1000, name = "ali", email = "ali@gmail.com", phone = "0098", date = "2021/09/23" ,});
               _dbContext.users.Add(p);
               _dbContext.SaveChanges();
            */
            // return us;
        }


        [HttpGet("{id}")]
        public async Task<Users> get(int id)
        {
            //  return _dbContext.users.SingleOrDefault(item => item.id == id);
            //return _dbContext.users.SingleOrDefault(item => item.id==id);
            Users u = await _userServ.Get(id);
            return u;
            // return InjectDep.get(id);
            //  return us.SingleOrDefault(item => item.id == id);
        }

        [HttpPost]
        public async Task addUser([FromBody] Users u)
        {
            // _userServ.Add(u);
         await _userServ.Add(u);
            //_userServ.s
            // _userServ.SaveChanges();
            // _dbContext.users.Add(u);
            // _dbContext.SaveChanges();
            //InjectDep.addUser(u);
            //us.Add(u);

        }
       

        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {

            //   InjectDep.DeleteUser(id);
            /*  var delus = us.SingleOrDefault(item => item.id .equals (id));
              if (delus != null)
                  us.Remove(delus);

            */
            /*
            var delus = _dbContext.users.SingleOrDefault(item => item.id==id);
            if (delus != null)
            {
                _dbContext.users.Remove(delus);
                _dbContext.SaveChanges();
            }
               */
          //  var delus = _userServ.


        }

        /*
         * 
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id,[FromBody] Users USRRR)
        {
            var ouser = us.SingleOrDefault(x => x.id == id);
            if (ouser == null)
            {
                return NotFound("No Found");
            }
            ouser.name = USRRR.name;
            ouser.email = USRRR.email;
            ouser.phone = USRRR.phone;
            ouser.date = USRRR.date;
            //   us.Add(ouser);
            /*
               if (us.Count == 0)
               {
                   return NotFound("No List found");
               }
               return Ok(us);
            */
            //  retun Ok(us); 
            //return Ok(us);
        
        }
    
    }


  


