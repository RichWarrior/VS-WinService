using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarukSahin.Service.Model
{
    public class Smtp
    {
        public string host { get; set; }
        public int port { get; set; }
        public string sender { get; set; }
        public string password { get; set; }
    }
}
