﻿namespace XYWE {
    partial class FormXYWE {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormXYWE));
            this.LlVersion = new System.Windows.Forms.LinkLabel();
            this.BtnXYCodeLibraryManager = new System.Windows.Forms.Button();
            this.BtnXYUILibraryManager = new System.Windows.Forms.Button();
            this.BtnStartXYWE = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LlVersion
            // 
            this.LlVersion.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LlVersion.Location = new System.Drawing.Point(214, 223);
            this.LlVersion.Name = "LlVersion";
            this.LlVersion.Size = new System.Drawing.Size(171, 12);
            this.LlVersion.TabIndex = 0;
            this.LlVersion.TabStop = true;
            this.LlVersion.Text = "LlVersion";
            this.LlVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LlVersion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlVersion_LinkClicked);
            // 
            // BtnXYCodeLibraryManager
            // 
            this.BtnXYCodeLibraryManager.Enabled = false;
            this.BtnXYCodeLibraryManager.Font = new System.Drawing.Font("宋体", 9F);
            this.BtnXYCodeLibraryManager.Location = new System.Drawing.Point(118, 120);
            this.BtnXYCodeLibraryManager.Name = "BtnXYCodeLibraryManager";
            this.BtnXYCodeLibraryManager.Size = new System.Drawing.Size(100, 38);
            this.BtnXYCodeLibraryManager.TabIndex = 1;
            this.BtnXYCodeLibraryManager.Text = "代码库管理器";
            this.BtnXYCodeLibraryManager.UseVisualStyleBackColor = true;
            this.BtnXYCodeLibraryManager.Click += new System.EventHandler(this.BtnXYCodeLibraryManager_Click);
            // 
            // BtnXYUILibraryManager
            // 
            this.BtnXYUILibraryManager.Enabled = false;
            this.BtnXYUILibraryManager.Font = new System.Drawing.Font("宋体", 9F);
            this.BtnXYUILibraryManager.Location = new System.Drawing.Point(12, 120);
            this.BtnXYUILibraryManager.Name = "BtnXYUILibraryManager";
            this.BtnXYUILibraryManager.Size = new System.Drawing.Size(100, 38);
            this.BtnXYUILibraryManager.TabIndex = 3;
            this.BtnXYUILibraryManager.Text = "UI库管理器";
            this.BtnXYUILibraryManager.UseVisualStyleBackColor = true;
            this.BtnXYUILibraryManager.Click += new System.EventHandler(this.BtnXYUILibraryManager_Click);
            // 
            // BtnStartXYWE
            // 
            this.BtnStartXYWE.Location = new System.Drawing.Point(12, 164);
            this.BtnStartXYWE.Name = "BtnStartXYWE";
            this.BtnStartXYWE.Size = new System.Drawing.Size(373, 51);
            this.BtnStartXYWE.TabIndex = 4;
            this.BtnStartXYWE.Text = "启动咸鱼地图编辑器";
            this.BtnStartXYWE.UseVisualStyleBackColor = true;
            this.BtnStartXYWE.Click += new System.EventHandler(this.BtnStartXYWE_Click);
            // 
            // FormXYWE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 244);
            this.Controls.Add(this.BtnStartXYWE);
            this.Controls.Add(this.BtnXYUILibraryManager);
            this.Controls.Add(this.BtnXYCodeLibraryManager);
            this.Controls.Add(this.LlVersion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormXYWE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "咸鱼地图编辑器";
            this.Load += new System.EventHandler(this.FormXYWE_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel LlVersion;
        private System.Windows.Forms.Button BtnXYCodeLibraryManager;
        private System.Windows.Forms.Button BtnXYUILibraryManager;
        private System.Windows.Forms.Button BtnStartXYWE;
    }
}

