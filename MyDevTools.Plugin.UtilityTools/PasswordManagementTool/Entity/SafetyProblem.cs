using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDevTools.Plugin.UtilityTools.PasswordManagementTool.Entity
{
    /// <summary>
    /// 安全问题
    /// </summary>
    public class SafetyProblem
    {
        /// <summary>
        /// 问题
        /// </summary>
        [JsonProperty]
        public String Problem { get; private set; }

        /// <summary>
        /// 答案
        /// </summary>
        [JsonProperty]
        public String Solution { get; private set; }

        private SafetyProblem() { }

        public SafetyProblem(String Problem)
        {
            this.Problem = Problem;
        }

        public SafetyProblem(String Problem, String Solution)
        {
            this.Problem = Problem;
            this.Solution = Solution;
        }

        /// <summary>
        /// 修改答案
        /// </summary>
        /// <param name="Solution"></param>
        public void UpdateSolution(String Solution)
        {
            this.Solution = Solution;
        }
    }
}
