using CommonLibraryB.Base.Adapter;
using CommonLibraryB.Library.Amr.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.Amr.Adapter
{
    public enum EAmrSupplier { HikRobot_MpFoup4, HikRobot_IcTray6 }

    public class AmrAdapter : AdapterBase<AmrConfig, EAmrSupplier, IAmrOperate<AmrPackage>>
    {
        public AmrAdapter(List<AmrConfig> keys) : base(keys)
        {

        }

        protected override void InitAdapter(List<AmrConfig> keys)
        {
            foreach(var v in keys)
            {
                EAmrSupplier supplier = v.supplier;

                if (table.ContainsKey(supplier))
                    continue;

                switch(supplier)
                {
                    case EAmrSupplier.HikRobot_MpFoup4:
                        table.Add(supplier, new AdapterHikRobotMpFoup());
                        break;

                    case EAmrSupplier.HikRobot_IcTray6:
                        table.Add(supplier, new AdapterHikRobotIcTray());
                        break;
                }
            }
        }
    }
}
