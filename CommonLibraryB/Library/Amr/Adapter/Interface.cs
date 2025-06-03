using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.Amr.Adapter
{
    public interface IAmrOperate<T>
    {
        //獲取任務開始訊號
        Task<bool> GetMissionStartedAsync(T t);

        //設置任務開始
        Task<bool> SetMisssionStartAsync(T t);
        
        //任務完成
        Task<bool> SetMissionFinishResultAsync(T t);

        //任務信息
        Task<bool> GetMissionInformAsync(T t);

        //狀態信息
        Task<bool> SetWarehouseInformAsync(T t);

        //錯誤訊息
        Task<bool> SetErrorCodeAsync(T t);

        //提取全部的庫位序號
        public void GetDeployData(T t);

    }
}
