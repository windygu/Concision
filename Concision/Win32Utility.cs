﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Concision
{
    /*-------------------------------------------------------------------------
 * 版权所有：王浪静
 * 作者：王浪静
 * 联系方式：932444208@qq.com
 * 创建时间： 2017/8/10 11:25:13
 * 版本号：v1.0
 * .NET 版本：4.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/
    public class Win32Utility
    {
        public static void SetCueText(System.Windows.Forms.Control control, String text)
        {
            if (control is ComboBox)
            {
                COMBOBOXINFO info = GetComboBoxInfo(control);
                WindowsApi.SendMessage(info.hwndItem, WindowsConstants.EM_SETCUEBANNER, 0, text);
           
            }
            else
            {
                WindowsApi.SendMessage(control.Handle,WindowsConstants.EM_SETCUEBANNER, 0, text);
            }
        }

        private static COMBOBOXINFO GetComboBoxInfo(System.Windows.Forms.Control control)
        {
            COMBOBOXINFO info = new COMBOBOXINFO();
            info.cbSize = Marshal.SizeOf(info);
            WindowsApi.GetComboBoxInfo(control.Handle, ref info);
            return info;
        }

        public static String GetCueText(System.Windows.Forms.Control control)
        {
            StringBuilder builder = new StringBuilder();
            if (control is ComboBox)
            {
                COMBOBOXINFO info = new COMBOBOXINFO();
                info.cbSize = Marshal.SizeOf(info);
                WindowsApi.GetComboBoxInfo(control.Handle, ref info);
               WindowsApi.SendMessage(info.hwndItem, WindowsConstants.EM_GETCUEBANNER, 0, builder);
            }
            else
            {
                WindowsApi.SendMessage(control.Handle, WindowsConstants.EM_GETCUEBANNER, 0, builder);
            }
            return builder.ToString();
        }
    }
}
