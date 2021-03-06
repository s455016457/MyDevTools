using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api;

namespace DingTalk.Api.Response
{
    /// <summary>
    /// OapiEduCourseEndResponse.
    /// </summary>
    public class OapiEduCourseEndResponse : DingTalkResponse
    {
        /// <summary>
        /// dingOpenErrcode
        /// </summary>
        [XmlElement("errcode")]
        public long Errcode { get; set; }

        /// <summary>
        /// errorMsg
        /// </summary>
        [XmlElement("errmsg")]
        public string Errmsg { get; set; }

        /// <summary>
        /// 结束课程结果
        /// </summary>
        [XmlElement("result")]
        public bool Result { get; set; }

        /// <summary>
        /// success
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }

    }
}
