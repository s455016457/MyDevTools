#region CopyRight
/**************************************************************
   Copyright (c) 2014 StarPeng. All rights reserved.
   CLR版本        :    4.0.30319.34011
   命名空间名称   :    RunsaTools
   文件名         :    FormHelper
   创建时间       :    2014/3/31 14:35:41
   用户所在的域   :    SWT410
   登录用户名     :    Star
   文件描述       :    
   版本           :    1.0.0
   历史           :    
   最后更新人     :   
   最后更新时间   :   
 **************************************************************/
#endregion CopyRight

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyDevTools
{
    public class FormHelper
    {
        private const String TITLE_CONFIRM = "确认";
        private const String TITLE_WARING = "警告";
        private const String TITLE_INFO = "消息";
        private const String TITLE_ERROR = "错误";
        private const String TITLE_HELP = "帮助";
        private const String CONFIRM_DELETE_MESSAGE = "确认删除吗？";

        public static Boolean ConfirmDetele()
        {
            return Confirm(CONFIRM_DELETE_MESSAGE);
        }

        public static Boolean Confirm(String message)
        {
            return Confirm(message.PadRight(50, ' '), TITLE_CONFIRM);
        }

        public static Boolean Confirm(String message, String title)
        {
            var result = MessageBox.Show(message.PadRight(50, ' '), title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            return result == DialogResult.OK;
        }

        public static void ShowWarning(String message)
        {
            ShowWarning(message, TITLE_WARING);
        }

        public static void ShowWarning(String message, String title)
        {
            MessageBox.Show(message.PadRight(50, ' '), title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowInfo(String message)
        {
            ShowInfo(message, TITLE_INFO);
        }

        public static void ShowInfo(String message, String title)
        {
            MessageBox.Show(message.PadRight(50, ' '), title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowHelp(String message)
        {
            ShowHelp(message, TITLE_HELP);
        }

        public static void ShowHelp(String message, String title)
        {
            MessageBox.Show(message.PadRight(50, ' '), title, MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        public static void ShowError(String message)
        {
            ShowError(message, TITLE_ERROR);
        }

        public static void ShowError(String message, String title)
        {
            MessageBox.Show(message.PadRight(50, ' '), title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
