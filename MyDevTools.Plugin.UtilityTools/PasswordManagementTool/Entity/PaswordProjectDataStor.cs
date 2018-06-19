using MyDevTools.Plugin.UtilityTools.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDevTools.Plugin.UtilityTools.PasswordManagementTool.Entity
{

    /// <summary>
    /// 密码项目数据仓储
    /// </summary>
    public class PaswordProjectDataStor
    {

        /// <summary>
        /// 项目密码
        /// </summary>
        [JsonProperty]
        public String Password { get; private set; }

        /// <summary>
        /// 密码项
        /// </summary>
        public List<PasswordProject> PassworkProjects { get; set; }

        public PaswordProjectDataStor()
        {
            PassworkProjects = new List<PasswordProject>();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="password"></param>
        public void UpdatePassword(String password)
        {
            Password = MD5CryptoHelper.Encrypto(password);
        }

        /// <summary>
        /// 验证密码是否正确
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public Boolean VerificationPassword(String password)
        {
            if (String.IsNullOrEmpty(Password)) return false;
            return Password.Equals(MD5CryptoHelper.Encrypto(password));
        }

        public static String CreateSignKey(String password)
        {
            return MD5CryptoHelper.Encrypto(password);
        }
    }
}
