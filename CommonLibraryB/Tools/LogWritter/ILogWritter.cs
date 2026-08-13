using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Tools.LogWritter
{
    public interface INLogObservable
    {
        void AddNLogObserver(INLogObserver o);

        void RemoveNLogObserver(INLogObserver o);

        Task NotifyNLog(EStatus status, string msg);
    }

    public interface INLogObserver
    {
        Task HandleNLog(EStatus status, string msg);
    }
}
