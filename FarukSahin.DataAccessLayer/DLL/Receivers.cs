using System;
using System.Collections.Generic;
using System.Linq;

namespace FarukSahin.DataAccessLayer.DLL
{
    public class Receivers : Base
    {
        public List<Entities.Receivers> List()
        {
            var result = new List<Entities.Receivers>();
            try
            {
                result = dbContext.Receivers.ToList();
            }
            catch (Exception)
            {
            }
            return result;
        }
    }
}
