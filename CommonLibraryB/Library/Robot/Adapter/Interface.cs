using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.Robot.Adapter
{

    public interface IRobotOperate<T>
    {
        public Task<bool> SetOnPositionAsync(T t);

        public Task<bool> SetMissionDataAsync(T t);

        public Task<bool> SetTriggerErrorAsync(T t);

        #region 手臂專案流程狀態

        public Task<bool> GetProjectStatusAsync(T t);

        public Task<bool> GetProjectErrorCodeAsync(T t);

        #endregion

        #region 手臂底層錯誤

        public Task<bool> GetIsErrorAsync(T t);

        public Task<bool> GetErrorCodeAsync(T t);

        #endregion

        #region 儲位sensor

        public Task<bool> GetSensorSignalAsync(T t);

        public void GetDeployData(T t);

        #endregion

        #region RFID 到站動作

        public Task<bool> GetInRFIDScanPosAsync(T t);

        public Task<bool> SetRFIDScanMotionAsync(T t);

        #endregion

    }
}
