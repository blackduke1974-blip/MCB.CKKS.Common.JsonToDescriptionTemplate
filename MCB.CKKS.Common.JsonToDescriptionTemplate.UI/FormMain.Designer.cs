using CDS.Markdown;

namespace MCB.CKKS.Common.JsonToDescriptionTemplate.UI
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtJsonFile;
        private System.Windows.Forms.Button btnSelectJson;
        private System.Windows.Forms.TextBox txtTemplateFile;
        private System.Windows.Forms.Button btnSelectTemplate;
        private MarkdownViewer mdViewer;
        private System.Windows.Forms.Button btnRender;
        private System.Windows.Forms.ListBox lstRenders;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtJsonFile = new System.Windows.Forms.TextBox();
            btnSelectJson = new System.Windows.Forms.Button();
            txtTemplateFile = new System.Windows.Forms.TextBox();
            btnSelectTemplate = new System.Windows.Forms.Button();
            mdViewer = new MarkdownViewer();
            btnRender = new System.Windows.Forms.Button();
            lstRenders = new System.Windows.Forms.ListBox();
            SuspendLayout();
            // 
            // txtJsonFile
            // 
            txtJsonFile.Location = new System.Drawing.Point(12, 12);
            txtJsonFile.Name = "txtJsonFile";
            txtJsonFile.ReadOnly = true;
            txtJsonFile.Size = new System.Drawing.Size(500, 23);
            txtJsonFile.TabIndex = 0;
            // 
            // btnSelectJson
            // 
            btnSelectJson.Location = new System.Drawing.Point(518, 12);
            btnSelectJson.Name = "btnSelectJson";
            btnSelectJson.Size = new System.Drawing.Size(75, 23);
            btnSelectJson.TabIndex = 1;
            btnSelectJson.Text = "Выбрать";
            btnSelectJson.UseVisualStyleBackColor = true;
            btnSelectJson.Click += btnSelectJson_Click;
            // 
            // txtTemplateFile
            // 
            txtTemplateFile.Location = new System.Drawing.Point(12, 41);
            txtTemplateFile.Name = "txtTemplateFile";
            txtTemplateFile.ReadOnly = true;
            txtTemplateFile.Size = new System.Drawing.Size(500, 23);
            txtTemplateFile.TabIndex = 2;
            // 
            // btnSelectTemplate
            // 
            btnSelectTemplate.Location = new System.Drawing.Point(518, 41);
            btnSelectTemplate.Name = "btnSelectTemplate";
            btnSelectTemplate.Size = new System.Drawing.Size(75, 23);
            btnSelectTemplate.TabIndex = 3;
            btnSelectTemplate.Text = "Выбрать";
            btnSelectTemplate.UseVisualStyleBackColor = true;
            btnSelectTemplate.Click += btnSelectTemplate_Click;
            // 
            // lstRenders
            // 
            lstRenders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)));
            lstRenders.FormattingEnabled = true;
            lstRenders.ItemHeight = 15;
            lstRenders.Location = new System.Drawing.Point(12, 70);
            lstRenders.Name = "lstRenders";
            lstRenders.Size = new System.Drawing.Size(250, 364);
            lstRenders.TabIndex = 6;
            lstRenders.SelectedIndexChanged += lstRenders_SelectedIndexChanged;
            // 
            // mdViewer
            // 
            mdViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            mdViewer.Location = new System.Drawing.Point(268, 70);
            mdViewer.Name = "mdViewer";
            mdViewer.Options.ShowNavigationToolbar = true;
            mdViewer.Size = new System.Drawing.Size(520, 368);
            mdViewer.TabIndex = 4;
            // 
            // btnRender
            // 
            btnRender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            btnRender.Location = new System.Drawing.Point(599, 12);
            btnRender.Name = "btnRender";
            btnRender.Size = new System.Drawing.Size(189, 23);
            btnRender.TabIndex = 5;
            btnRender.Text = "Рендер";
            btnRender.UseVisualStyleBackColor = true;
            btnRender.Click += btnRender_Click;
            // 
            // FormMain
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(lstRenders);
            Controls.Add(btnRender);
            Controls.Add(mdViewer);
            Controls.Add(btnSelectTemplate);
            Controls.Add(txtTemplateFile);
            Controls.Add(btnSelectJson);
            Controls.Add(txtJsonFile);
            Name = "FormMain";
            Text = "JsonToDescriptionTemplate";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
