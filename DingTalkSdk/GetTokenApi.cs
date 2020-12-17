using DingTalk.Api;
using DingTalk.Api.Request;
using DingTalk.Api.Response;
using DingTalkSdk.Properties;

namespace DingTalkSdk
{
    /// <summary>
    /// 获取凭证API
    /// </summary>
    public static  class GetTokenApi
    {
        /// <summary>
        /// 获取企业凭证
        /// <para>
        /// 获取调用企业接口凭证。可通过 appkey、appsecret 或 corpid、corpsecret 换取access_token
        /// </para>
        /// </summary>
        /// <param name="appkey">应用凭证AppKey</param>
        /// <param name="appsecret">应用凭证APPSecret</param>
        /// <returns></returns>
        public static string GetToken(string appkey,string appsecret)
        {
            IDingTalkClient client = new DefaultDingTalkClient(Settings.Default.GetTokenServerUrl);
            OapiGettokenRequest req = new OapiGettokenRequest();
            req.Appkey = appkey;
            req.Appsecret = appsecret;
            req.SetHttpMethod("GET");
            OapiGettokenResponse rsp = client.Execute(req);
            return rsp.Body;
        }

        /// <summary>
        /// 获取jsapi_ticket
        /// </summary>
        /// <param name="accessToken">企业凭证</param>
        /// <returns></returns>
        public static string GetJSApiTicket(string accessToken)
        {
            IDingTalkClient client = new DefaultDingTalkClient(Settings.Default.GetJSApiTicketServerUrl);
            OapiGetJsapiTicketRequest req = new OapiGetJsapiTicketRequest();
            req.SetHttpMethod("GET");
            OapiGetJsapiTicketResponse rsp = client.Execute(req, accessToken);
            return rsp.Body;
        }

        /// <summary>
        /// 获取企业授权凭证
        /// <para>企业凭证，即企业授权给第三方企业应用时，第三方企业应用获取企业的凭证access_token。第三方企业应用可以使用access_token调用接口获取企业的相关信息。</para>
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public static string GetCorpToken(string access_token)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/service/get_corp_token");
            OapiServiceGetCorpTokenRequest req = new OapiServiceGetCorpTokenRequest();
            OapiServiceGetCorpTokenResponse rsp = client.Execute(req, access_token);
            return rsp.Body;
        }
        /// <summary>
        /// 获取第三方企业应用凭证
        /// </summary>
        /// <param name="suiteKey"></param>
        /// <param name="suiteSecret"></param>
        /// <param name="suiteTicket"></param>
        /// <returns></returns>
        public static string GetSuiteToken(string suiteKey,string suiteSecret,string suiteTicket)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/service/get_suite_token");
            OapiServiceGetSuiteTokenRequest req = new OapiServiceGetSuiteTokenRequest();
            req.SuiteKey = suiteKey;
            req.SuiteSecret = suiteSecret;
            req.SuiteTicket = suiteTicket;
            OapiServiceGetSuiteTokenResponse rsp = client.Execute(req);
           return rsp.Body;
        }
    }
}
