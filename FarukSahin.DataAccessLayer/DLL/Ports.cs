using System;
using System.Collections.Generic;
using System.Linq;

namespace FarukSahin.DataAccessLayer.DLL
{
    public class Ports : Base
    {
        public List<Entities.Ports> List()
        {
            var result = new List<Entities.Ports>();
            try
            {
                result = dbContext.Ports.ToList();
            }
            catch (Exception)
            {
            }
            return result;
        }
    }
}
