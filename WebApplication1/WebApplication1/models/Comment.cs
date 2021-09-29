using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.models
{
    public class Comment : IModelBase
    {
        public int id { get; set; }
        public string CoomentBody { get; set; }

    }
    

}
