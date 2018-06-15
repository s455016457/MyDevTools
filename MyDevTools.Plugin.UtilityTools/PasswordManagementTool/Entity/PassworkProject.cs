using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDevTools.Plugin.UtilityTools.PasswordManagementTool.Entity
{
    /// <summary>
    /// 密码项目
    /// </summary>
    public class PassworkProject
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        [JsonProperty]
        public String Name { get; private set; }
        /// <summary>
        /// 项目地址
        /// </summary>
        public String Address { get; set; }
        /// <summary>
        /// 项目账号
        /// </summary>
        public String Account { get; set; }
        /// <summary>
        /// 电子邮件
        /// </summary>
        public String Email { get; set; }
        /// <summary>
        /// 移动电话
        /// </summary>
        public String MobilPhone { get; set; }
        /// <summary>
        /// 扩展字段
        /// </summary>
        [JsonProperty]
        public IReadOnlyCollection<ExtensionField> ExtensionFields
        {
            get
            {
                return _extensionFields == null ? null : _extensionFields.AsReadOnly();
            }
            //用于反序列化
            private set
            {
                if (value == null) return;
                if (_extensionFields == null) _extensionFields = new List<ExtensionField>();
                foreach (var item in value)
                {
                    _extensionFields.Add(item);
                }
            }
        }
        /// <summary>
        /// 安全问题
        /// </summary>
        [JsonProperty]
        public IReadOnlyCollection<SafetyProblem> SafetyProblems
        {
            get
            {
                return _safetyProblems == null ? null : _safetyProblems.AsReadOnly();
            }
            //用于反序列化
            private set
            {
                if (value == null) return;
                if (_safetyProblems == null) _safetyProblems = new List<SafetyProblem>();
                foreach (var item in value)
                {
                    _safetyProblems.Add(item);
                }
            }
        }
        /// <summary>
        /// 密码项
        /// </summary>
        [JsonProperty]
        public IReadOnlyCollection<PasswordItem> PasswordItems
        {
            get
            {
                return _passwordItems == null ? null : _passwordItems.AsReadOnly();
            }
            //用于反序列化
            private set
            {
                if (value == null) return;
                if (_passwordItems == null) _passwordItems = new List<PasswordItem>();
                foreach (var item in value)
                {
                    _passwordItems.Add(item);
                }
            }
        }
        
        /// <summary>
        /// 扩展字段
        /// </summary>
        private List<ExtensionField> _extensionFields { get; set; }
        /// <summary>
        /// 安全问题
        /// </summary>
        private List<SafetyProblem> _safetyProblems { get; set; }
        /// <summary>
        /// 密码项
        /// </summary>
        private List<PasswordItem> _passwordItems { get; set; }

        private PassworkProject() { }
        public PassworkProject(String Name, String Account)
        {
            this.Name = Name;
            this.Account = Account;
        }

        /// <summary>
        /// 添加扩展字段
        /// </summary>
        /// <param name="Name"></param>
        public void AddExtensionField(String Name)
        {
            if (_extensionFields == null) _extensionFields = new List<ExtensionField>();

            if (_extensionFields.FirstOrDefault(p=>p.Name.Equals(Name, StringComparison.CurrentCultureIgnoreCase))!=null)
                throw new Exception(String.Format("不能添加重复的扩展字段【{0}】！", Name));

            _extensionFields.Add(new ExtensionField(Name));
        }

        /// <summary>
        /// 修改扩展字段的值
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Value"></param>
        public void UpdateExtensionField(String Name, String Value)
        {
            if (_extensionFields == null)
                throw new Exception(String.Format("扩展字段【{0}】不存在！", Name));
            if (_extensionFields.FirstOrDefault(p => p.Name.Equals(Name, StringComparison.CurrentCultureIgnoreCase)) == null)
                throw new Exception(String.Format("扩展字段【{0}】不存在！", Name));

            _extensionFields.FirstOrDefault(p => p.Name.Equals(Name, StringComparison.CurrentCultureIgnoreCase)).UpdateValue(Value);
        }
        /// <summary>
        /// 修改扩展字段的值
        /// </summary>
        /// <param name="ExtensionFields"></param>
        public void UpdateExtensionFields(ICollection<ExtensionField> ExtensionFields)
        {
            if (_extensionFields == null)
                _extensionFields = new List<ExtensionField>();

            foreach (var field in ExtensionFields)
            {
                UpdateExtensionField(field.Name, field.Value);
            }
        }

        public void RemoveExtensionFields(String Name) {
            if (_extensionFields == null)
                throw new Exception(String.Format("扩展字段【{0}】不存在！", Name));
            if (_extensionFields.FirstOrDefault(p => p.Name.Equals(Name, StringComparison.CurrentCultureIgnoreCase)) == null)
                throw new Exception(String.Format("扩展字段【{0}】不存在！", Name));

            _extensionFields.Remove(_extensionFields.FirstOrDefault(p => p.Name.Equals(Name, StringComparison.CurrentCultureIgnoreCase)));
        }

        /// <summary>
        /// 添加安全问题
        /// </summary>
        /// <param name="Problem"></param>
        public void AddSafetyProblem(String Problem)
        {
            if (_safetyProblems == null) _safetyProblems = new List<SafetyProblem>();

            if (_safetyProblems.FirstOrDefault(p => p.Problem.Equals(Problem, StringComparison.CurrentCultureIgnoreCase)) != null)
                throw new Exception(String.Format("不能添加重复问题【{0}】！", Problem));

            _safetyProblems.Add(new SafetyProblem(Problem));
        }
        /// <summary>
        /// 修改安全问题答案
        /// </summary>
        /// <param name="Problem"></param>
        /// <param name="Solution"></param>
        public void UpdateSafetyProblem(String Problem, String Solution)
        {
            if (_safetyProblems == null)
                throw new Exception(String.Format("安全问题【{0}】不存在！", Problem));
            if (_safetyProblems.FirstOrDefault(p => p.Problem.Equals(Problem, StringComparison.CurrentCultureIgnoreCase)) == null)
                throw new Exception(String.Format("安全问题【{0}】不存在！", Problem));

            _safetyProblems.FirstOrDefault(p => p.Problem.Equals(Problem, StringComparison.CurrentCultureIgnoreCase))
                .UpdateSolution(Solution);
        }

        public void RemoveSafetyProblem(String Problem)
        {
            if (_safetyProblems == null)
                throw new Exception(String.Format("安全问题【{0}】不存在！", Problem));
            if (_safetyProblems.FirstOrDefault(p => p.Problem.Equals(Problem, StringComparison.CurrentCultureIgnoreCase)) == null)
                throw new Exception(String.Format("安全问题【{0}】不存在！", Problem));

            _safetyProblems.Remove(_safetyProblems.FirstOrDefault(p => p.Problem.Equals(Problem, StringComparison.CurrentCultureIgnoreCase)));

        }

        /// <summary>
        /// 修改安全问题答案
        /// </summary>
        /// <param name="SafetyProblems"></param>
        public void UpdateSafetyProblems(ICollection<SafetyProblem> SafetyProblems)
        {
            if (_safetyProblems == null)
                _safetyProblems = new List<SafetyProblem>();

            foreach (var problem in SafetyProblems)
            {
                UpdateSafetyProblem(problem.Problem, problem.Solution);
            }
        }

        /// <summary>
        /// 添加密码项
        /// </summary>
        /// <param name="Name"></param>
        public void AddPasswordItem(String Name)
        {
            if (_passwordItems == null) _passwordItems = new List<PasswordItem>();

            if (_passwordItems.FirstOrDefault(p => p.Name.Equals(Name, StringComparison.CurrentCultureIgnoreCase)) != null)
                throw new Exception(String.Format("不能添加重复的密码项【{0}】！", Name));

            _passwordItems.Add(new PasswordItem(Name));
        }

        public void UpdatePassword(String Name, String Value)
        {
            if (_passwordItems == null)
                throw new Exception(String.Format("密码项【{0}】不存在！", Name));
            if (_passwordItems.FirstOrDefault(p => p.Name.Equals(Name, StringComparison.CurrentCultureIgnoreCase)) == null)
                throw new Exception(String.Format("密码项【{0}】不存在！", Name));

            _passwordItems.FirstOrDefault(p => p.Name.Equals(Name, StringComparison.CurrentCultureIgnoreCase)).UpdatePassword(Value);
        }

        public void UpdatePasswordRemark(String Name, String Remark)
        {
            if (_passwordItems == null)
                throw new Exception(String.Format("密码项【{0}】不存在！", Name));
            if (_passwordItems.FirstOrDefault(p => p.Name.Equals(Name, StringComparison.CurrentCultureIgnoreCase)) == null)
                throw new Exception(String.Format("密码项【{0}】不存在！", Name));

            _passwordItems.FirstOrDefault(p => p.Name.Equals(Name, StringComparison.CurrentCultureIgnoreCase)).UpdateRemark(Remark);
        }
        /// <summary>
        /// 修改密码项
        /// </summary>
        /// <param name="PasswordItems"></param>
        public void UpdatePasswordItems(ICollection<PasswordItem> PasswordItems)
        {
            if (_passwordItems == null)
                _passwordItems = new List<PasswordItem>();

            foreach (var apssword in PasswordItems)
            {
                UpdatePassword(apssword.Name,apssword.Password);
                UpdatePasswordRemark(apssword.Name,apssword.Remark);
            }
        }

        public void RemovePasswordItem(String Name)
        {
            if (_passwordItems == null)
                throw new Exception(String.Format("密码项【{0}】不存在！", Name));
            if (_passwordItems.FirstOrDefault(p => p.Name.Equals(Name, StringComparison.CurrentCultureIgnoreCase)) == null)
                throw new Exception(String.Format("密码项【{0}】不存在！", Name));

            _passwordItems.Remove(_passwordItems.FirstOrDefault(p => p.Name.Equals(Name, StringComparison.CurrentCultureIgnoreCase)));
        }
    }
}
