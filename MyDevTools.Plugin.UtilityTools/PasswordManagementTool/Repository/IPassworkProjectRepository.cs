using MyDevTools.Plugin.UtilityTools.PasswordManagementTool.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDevTools.Plugin.UtilityTools.PasswordManagementTool.Repository
{
    /// <summary>
    /// 密码项目资源库
    /// </summary>
    public interface IPassworkProjectRepository
    {
        /// <summary>
        /// 获取所有密码项目
        /// </summary>
        /// <returns></returns>
        IReadOnlyList<PassworkProject> GetPassworkProjectList();

        /// <summary>
        /// 获取所有密码项目名称列表
        /// </summary>
        /// <returns></returns>
        List<String> GetPassworkProjectNameList();

        /// <summary>
        /// 获取密码项目
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        PassworkProject GetPassworkProject(String Name);

        /// <summary>
        /// 创建密码项目
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Account"></param>
        /// <returns></returns>
        PassworkProject CreatePassworkProject(String Name, String Account);

        /// <summary>
        /// 删除密码项目
        /// </summary>
        /// <param name="passworkProject"></param>
        void RemovePassworkProject(PassworkProject passworkProject);

        /// <summary>
        /// 保存更新
        /// </summary>
        void SaveChanges();
    }
}
