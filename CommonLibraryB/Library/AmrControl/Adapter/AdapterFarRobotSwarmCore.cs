using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CommonLibraryB.Library.AmrControl.Package;
using CommonLibraryB.Library.AmrControl.Property.JsonModel.FarRobotSwarmCoreJson;

namespace CommonLibraryB.Library.AmrControl.Adapter
{
    public partial class AdapterFarRobotSwarmCore
    {
        enum EGetOperate
        {
            AccessToken,
            ProgressByFlowId,
            ProgressByTaskId
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
    }

    public partial class AdapterFarRobotSwarmCore
    {
        enum ESetOperate
        {
            MoveFlow,
            ChargeFlow
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
            }
        }

        void cmdMoveFlow(AmrControlPackage t)
        {
            t.property.farRobot.moveFlow.flowName = "move_api_test";
            t.path = $"/v2/flows/{t.property.farRobot.moveFlow.flowName}";

            string cellName = t.property.farRobot.moveFlow.post.args.Params.Node4.goal_tynXx;
            t.property.farRobot.moveFlow.post.args.Params.Node4.goal_tynXx = $"dennis test1@default_area@{cellName}";
        }

        void cmdChargeFlow(AmrControlPackage t)
        {
            t.property.farRobot.chargeFlow.flowName = "charge_api_test";
            t.path = $"/v2/flows/{t.property.farRobot.chargeFlow.flowName}";

            string cellName = t.property.farRobot.chargeFlow.post.args.Params.Node4.goal_nUvaT;
            t.property.farRobot.chargeFlow.post.args.Params.Node4.goal_nUvaT = $"dennis test1@default_area@{cellName}";
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
    }

    public partial class AdapterFarRobotSwarmCore
    {
        void setWebApiClientError()
        {
            throw new InvalidOperationException("Web Api Client Disconnect");
        }
    }
}
