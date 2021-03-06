using System;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.im.chat.scenegroup.update
    /// </summary>
    public class OapiImChatScenegroupUpdateRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiImChatScenegroupUpdateResponse>
    {
        /// <summary>
        /// 群禁言，0-默认，不禁言，1-全员禁言
        /// </summary>
        public Nullable<long> ChatBannedType { get; set; }

        /// <summary>
        /// 群头像mediaId
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 管理类型，0-默认，所有人可管理，1-仅群主可管理
        /// </summary>
        public Nullable<long> ManagementType { get; set; }

        /// <summary>
        /// @all 权限，0-默认，所有人，1-仅群主可@all
        /// </summary>
        public Nullable<long> MentionAllAuthority { get; set; }

        /// <summary>
        /// 群id
        /// </summary>
        public string OpenConversationId { get; set; }

        /// <summary>
        /// 群主userid
        /// </summary>
        public string OwnerUserId { get; set; }

        /// <summary>
        /// 群可搜索，0-默认，不可搜索，1-可搜索
        /// </summary>
        public Nullable<long> Searchable { get; set; }

        /// <summary>
        /// 新成员是否可查看聊天历史消息，0-默认，否，1-是
        /// </summary>
        public Nullable<long> ShowHistoryType { get; set; }

        /// <summary>
        /// 群名称
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 入群验证，0：不入群验证（默认） 1：入群验证
        /// </summary>
        public Nullable<long> ValidationType { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.im.chat.scenegroup.update";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("chat_banned_type", this.ChatBannedType);
            parameters.Add("icon", this.Icon);
            parameters.Add("management_type", this.ManagementType);
            parameters.Add("mention_all_authority", this.MentionAllAuthority);
            parameters.Add("open_conversation_id", this.OpenConversationId);
            parameters.Add("owner_user_id", this.OwnerUserId);
            parameters.Add("searchable", this.Searchable);
            parameters.Add("show_history_type", this.ShowHistoryType);
            parameters.Add("title", this.Title);
            parameters.Add("validation_type", this.ValidationType);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("open_conversation_id", this.OpenConversationId);
        }

        #endregion
    }
}
