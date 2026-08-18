using CommonLibraryB.Library.AmrControl.Package;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.AmrControl.Adapter
{
    public partial class AdapterAmrControlStub : IAmrControlAdapter<AmrControlPackage>
    {
        public async Task<bool> GetAccessToken(AmrControlPackage t)
        {
            try
            {
                await t.gate.WaitAsync();
                return true;
            }
            finally
            {
                t.gate.Release();
            }
        }

        public async Task<bool> SetMoveFlow(AmrControlPackage t)
        {
            try
            {
                await t.gate.WaitAsync();
                return true;
            }
            finally
            {
                t.gate.Release();
            }
        }

        public async Task<bool> SetChargeFlow(AmrControlPackage t)
        {
            try
            {
                await t.gate.WaitAsync();
                return true;
            }
            finally
            {
                t.gate.Release();
            }
        }

        public async Task<bool> GetProgressByFlowId(AmrControlPackage t)
        {
            try
            {
                await t.gate.WaitAsync();
                return true;
            }
            finally
            {
                t.gate.Release();
            }
        }

        public async Task<bool> GetProgressByTaskId(AmrControlPackage t)
        {
            try
            {
                await t.gate.WaitAsync();
                return true;
            }
            finally
            {
                t.gate.Release();
            }
        }
    }
}
