using System;
using System.Collections.Generic;
using System.Linq;
using MyDevTools.Plugin.UtilityTools.PasswordManagementTool.DataStor;
using MyDevTools.Plugin.UtilityTools.PasswordManagementTool.Entity;

namespace MyDevTools.Plugin.UtilityTools.PasswordManagementTool.Repository.Impl
{
    public class PasswordProjectRepository : IPassworkProjectRepository
    {
        private List<PasswordProject> PassworkProjects;
        private IPasswordProjectStor PasswordProjectStor;
        private PaswordProjectDataStor PaswordProjectData;

        public PasswordProjectRepository(IPasswordProjectStor passwordProjectStor, String password)
        {
            PasswordProjectStor = passwordProjectStor;
            PaswordProjectData = PasswordProjectStor.GetPaswordProjectDataStor(password);
            if (PaswordProjectData == null) PaswordProjectData = new PaswordProjectDataStor();
            PassworkProjects = PaswordProjectData.PassworkProjects;
            if (PassworkProjects == null)
                PaswordProjectData.PassworkProjects = PassworkProjects = new List<PasswordProject>();
        }

        public PasswordProject CreatePassworkProject(string Name, string Account)
        {
            PasswordProject passworkProject = new PasswordProject(Name, Account);
            if (PassworkProjects.FirstOrDefault(p => p.Name.Equals(Name,StringComparison.CurrentCultureIgnoreCase)) != null)
            {
                throw new Exception(String.Format("不能添加重复的项目【{0}】！", Name));
            }
            PassworkProjects.Add(passworkProject);
            return passworkProject;
        }

        public PasswordProject GetPassworkProject(string Name)
        {
            return PassworkProjects.FirstOrDefault(p => p.Name.Equals(Name, StringComparison.CurrentCultureIgnoreCase));
        }

        public IReadOnlyList<PasswordProject> GetPassworkProjectList()
        {
            return PassworkProjects.AsReadOnly();
        }

        public List<string> GetPassworkProjectNameList()
        {
            return PassworkProjects.OrderBy(p=>p.Name).Select(p => p.Name).ToList();
        }

        public void RemovePassworkProject(PasswordProject passworkProject)
        {
            PassworkProjects.Remove(GetPassworkProject(passworkProject.Name));
        }

        public String GetPassword()
        {
            return PaswordProjectData.Password;
        }

        public Boolean VerificationPassword(String password)
        {
            return PaswordProjectData.VerificationPassword(password);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="password"></param>
        public void UpdatePassword(String password)
        {
            PaswordProjectData.UpdatePassword(password);
        }        

        public void SaveChanges()
        {
            PasswordProjectStor.SaveChanges(PaswordProjectData);
        }
    }
}
