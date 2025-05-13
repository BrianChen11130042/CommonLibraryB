using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.Amr.Adapter
{
    public interface IAmrOperate<T>
    {
        //任務開始
        Task<bool> GetIsMissionStartedAsync(T t);

        //任務取消
        Task<bool> GetIsMissionCanceledAsync(T t);
        
        //任務完成
        Task<bool> SetMissionCompletedResultAsync(T t);

        //任務信息
        Task<bool> GetMissionInformAsync(T t);

        //狀態信息
        Task<bool> SetWarehouseInformAsync(T t);

        //執行機構動作
        Task<bool> SetRobotErrorMessageAsync(T t);

        Task<bool> SetRobotIdleMessageAsync(T t);

        Task<bool> SetRobotCompletedMessageAsync(T t);

        Task<bool> SetRobotRunningMessageAsync(T t);

    }
}
