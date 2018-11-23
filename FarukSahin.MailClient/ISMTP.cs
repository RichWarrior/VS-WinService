using System.Collections.Generic;
using System.Threading.Tasks;
using static FarukSahin.MailClient.Model;

namespace FarukSahin.MailClient
{
    public interface ISMTP
    {
        Task<bool> SendAsync();
        Task<bool> SendAsyncRange(List<string> list);
        bool Send();
        bool SendRange(List<ReceiverModel> list);
    }
}
