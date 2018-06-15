using System;
using System.Collections.Generic;
using System.Linq;
using MyDevTools.Plugin.UtilityTools.PasswordManagementTool.DataStor;
using MyDevTools.Plugin.UtilityTools.PasswordManagementTool.Entity;

namespace MyDevTools.Plugin.UtilityTools.PasswordManagementTool.Repository.Impl
{
    public class PassworkProjectRepository : IPassworkProjectRepository
    {
        private List<PassworkProject> PassworkProjects;
        private IPasswordProjectStor PasswordProjectStor;

        public PassworkProjectRepository(IPasswordProjectStor passwordProjectStor)
        {
            PasswordProjectStor = passwordProjectStor;
            PassworkProjects = PasswordProjectStor.GetPassworkProjects();
            if (PassworkProjects == null) PassworkProjects = new List<PassworkProject>();
        }

        public PassworkProject CreatePassworkProject(string Name, string Account)
        {
            PassworkProject passworkProject = new PassworkProject(Name, Account);
            if (PassworkProjects.FirstOrDefault(p => p.Name.Equals(Name,StringComparison.CurrentCultureIgnoreCase)) != null)
            {
                throw new Exception(String.Format("不能添加重复的项目【{0}】！", Name));
            }
            PassworkProjects.Add(passworkProject);
            return passworkProject;
        }

        public PassworkProject GetPassworkProject(string Name)
        {
            return PassworkProjects.FirstOrDefault(p => p.Name.Equals(Name, StringComparison.CurrentCultureIgnoreCase));
        }

        public IReadOnlyList<PassworkProject> GetPassworkProjectList()
        {
            return PassworkProjects.AsReadOnly();
        }

        public List<string> GetPassworkProjectNameList()
        {
            return PassworkProjects.OrderBy(p=>p.Name).Select(p => p.Name).ToList();
        }

        public void RemovePassworkProject(PassworkProject passworkProject)
        {
            PassworkProjects.Remove(GetPassworkProject(passworkProject.Name));
        }

        public void SaveChanges()
        {
            PasswordProjectStor.SaveChanges(PassworkProjects);
        }
    }
}
