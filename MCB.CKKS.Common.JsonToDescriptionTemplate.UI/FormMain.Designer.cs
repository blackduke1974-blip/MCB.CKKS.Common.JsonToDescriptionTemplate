using CDS.Markdown;

namespace MCB.CKKS.Common.JsonToDescriptionTemplate.UI
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private MarkdownViewer mdViewer;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
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
            components = new System.ComponentModel.Container();
            mdViewer = new MarkdownViewer();
            groupBoxList = new GroupBox();
            dgvRenders = new DataGridView();
            chkSelectColumn = new DataGridViewCheckBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colType = new DataGridViewTextBoxColumn();
            pnlActions = new FlowLayoutPanel();
            btnSaveAs = new Button();
            btnMoveDown = new Button();
            btnMoveUp = new Button();
            btnConcatenate = new Button();
            btnDeleteSelected = new Button();
            toolTipActions = new ToolTip(components);
            groupBoxFiles = new GroupBox();
            btnRender = new Button();
            btnSelectTemplate = new Button();
            cmbTemplateFile = new ComboBox();
            btnSelectJson = new Button();
            cmbJsonFile = new ComboBox();
            splitter1 = new Splitter();
            mdViewer.BorderStyle = BorderStyle.Fixed3D;
            mdViewer.Dock = DockStyle.Fill;
            mdViewer.Location = new Point(361, 86);
            mdViewer.Name = "mdViewer";
            mdViewer.Options.ShowNavigationToolbar = false;
            mdViewer.Size = new Size(855, 444);
            mdViewer.TabIndex = 4;
            // 
            // groupBoxList
            // 
            groupBoxList.Controls.Add(dgvRenders);
            groupBoxList.Controls.Add(pnlActions);
            groupBoxList.Dock = DockStyle.Left;
            groupBoxList.Location = new Point(0, 0);
            groupBoxList.Name = "groupBoxList";
            groupBoxList.Size = new Size(351, 530);
            groupBoxList.TabIndex = 8;
            groupBoxList.TabStop = false;
            groupBoxList.Text = "Список обработанных данных";
            // 
            // dgvRenders
            // 
            dgvRenders.AllowUserToAddRows = false;
            dgvRenders.AllowUserToDeleteRows = false;
            dgvRenders.AllowUserToResizeRows = false;
            dgvRenders.AutoGenerateColumns = false;
            dgvRenders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRenders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRenders.Columns.AddRange(new DataGridViewColumn[] { chkSelectColumn, colName, colType });
            dgvRenders.Dock = DockStyle.Fill;
            dgvRenders.Location = new Point(39, 19);
            dgvRenders.MultiSelect = false;
            dgvRenders.Name = "dgvRenders";
            dgvRenders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRenders.Size = new Size(309, 508);
            dgvRenders.TabIndex = 7;
            dgvRenders.RowHeadersVisible = false;
            dgvRenders.SelectionChanged += dgvRenders_SelectionChanged;
            // 
            // chkSelectColumn
            // 
            chkSelectColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            chkSelectColumn.DataPropertyName = "IsSelected";
            chkSelectColumn.FalseValue = false;
            chkSelectColumn.HeaderText = "";
            chkSelectColumn.Name = "chkSelectColumn";
            chkSelectColumn.Resizable = DataGridViewTriState.True;
            chkSelectColumn.TrueValue = true;
            chkSelectColumn.Width = 30;
            // 
            // colName
            // 
            colName.DataPropertyName = "Name";
            colName.FillWeight = 50F;
            colName.HeaderText = "Название";
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colType
            // 
            colType.DataPropertyName = "TypeDisplay";
            colType.FillWeight = 50F;
            colType.HeaderText = "Тип";
            colType.Name = "colType";
            colType.ReadOnly = true;
            // 
            // pnlActions
            // 
            pnlActions.Controls.Add(btnMoveUp);
            pnlActions.Controls.Add(btnMoveDown);
            pnlActions.Controls.Add(btnConcatenate);
            pnlActions.Controls.Add(btnSaveAs);
            pnlActions.Controls.Add(btnDeleteSelected);
            pnlActions.Dock = DockStyle.Left;
            pnlActions.FlowDirection = FlowDirection.TopDown;
            pnlActions.Location = new Point(3, 19);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(36, 508);
            pnlActions.TabIndex = 8;
            // 
            // btnMoveUp
            // 
            btnMoveUp.FlatAppearance.BorderSize = 0;
            btnMoveUp.Font = new Font("Segoe UI Symbol", 11F);
            btnMoveUp.ForeColor = Color.FromArgb(48, 48, 48);
            btnMoveUp.Location = new Point(3, 3);
            btnMoveUp.Name = "btnMoveUp";
            btnMoveUp.Size = new Size(30, 30);
            btnMoveUp.TabIndex = 2;
            btnMoveUp.Text = "⬆";
            btnMoveUp.TextImageRelation = TextImageRelation.ImageAboveText;
            toolTipActions.SetToolTip(btnMoveUp, "Вверх");
            btnMoveUp.UseVisualStyleBackColor = true;
            btnMoveUp.Click += btnMoveUp_Click;
            // 
            // btnMoveDown
            // 
            btnMoveDown.FlatAppearance.BorderSize = 0;
            btnMoveDown.Font = new Font("Segoe UI Symbol", 11F);
            btnMoveDown.ForeColor = Color.FromArgb(48, 48, 48);
            btnMoveDown.Location = new Point(3, 39);
            btnMoveDown.Name = "btnMoveDown";
            btnMoveDown.Size = new Size(30, 30);
            btnMoveDown.TabIndex = 3;
            btnMoveDown.Text = "⬇";
            btnMoveDown.TextImageRelation = TextImageRelation.ImageAboveText;
            toolTipActions.SetToolTip(btnMoveDown, "Вниз");
            btnMoveDown.UseVisualStyleBackColor = true;
            btnMoveDown.Click += btnMoveDown_Click;
            // 
            // btnConcatenate
            // 
            btnConcatenate.FlatAppearance.BorderSize = 0;
            btnConcatenate.Font = new Font("Segoe UI Symbol", 11F);
            btnConcatenate.ForeColor = Color.FromArgb(48, 48, 48);
            btnConcatenate.Location = new Point(3, 75);
            btnConcatenate.Name = "btnConcatenate";
            btnConcatenate.Size = new Size(30, 30);
            btnConcatenate.TabIndex = 1;
            btnConcatenate.Text = "🔗";
            btnConcatenate.TextImageRelation = TextImageRelation.ImageAboveText;
            toolTipActions.SetToolTip(btnConcatenate, "Склеить");
            btnConcatenate.UseVisualStyleBackColor = true;
            btnConcatenate.Click += btnConcatenate_Click;
            // 
            // btnSaveAs
            // 
            btnSaveAs.FlatAppearance.BorderSize = 0;
            btnSaveAs.Font = new Font("Segoe UI Symbol", 11F);
            btnSaveAs.ForeColor = Color.FromArgb(48, 48, 48);
            btnSaveAs.Location = new Point(3, 111);
            btnSaveAs.Name = "btnSaveAs";
            btnSaveAs.Size = new Size(30, 30);
            btnSaveAs.TabIndex = 4;
            btnSaveAs.Text = "💾";
            btnSaveAs.TextImageRelation = TextImageRelation.ImageAboveText;
            toolTipActions.SetToolTip(btnSaveAs, "Сохранить как");
            btnSaveAs.UseVisualStyleBackColor = true;
            btnSaveAs.Click += btnSaveAs_Click;
            // 
            // btnDeleteSelected
            // 
            btnDeleteSelected.FlatAppearance.BorderSize = 0;
            btnDeleteSelected.Font = new Font("Segoe UI Symbol", 11F);
            btnDeleteSelected.ForeColor = Color.FromArgb(48, 48, 48);
            btnDeleteSelected.Location = new Point(3, 147);
            btnDeleteSelected.Name = "btnDeleteSelected";
            btnDeleteSelected.Size = new Size(30, 30);
            btnDeleteSelected.TabIndex = 0;
            btnDeleteSelected.Text = "✕";
            btnDeleteSelected.TextImageRelation = TextImageRelation.ImageAboveText;
            toolTipActions.SetToolTip(btnDeleteSelected, "Удалить");
            btnDeleteSelected.UseVisualStyleBackColor = true;
            btnDeleteSelected.Click += btnDeleteSelected_Click;
            // 
            // groupBoxFiles
            // 
            groupBoxFiles.Controls.Add(btnRender);
            groupBoxFiles.Controls.Add(btnSelectTemplate);
            groupBoxFiles.Controls.Add(cmbTemplateFile);
            groupBoxFiles.Controls.Add(btnSelectJson);
            groupBoxFiles.Controls.Add(cmbJsonFile);
            groupBoxFiles.Dock = DockStyle.Top;
            groupBoxFiles.Location = new Point(361, 0);
            groupBoxFiles.Name = "groupBoxFiles";
            groupBoxFiles.Size = new Size(855, 86);
            groupBoxFiles.TabIndex = 9;
            groupBoxFiles.TabStop = false;
            groupBoxFiles.Text = "Обработка файлов";
            // 
            // btnRender
            // 
            btnRender.Location = new Point(6, 22);
            btnRender.Name = "btnRender";
            btnRender.Size = new Size(191, 23);
            btnRender.TabIndex = 10;
            btnRender.Text = "Рендер";
            btnRender.UseVisualStyleBackColor = true;
            btnRender.Click += btnRender_Click;
            // 
            // btnSelectTemplate
            // 
            btnSelectTemplate.Location = new Point(216, 50);
            btnSelectTemplate.Name = "btnSelectTemplate";
            btnSelectTemplate.Size = new Size(191, 23);
            btnSelectTemplate.TabIndex = 9;
            btnSelectTemplate.Text = "Выбрать шаблон";
            btnSelectTemplate.UseVisualStyleBackColor = true;
            btnSelectTemplate.Click += btnSelectTemplate_Click;
            // 
            // cmbTemplateFile
            // 
            cmbTemplateFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbTemplateFile.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbTemplateFile.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbTemplateFile.DropDownHeight = 200;
            cmbTemplateFile.FormattingEnabled = true;
            cmbTemplateFile.IntegralHeight = false;
            cmbTemplateFile.Location = new Point(413, 51);
            cmbTemplateFile.Name = "cmbTemplateFile";
            cmbTemplateFile.Size = new Size(436, 23);
            cmbTemplateFile.TabIndex = 8;
            // 
            // btnSelectJson
            // 
            btnSelectJson.Location = new Point(216, 22);
            btnSelectJson.Name = "btnSelectJson";
            btnSelectJson.Size = new Size(191, 23);
            btnSelectJson.TabIndex = 7;
            btnSelectJson.Text = "Выбрать источник";
            btnSelectJson.UseVisualStyleBackColor = true;
            btnSelectJson.Click += btnSelectJson_Click;
            // 
            // cmbJsonFile
            // 
            cmbJsonFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbJsonFile.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbJsonFile.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbJsonFile.DropDownHeight = 200;
            cmbJsonFile.FormattingEnabled = true;
            cmbJsonFile.IntegralHeight = false;
            cmbJsonFile.Location = new Point(413, 22);
            cmbJsonFile.Name = "cmbJsonFile";
            cmbJsonFile.Size = new Size(436, 23);
            cmbJsonFile.TabIndex = 6;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(351, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(10, 530);
            splitter1.TabIndex = 10;
            splitter1.TabStop = false;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1216, 530);
            Controls.Add(mdViewer);
            Controls.Add(groupBoxFiles);
            Controls.Add(splitter1);
            Controls.Add(groupBoxList);
            Name = "FormMain";
            Text = "JsonToDescriptionTemplate";
            groupBoxList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRenders).EndInit();
            pnlActions.ResumeLayout(false);
            groupBoxFiles.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxList;
        private FlowLayoutPanel pnlActions;
        private ToolTip toolTipActions;
        private DataGridView dgvRenders;
        private DataGridViewCheckBoxColumn chkSelectColumn;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colType;
        private Button btnSaveAs;
        private Button btnMoveDown;
        private Button btnMoveUp;
        private Button btnConcatenate;
        private Button btnDeleteSelected;
        private GroupBox groupBoxFiles;
        private Button btnRender;
        private Button btnSelectTemplate;
        private ComboBox cmbTemplateFile;
        private Button btnSelectJson;
        private ComboBox cmbJsonFile;
        private Splitter splitter1;
    }
}
