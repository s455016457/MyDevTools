using MyDevTools.Plugin.UtilityTools.PasswordManagementTool.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDevTools.Plugin.UtilityTools.PasswordManagementTool.DataStor
{
    public interface IPasswordProjectStor
    {
        /// <summary>
        /// 保存所有变更
        /// </summary>
        /// <param name="PassworkProjects"></param>
        void SaveChanges(PaswordProjectDataStor PassworkProjects);
        /// <summary>
        /// 获取密码项目列表
        /// </summary>
        /// <returns></returns>
        PaswordProjectDataStor GetPaswordProjectDataStor(String password);
    }
}
