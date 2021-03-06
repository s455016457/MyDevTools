using System;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.chat.chatid.transformqrcode.get
    /// </summary>
    public class OapiChatChatidTransformqrcodeGetRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiChatChatidTransformqrcodeGetResponse>
    {
        /// <summary>
        /// 群二维码的url
        /// </summary>
        public string GroupUrl { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.chat.chatid.transformqrcode.get";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("group_url", this.GroupUrl);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("group_url", this.GroupUrl);
        }

        #endregion
    }
}
