using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDevTools.Plugin.UtilityTools.PasswordManagementTool.Entity
{
    /// <summary>
    /// 扩展字段
    /// </summary>
    public class ExtensionField
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        [JsonProperty]
        public String Name { get; private set; }
        /// <summary>
        /// 值
        /// </summary>
        [JsonProperty]
        public String Value { get; private set; }

        private ExtensionField() { }

        public ExtensionField(String Name)
        {
            this.Name = Name;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="Password"></param>
        public void UpdateValue(String Value)
        {
            this.Value = Value;
        }
    }
}
