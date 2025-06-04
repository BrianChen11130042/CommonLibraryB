using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibraryB.Base.Adapter;
using CommonLibraryB.Library.Robot.Config;

namespace CommonLibraryB.Library.Robot.Adapter
{
    public enum ERobotSupplier { TMRobot_MpFoup4, TMRobot_IcTray6 }

    public class RobotAdapter : AdapterBase<RobotConfig, ERobotSupplier, IRobotOperate<RobotPackage>>
    {
        public RobotAdapter(List<RobotConfig> keys):base(keys)
        {

        }

        protected override void InitAdapter(List<RobotConfig> keys)
        {
            foreach(var v in keys)
            {
                ERobotSupplier supplier = v.supplier;

                if (table.ContainsKey(supplier))
                    continue;

                switch(supplier)
                {
                    case ERobotSupplier.TMRobot_MpFoup4:
                        table.Add(supplier, new AdapterRobotMpFoup());
                        break;

                    case ERobotSupplier.TMRobot_IcTray6:
                        table.Add(supplier, new AdapterRobotIcTray());
                        break;
                }
            }
        }
    }
}
