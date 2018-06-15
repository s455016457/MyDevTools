using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDevTools.Plugin.UtilityTools.PasswordManagementTool.Entity
{
    /// <summary>
    /// 密码项
    /// </summary>
    public class PasswordItem
    {
        /// <summary>
        /// 密码项名称
        /// </summary>
        [JsonProperty]
        public String Name { get; private set; }
        /// <summary>
        /// 密码
        /// </summary>
        [JsonProperty]
        public String Password { get; private set; }
        /// <summary>
        /// 备注
        /// </summary>
        [JsonProperty]
        public String Remark { get; private set; }

        private PasswordItem() { }

        public PasswordItem(String Name)
        {
            this.Name = Name;
        }        

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="Password"></param>
        public void UpdatePassword(String Password)
        {
            this.Password = Password;
        }
        /// <summary>
        /// 修改备注
        /// </summary>
        /// <param name="Remark"></param>
        public void UpdateRemark(String Remark)
        {
            this.Remark = Remark;
        }
    }
}
