using System;
using System.Collections.Generic;
using System.Linq;

namespace FarukSahin.DataAccessLayer.DLL
{
    public class Server_Info : Base
    {
        public List<Entities.Server_Info> List()
        {
            var result = new List<Entities.Server_Info>();
            try
            {
                result = dbContext.Server_Info.ToList();
            }
            catch (Exception)
            {
            }
            return result;
        }
    }
}
