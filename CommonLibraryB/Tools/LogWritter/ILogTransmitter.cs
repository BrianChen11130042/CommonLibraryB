using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Tools.LogWritter
{
    public interface ILogTransmissionObservable
    {
        void AddLogTransmissionObserver(ILogTransmissionObserver o);
    }

    public interface ILogTransmissionObserver
    {
        Task NotifyLog(EStatus status, string msg);
    }
}
