using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.Amr.Adapter
{
    public interface IAmrOperate<T>
    {
        //獲取AMR是否有在移動狀態
        Task<bool> GetMotionStatusAsync(T t);

        //獲取任務開始訊號
        Task<bool> GetMissionStartedAsync(T t);

        //設置任務開始
        Task<bool> SetMisssionStartAsync(T t);

        //獲取任務中止訊號
        Task<bool> GetMissionAbortAsync(T t);
        
        //任務完成
        Task<bool> SetMissionFinishResultAsync(T t);

        //任務信息
        Task<bool> GetMissionInformAsync(T t);

        //狀態信息
        Task<bool> SetWarehouseInformAsync(T t);

        //錯誤訊息
        Task<bool> SetErrorCodeAsync(T t);

        Task<bool> ResetErrorCodeAsync(T t);

        //提取全部的庫位序號
        public void GetDeployData(T t);

        //獲取儲位任務取消訊息
        Task<bool> GetMissionCancelInform(T t);

        //設置上模組Robot是某有在動作
        Task<bool> SetRobotMotionStatusAsync(T t);

    }
}
