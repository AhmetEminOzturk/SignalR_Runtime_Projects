using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRServerExample.Interfaces
{
    public interface IMessageClient
    {
        Task Clients(List<string> cliets);
        Task UserJoined(string connectionId);
        Task UserLeaved(string connectionId);
    }
}
