using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibraryB.Library.AmrControl.Adapter;
using CommonLibraryB.Library.AmrControl.Config;
using CommonLibraryB.Library.AmrControl.Package;
using CommonLibraryB.Library.AmrControl.Property;
using CommonLibraryB.Manager.WebApiClient;

namespace CommonLibraryB.Library.AmrControl
{
    public partial class AmrControlLibrary<T>
    {
        public WebApiClientManager apiClientManager;
        public AmrControlConfigManager<T> configManager;
        public AmrControlPropertyManager<T> propertyManager;

        public AmrControlLibrary(WebApiClientManager apiClientManager, AmrControlConfigManager<T> configManager,
                                 AmrControlPropertyManager<T> propertyManager)
        {
            this.apiClientManager = apiClientManager;
            this.configManager = configManager;
            this.propertyManager = propertyManager;
        }
    }

    public partial class AmrControlLibrary<T> : IAmrControlPackage<T>
    {
        Dictionary<T, AmrControlPackage> _packages { get; set; }

        public Dictionary<T, AmrControlPackage> Packages
        {
            get
            {
                return _packages;
            }
            set
            {
                _packages = value;
            }
        }

        public void InitPackage()
        {
            if (Packages == null)
            {
                Packages = new Dictionary<T, AmrControlPackage>();

                foreach (T dev in Enum.GetValues(typeof(T)))
                {
                    Packages.Add(dev, new AmrControlPackage());
                }
            }

            foreach (T dev in Enum.GetValues(typeof(T)))
            {
                Packages[dev].config = configManager.table[dev.ToString()];
                Packages[dev].property = propertyManager.table[dev.ToString()];

                string apiClient = configManager.table[dev.ToString()].client.ToString();
                Packages[dev].httpClient = apiClientManager.table[apiClient].httpClient;
            }
        }

    }

    public partial class AmrControlLibrary<T> : IAmrControlAdapter<T>
    {
        AmrControlAdapter adapter;

        public void InitAdapter()
        {
            List<AmrControlConfig> cs = configManager.table.Values.ToList();
            adapter = new AmrControlAdapter(cs);
        }

        IAmrControlAdapter<AmrControlPackage> SelectAdapter(T t)
        {
            string key = t.ToString();
            AmrControlConfig c = configManager.table[key];
            return adapter[c.supplier];
        }

        public async Task<bool> GetAccessToken(T t)
        {
            return await SelectAdapter(t).GetAccessToken(Packages[t]);
        }

        public async Task<bool> SetMoveFlow(T t)
        {
            return await SelectAdapter(t).SetMoveFlow(Packages[t]);
        }

        public async Task<bool> SetChargeFlow(T t)
        {
            return await SelectAdapter(t).SetChargeFlow(Packages[t]);
        }

        public async Task<bool> GetProgressByFlowId(T t)
        {
            return await SelectAdapter(t).GetProgressByFlowId(Packages[t]);
        }

        public async Task<bool> GetProgressByTaskId(T t)
        {
            return await SelectAdapter(t).GetProgressByTaskId(Packages[t]);
        }

        public async Task<bool> GetArtifactStatusByArtifactId(T t)
        {
            return await SelectAdapter(t).GetArtifactStatusByArtifactId(Packages[t]);
        }

        public async Task<bool> SetDeleteFlowByFlowId(T t)
        {
            return await SelectAdapter(t).SetDeleteFlowByFlowId(Packages[t]);
        }

        public async Task<bool> GetFlowName(T t)
        {
            return await SelectAdapter(t).GetFlowName(Packages[t]);
        }

        public async Task<bool> GetScanAmr(T t)
        {
            return await SelectAdapter(t).GetScanAmr(Packages[t]);
        }

        public async Task<bool> GetCellStatus(T t)
        {
            return await SelectAdapter(t).GetCellStatus(Packages[t]);
        }

        public async Task<bool> GetAmrStatusByAmrId(T t)
        {
            return await SelectAdapter(t).GetAmrStatusByAmrId(Packages[t]);
        }

        public async Task<bool> SetMoveArtifactFlow(T t)
        {
            return await SelectAdapter(t).SetMoveArtifactFlow(Packages[t]);
        }
    }
}
