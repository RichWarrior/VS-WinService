using FarukSahin.DataAccessLayer.Entities;

namespace FarukSahin.DataAccessLayer.DLL
{
    public class Base
    {
        public MainEntities dbContext { get; set; }
        public Base()
        {
            dbContext = new MainEntities();
            dbContext.Configuration.LazyLoadingEnabled = false;
        }
    }
}
