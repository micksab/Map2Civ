/*This file is part of Map2Civilization.

    Map2Civilization is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Map2Civilization is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Foobar.  If not, see<http://www.gnu.org/licenses/>.*/

using Map2Civilization.Properties;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace Map2CivilizationView
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();

            Text = string.Concat(Map2Civilization.Properties.Resources.Str_AboutForm_About,
                Resources.Str_SingleSpace, this.AssemblyTitle);
            labelProductName.Text = this.AssemblyProduct;
            labelVersion.Text = string.Concat(Resources.Str_AboutForm_Version,
                Resources.Str_SingleSpace, this.AssemblyVersion);
            labelCopyright.Text = AssemblyCopyright;
        }

        #region Assembly Attribute Accessors

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (!string.IsNullOrEmpty(titleAttribute.Title))
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        public String AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        #endregion Assembly Attribute Accessors

        private void textBoxDescription_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            if (IsHttpURL(e.LinkText)) Process.Start(e.LinkText);
        }

        // Performs the actual browser launch to follow link:
        private void LaunchWeblink(string url)
        {
            if (IsHttpURL(url)) Process.Start(url);
        }

        // Simple check to make sure link is valid,
        // can be modified to check for other protocols:
        private bool IsHttpURL(string url)
        {
            return
                ((!string.IsNullOrWhiteSpace(url)) &&
                (url.ToLower(CultureInfo.InvariantCulture).StartsWith("http", StringComparison.Ordinal)));
        }

        private void creditsButton_Click(object sender, EventArgs e)
        {
            using (CreditsForm creditsForm = new CreditsForm())
            {
                creditsForm.ShowDialog();
            }
        }
    }
}