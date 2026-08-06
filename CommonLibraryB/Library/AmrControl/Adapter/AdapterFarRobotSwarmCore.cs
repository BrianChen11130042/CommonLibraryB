using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CommonLibraryB.Library.AmrControl.Property.JsonModel.FarRobotSwarmCoreJson;

namespace CommonLibraryB.Library.AmrControl.Adapter
{
    public partial class AdapterFarRobotSwarmCore
    {
        enum EGetOperate
        {
            AccessToken
        }

        void getCmd(EGetOperate operate, AmrControlPackage t)
        {
            switch(operate)
            {
                case EGetOperate.AccessToken:
                    cmdAccessToken(t);
                    break;
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
        }
    }

    public partial class AdapterFarRobotSwarmCore
    {
        enum ESetOperate
        {
            MoveFlow
        }

        void getCmd(ESetOperate operate, AmrControlPackage t)
        {
            switch(operate)
            {
                case ESetOperate.MoveFlow:
                    cmdMoveFlow(t);
                    break;
            }
        }

        void cmdMoveFlow(AmrControlPackage t)
        {
            t.property.farRobot.flowName = "move_api_test";

            t.path = $"/v2/flows/{t.property.farRobot.flowName}";

            t.property.farRobot.moveFlow.post.args.priority = "3";

            t.property.farRobot.moveFlow.post.args.Params.Node4.assigned_robot = "smr_9901010401002t73j251";
            t.property.farRobot.moveFlow.post.args.Params.Node4.goal_tynXx = "dennis test1@default_area@destination";

            t.property.farRobot.moveFlow.post.args.Params.Node5.assigned_robot = "smr_9901010401002t73j251";
            t.property.farRobot.moveFlow.post.args.Params.Node5.goal_tynXx = "dennis test1@default_area@departure";
        }
    }

    public partial class AdapterFarRobotSwarmCore : IAmrControlOperate<AmrControlPackage>
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
    }

    public partial class AdapterFarRobotSwarmCore
    {
        void setWebApiClientError()
        {
            throw new InvalidOperationException("Web Api Client Disconnect");
        }
    }
}
