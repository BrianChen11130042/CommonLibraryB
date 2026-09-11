using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CommonLibraryB.Library.AmrControl.Package;
using CommonLibraryB.Library.AmrControl.Property.JsonModel.FarRobotSwarmCoreJson;
using Microsoft.AspNetCore.WebUtilities;

namespace CommonLibraryB.Library.AmrControl.Adapter
{
    public partial class AdapterFarRobotSwarmCore
    {
        enum EGetOperate
        {
            AccessToken,
            ProgressByFlowId,
            ProgressByTaskId,
            ArtifactStatusByArtifactId,
            FlowName,
            ScanAmr,
            CellStatus,
            AmrStatusByAmrId
        }

        void getCmd(EGetOperate operate, AmrControlPackage t)
        {
            switch(operate)
            {
                case EGetOperate.AccessToken:
                    cmdAccessToken(t);
                    break;

                case EGetOperate.ProgressByFlowId:
                    cmdProgressByFlowId(t);
                    break;

                case EGetOperate.ProgressByTaskId:
                    cmdProgressByTaskId(t);
                    break;

                case EGetOperate.ArtifactStatusByArtifactId:
                    cmdArtifactStatusByArtifactId(t);
                    break;

                case EGetOperate.FlowName:
                    cmdFlowName(t);
                    break;

                case EGetOperate.ScanAmr:
                    cmdScanAmr(t);
                    break;

                case EGetOperate.CellStatus:
                    cmdCellStatus(t);
                    break;

                case EGetOperate.AmrStatusByAmrId:
                    cmdAmrStatusByAmrId(t);
                    break;
            }
        }

        void cmdAccessToken(AmrControlPackage t)
        {
            Dictionary<string, string> auth = new Dictionary<string, string>()
            {
                ["username"] = "admin",
                ["password"] = "admin",
            };

            t.property.farRobot.accessToken.post = auth;

            t.path = "/login/access-token";
        }

        void cmdProgressByFlowId(AmrControlPackage t)
        {
            t.path = $"/v1/flows/progress/{t.property.farRobot.flowProgress.flowId}";
        }

        void cmdProgressByTaskId(AmrControlPackage t)
        {
            t.path = $"/v1/tasks/progress/{t.property.farRobot.taskProgress.taskId}";
        }

        void cmdArtifactStatusByArtifactId(AmrControlPackage t)
        {
            t.path = $"/v2/artifacts/status/{t.property.farRobot.artifactStatusByArtifactId.artifactId}";
        }

        void cmdFlowName(AmrControlPackage t)
        {
            t.path = QueryHelpers.AddQueryString("/v2/flows", "fleet_name", t.property.farRobot.flowName.fleetName);
        }

        void cmdScanAmr(AmrControlPackage t)
        {
            Dictionary<string, string> dcQuery = new Dictionary<string, string>();

            if(!string.IsNullOrEmpty(t.property.farRobot.scanAmr.mode))
            {
                dcQuery.Add("mode", t.property.farRobot.scanAmr.mode);
            }
            
            if(!string.IsNullOrEmpty(t.property.farRobot.scanAmr.model))
            {
                dcQuery.Add("model", t.property.farRobot.scanAmr.model);
            }

            t.path = QueryHelpers.AddQueryString("/v2/robots/scan", dcQuery);
        }

        void cmdCellStatus(AmrControlPackage t)
        {
            t.path = QueryHelpers.AddQueryString("/v2/wms", "map_name", t.property.farRobot.cellStatus.map_name);
        }

        void cmdAmrStatusByAmrId(AmrControlPackage t)
        {
            string robotId = t.property.farRobot.amrStatusByAmrId.robotId;

            t.path = $"/v2/robots/status/{Uri.EscapeDataString(robotId)}";

            t.path = QueryHelpers.AddQueryString(
                t.path,
                "include_artifact",
                t.property.farRobot.amrStatusByAmrId.includeArtifact ? "true" : "false");
        }
    }

    public partial class AdapterFarRobotSwarmCore
    {
        enum ESetOperate
        {
            MoveFlow,
            ChargeFlow,
            MoveArtifactFlow,
            DeleteFlow
        }

        void getCmd(ESetOperate operate, AmrControlPackage t)
        {
            switch(operate)
            {
                case ESetOperate.MoveFlow:
                    cmdMoveFlow(t);
                    break;

                case ESetOperate.ChargeFlow:
                    cmdChargeFlow(t);
                    break;

                case ESetOperate.MoveArtifactFlow:
                    cmdMoveArtifactFlow(t);
                    break;

                case ESetOperate.DeleteFlow:
                    cmdDeleteFlow(t);
                    break;
            }
        }

        void cmdMoveFlow(AmrControlPackage t)
        {
            t.property.farRobot.moveFlow.flowName = "move_api_test";
            t.path = $"/v2/flows/{t.property.farRobot.moveFlow.flowName}";
        }

        void cmdChargeFlow(AmrControlPackage t)
        {
            t.property.farRobot.chargeFlow.flowName = "charge_api_test";
            t.path = $"/v2/flows/{t.property.farRobot.chargeFlow.flowName}";
        }

        void cmdMoveArtifactFlow(AmrControlPackage t)
        {
            t.property.farRobot.moveArtifactFlow.flowName = "move_artifact_api_test";
            t.path = $"/v2/flows/{t.property.farRobot.moveArtifactFlow.flowName}";
        }

        void cmdDeleteFlow(AmrControlPackage t)
        {
            t.path = $"/v2/flows/{t.property.farRobot.deleteFlow.flowId}";
        }
    }

    public partial class AdapterFarRobotSwarmCore : IAmrControlAdapter<AmrControlPackage>
    {
        public async Task<bool> GetAccessToken(AmrControlPackage t)
        {
            await t.gate.WaitAsync();

            try
            {
                if(t.httpClient == null)
                {
                    setWebApiClientError();
                }

                getCmd(EGetOperate.AccessToken, t);

                TokenResponse response = await t.PostFormAsync<TokenResponse>(t.property.farRobot.accessToken.post);

                t.property.farRobot.accessToken.response = response;

                t.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(response.token_type, response.access_token);

                return true;

            }
            catch(Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
            finally
            {
                t.gate.Release();
            }
        }

        public async Task<bool> SetMoveFlow(AmrControlPackage t)
        {
            await t.gate.WaitAsync();

            try
            {
                if (t.httpClient == null)
                {
                    setWebApiClientError();
                }

                getCmd(ESetOperate.MoveFlow, t);

                MoveFlowTriggerResponse response = await t.PostAsync<MoveFlowTriggerRequest, 
                                                                     MoveFlowTriggerResponse>(t.property.farRobot.moveFlow.post);

                t.property.farRobot.moveFlow.response = response;

                return true;

            }
            catch(Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
            finally
            {
                t.gate.Release();
            }
        }

        public async Task<bool> SetChargeFlow(AmrControlPackage t)
        {
            await t.gate.WaitAsync();

            try
            {
                if (t.httpClient == null)
                {
                    setWebApiClientError();
                }

                getCmd(ESetOperate.ChargeFlow, t);

                ChargeFlowTriggerResponse response = await t.PostAsync<ChargeFlowTriggerRequest, 
                                                                       ChargeFlowTriggerResponse>(t.property.farRobot.chargeFlow.post);

                t.property.farRobot.chargeFlow.response = response;

                return true;
            }
            catch(Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
            finally
            {
                t.gate.Release();
            }
        }

        public async Task<bool> SetMoveArtifactFlow(AmrControlPackage t)
        {
            await t.gate.WaitAsync();

            try
            {
                if (t.httpClient == null)
                {
                    setWebApiClientError();
                }

                getCmd(ESetOperate.MoveArtifactFlow, t);

                MoveArtifactFlowTriggerResponse response = await t.PostAsync<MoveArtifactFlowTriggerRequest,
                                                                             MoveArtifactFlowTriggerResponse>(t.property.farRobot
                                                                                                               .moveArtifactFlow.post);

                t.property.farRobot.moveArtifactFlow.response = response;

                return true;
            }
            catch(Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
            finally
            {
                t.gate.Release();
            }
        }

        public async Task<bool> GetProgressByFlowId(AmrControlPackage t)
        {
            await t.gate.WaitAsync();

            try
            {
                if (t.httpClient == null)
                {
                    setWebApiClientError();
                }

                getCmd(EGetOperate.ProgressByFlowId, t);

                FlowProgressResponse response = await t.GetAsync<FlowProgressResponse>();

                t.property.farRobot.flowProgress.response = response;

                return true;

            }
            catch(Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
            finally
            {
                t.gate.Release();
            }
        }

        public async Task<bool> GetProgressByTaskId(AmrControlPackage t)
        {
            await t.gate.WaitAsync();

            try
            {
                if (t.httpClient == null)
                {
                    setWebApiClientError();
                }

                getCmd(EGetOperate.ProgressByTaskId, t);

                TaskProgressResponse response = await t.GetAsync<TaskProgressResponse>();

                t.property.farRobot.taskProgress.response = response;

                return true;

            }
            catch(Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
            finally
            {
                t.gate.Release();
            }
        }

        public async Task<bool> GetArtifactStatusByArtifactId(AmrControlPackage t)
        {
            await t.gate.WaitAsync();

            try
            {
                if (t.httpClient == null)
                {
                    setWebApiClientError();
                }

                getCmd(EGetOperate.ArtifactStatusByArtifactId, t);

                ArtifactStatusResponse response = await t.GetAsync<ArtifactStatusResponse>();

                t.property.farRobot.artifactStatusByArtifactId.response = response;

                return true;
            }
            catch(Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
            finally
            {
                t.gate.Release();
            }
        }

        public async Task<bool> SetDeleteFlowByFlowId(AmrControlPackage t)
        {
            await t.gate.WaitAsync();

            try
            {
                if (t.httpClient == null)
                {
                    setWebApiClientError();
                }

                getCmd(ESetOperate.DeleteFlow, t);

                DeleteFlowResponse response = await t.DeleteAsync<DeleteFlowResponse>();

                t.property.farRobot.deleteFlow.response = response;

                return true;
            }
            catch(Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
            finally
            {
                t.gate.Release();
            }
        }

        public async Task<bool> GetFlowName(AmrControlPackage t)
        {
            await t.gate.WaitAsync();

            try
            {
                if (t.httpClient == null)
                {
                    setWebApiClientError();
                }

                getCmd(EGetOperate.FlowName, t);

                FlowNameResponse response = await t.GetAsync<FlowNameResponse>();

                t.property.farRobot.flowName.response = response;

                return true;
            }
            catch(Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
            finally
            {
                t.gate.Release();
            }
        }

        public async Task<bool> GetScanAmr(AmrControlPackage t)
        {
            await t.gate.WaitAsync();

            try
            {
                if (t.httpClient == null)
                {
                    setWebApiClientError();
                }

                getCmd(EGetOperate.ScanAmr, t);

                ScanAmrResponse response = await t.GetAsync<ScanAmrResponse>();

                t.property.farRobot.scanAmr.response = response;

                return true;
            }
            catch(Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
            finally
            {
                t.gate.Release();
            }
        }

        public async Task<bool> GetCellStatus(AmrControlPackage t)
        {
            await t.gate.WaitAsync();

            try
            {
                if (t.httpClient == null)
                {
                    setWebApiClientError();
                }

                getCmd(EGetOperate.CellStatus, t);

                CellStatusResponse response = await t.GetAsync<CellStatusResponse>();

                t.property.farRobot.cellStatus.response = response;

                return true;
            }
            catch(Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
            finally
            {
                t.gate.Release();
            }
        }

        public async Task<bool> GetAmrStatusByAmrId(AmrControlPackage t)
        {
            await t.gate.WaitAsync();

            try
            {
                if (t.httpClient == null)
                {
                    setWebApiClientError();
                }

                getCmd(EGetOperate.AmrStatusByAmrId, t);

                AmrStatusResponse response = await t.GetAsync<AmrStatusResponse>();

                t.property.farRobot.amrStatusByAmrId.response = response;

                return true;
            }
            catch(Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
            finally
            {
                t.gate.Release();
            }
        }
    }

    public partial class AdapterFarRobotSwarmCore
    {
        void setWebApiClientError()
        {
            throw new InvalidOperationException("Web Api Client Disconnect");
        }
    }
}
