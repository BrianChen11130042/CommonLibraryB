using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibraryB.Library.AmrControl.Adapter;
using CommonLibraryB.Library.AmrControl.Config;
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

        public Dictionary<T, AmrControlPackage> Packages;

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

    public partial class AmrControlLibrary<T> : IAmrControlOperate<T>
    {
        AmrControlAdapter adapter;

        public void InitAdapter()
        {
            List<AmrControlConfig> cs = configManager.table.Values.ToList();
            adapter = new AmrControlAdapter(cs);
        }

        IAmrControlOperate<AmrControlPackage> SelectAdapter(T t)
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

        public async Task<bool> GetProgressByFlowId(T t)
        {
            return await SelectAdapter(t).GetProgressByFlowId(Packages[t]);
        }
    }
}
