using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibraryB.Base.Adapter;
using CommonLibraryB.Library.AmrControl.Config;
using CommonLibraryB.Library.AmrControl.Package;

namespace CommonLibraryB.Library.AmrControl.Adapter
{
    public enum EAmrControlSupplier { FarRobotSwarmCore }

    public class AmrControlAdapter : AdapterBase<AmrControlConfig, EAmrControlSupplier, IAmrControlAdapter<AmrControlPackage>>
    {
        public AmrControlAdapter(List<AmrControlConfig> keys) : base(keys)
        {

        }

        protected override void InitAdapter(List<AmrControlConfig> keys)
        {
            foreach(var v in keys)
            {
                EAmrControlSupplier supplier = v.supplier;

                if (table.ContainsKey(supplier))
                    continue;

                switch(supplier)
                {
                    case EAmrControlSupplier.FarRobotSwarmCore:
                        table.Add(supplier, new AdapterFarRobotSwarmCore());
                        break;
                }
            }
        }
    }
}
