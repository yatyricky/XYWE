using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace XYWE {
    public partial class FormXYWE : Form {
        private static FormXYWE Last = null;
        
        public FormXYWE() {
            InitializeComponent();
            Load += FormXYWE_Load;
            Activated += FormXYWE_Activated;
            Last = this;
        }

        private void FormXYWE_Load(object sender, EventArgs e) {
        }

        private void FormXYWE_Activated(object sender, EventArgs e) {
        }

        private void LlVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://wow9.org/xywe");
        }

        private void BtnStartXYWE_Click(object sender, EventArgs e) {
            StartTip.Refresh();
            Process.Start(@"core\ydwe\YDWE.exe");
        }

        private void BtnXYCodeLibraryManager_Click(object sender, EventArgs e) {
#if DEBUG
            Process.Start(@"..\..\..\XYCodeLibraryManager\bin\Debug\XYCodeLibraryManager.exe");
#else
            Process.Start(@"core\xywe\XYCodeLibraryManager.exe");
#endif
        }

        private void BtnXYUILibraryManager_Click(object sender, EventArgs e) {
#if DEBUG
            Process.Start(@"..\..\..\XYMpqLibraryManager\bin\Debug\XYMpqLibraryManager.exe");
#else
            Process.Start(@"core\xywe\XYMpqLibraryManager.exe");
#endif
        }
    }
}
