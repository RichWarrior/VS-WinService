using FarukSahin.DataAccessLayer.DLL;

namespace FarukSahin.DataAccessLayer
{
    public class BLL
    {
        private Ports _ports { get; set;}
        private Receivers _receivers { get; set; }
        private Server_Info _server_info { get; set; }

        public Ports Ports()
        {
            if (_ports == null)
                _ports = new Ports();
            return _ports;
        }

        public Receivers Receivers()
        {
            if (_receivers == null)
                _receivers = new Receivers();
            return _receivers;
        }
       
        public  Server_Info Server_Info()
        {
            if (_server_info == null)
                _server_info = new Server_Info();
            return _server_info;
        }
    }
}
