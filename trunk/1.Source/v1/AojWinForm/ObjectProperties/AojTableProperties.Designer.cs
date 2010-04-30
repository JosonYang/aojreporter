namespace AojReport.AojWinForm.ObjectProperties
{
    partial class AojTableProperties
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlTable = new System.Windows.Forms.TabControl();
            this.tabPageTable = new System.Windows.Forms.TabPage();
            this.txtTableHeight = new System.Windows.Forms.TextBox();
            this.txtTableWidth = new System.Windows.Forms.TextBox();
            this.lbTableHeight = new System.Windows.Forms.Label();
            this.lbTableWidth = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.lbTableName = new System.Windows.Forms.Label();
            this.tabPageColumn = new System.Windows.Forms.TabPage();
            this.groupBoxColumn2 = new System.Windows.Forms.GroupBox();
            this.txtColumnWidth = new System.Windows.Forms.TextBox();
            this.lbColumnWidth = new System.Windows.Forms.Label();
            this.txtColumnName = new System.Windows.Forms.TextBox();
            this.lbColumnName = new System.Windows.Forms.Label();
            this.groupBoxColumn1 = new System.Windows.Forms.GroupBox();
            this.btnDeleteColumn = new System.Windows.Forms.Button();
            this.btnAddColumn = new System.Windows.Forms.Button();
            this.lisBoxColumn = new System.Windows.Forms.ListBox();
            this.tabPageRow = new System.Windows.Forms.TabPage();
            this.groupBoxCell = new System.Windows.Forms.GroupBox();
            this.cmbCellLineAlignment = new System.Windows.Forms.ComboBox();
            this.cmbCellAlignment = new System.Windows.Forms.ComboBox();
            this.lbCellLineAlignment = new System.Windows.Forms.Label();
            this.lbCellAlignment = new System.Windows.Forms.Label();
            this.btnCellColor = new System.Windows.Forms.Button();
            this.btnCellFont = new System.Windows.Forms.Button();
            this.txtCellColor = new System.Windows.Forms.TextBox();
            this.txtCellFont = new System.Windows.Forms.TextBox();
            this.lbCellColor = new System.Windows.Forms.Label();
            this.lbCellFont = new System.Windows.Forms.Label();
            this.lbCellContent = new System.Windows.Forms.Label();
            this.txtCellConent = new System.Windows.Forms.TextBox();
            this.txtCellName = new System.Windows.Forms.TextBox();
            this.lbCellName = new System.Windows.Forms.Label();
            this.groupBoxRow = new System.Windows.Forms.GroupBox();
            this.btnDeleteRow = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.txtRowHeight = new System.Windows.Forms.TextBox();
            this.lbRowHeight = new System.Windows.Forms.Label();
            this.txtRowName = new System.Windows.Forms.TextBox();
            this.laRowName = new System.Windows.Forms.Label();
            this.pictureBoxDirection = new System.Windows.Forms.PictureBox();
            this.listBoxCell = new System.Windows.Forms.ListBox();
            this.listBoxRow = new System.Windows.Forms.ListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.fontDialogForm = new System.Windows.Forms.FontDialog();
            this.colorDialogForm = new System.Windows.Forms.ColorDialog();
            this.tabControlTable.SuspendLayout();
            this.tabPageTable.SuspendLayout();
            this.tabPageColumn.SuspendLayout();
            this.groupBoxColumn2.SuspendLayout();
            this.groupBoxColumn1.SuspendLayout();
            this.tabPageRow.SuspendLayout();
            this.groupBoxCell.SuspendLayout();
            this.groupBoxRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDirection)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlTable
            // 
            this.tabControlTable.Controls.Add(this.tabPageTable);
            this.tabControlTable.Controls.Add(this.tabPageColumn);
            this.tabControlTable.Controls.Add(this.tabPageRow);
            this.tabControlTable.Location = new System.Drawing.Point(2, 1);
            this.tabControlTable.Name = "tabControlTable";
            this.tabControlTable.SelectedIndex = 0;
            this.tabControlTable.Size = new System.Drawing.Size(425, 413);
            this.tabControlTable.TabIndex = 0;
            // 
            // tabPageTable
            // 
            this.tabPageTable.Controls.Add(this.txtTableHeight);
            this.tabPageTable.Controls.Add(this.txtTableWidth);
            this.tabPageTable.Controls.Add(this.lbTableHeight);
            this.tabPageTable.Controls.Add(this.lbTableWidth);
            this.tabPageTable.Controls.Add(this.txtTableName);
            this.tabPageTable.Controls.Add(this.lbTableName);
            this.tabPageTable.Location = new System.Drawing.Point(4, 22);
            this.tabPageTable.Name = "tabPageTable";
            this.tabPageTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTable.Size = new System.Drawing.Size(417, 387);
            this.tabPageTable.TabIndex = 0;
            this.tabPageTable.Text = "表格";
            this.tabPageTable.UseVisualStyleBackColor = true;
            // 
            // txtTableHeight
            // 
            this.txtTableHeight.Location = new System.Drawing.Point(245, 68);
            this.txtTableHeight.Name = "txtTableHeight";
            this.txtTableHeight.Size = new System.Drawing.Size(100, 20);
            this.txtTableHeight.TabIndex = 12;
            this.txtTableHeight.Validated += new System.EventHandler(this.txtTableHeight_Validated);
            // 
            // txtTableWidth
            // 
            this.txtTableWidth.Location = new System.Drawing.Point(66, 68);
            this.txtTableWidth.Name = "txtTableWidth";
            this.txtTableWidth.Size = new System.Drawing.Size(100, 20);
            this.txtTableWidth.TabIndex = 11;
            this.txtTableWidth.Validated += new System.EventHandler(this.txtTableWidth_Validated);
            // 
            // lbTableHeight
            // 
            this.lbTableHeight.AutoSize = true;
            this.lbTableHeight.Location = new System.Drawing.Point(205, 71);
            this.lbTableHeight.Name = "lbTableHeight";
            this.lbTableHeight.Size = new System.Drawing.Size(34, 13);
            this.lbTableHeight.TabIndex = 10;
            this.lbTableHeight.Text = "高度:";
            // 
            // lbTableWidth
            // 
            this.lbTableWidth.AutoSize = true;
            this.lbTableWidth.Location = new System.Drawing.Point(26, 71);
            this.lbTableWidth.Name = "lbTableWidth";
            this.lbTableWidth.Size = new System.Drawing.Size(34, 13);
            this.lbTableWidth.TabIndex = 9;
            this.lbTableWidth.Text = "宽度:";
            // 
            // txtTableName
            // 
            this.txtTableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTableName.Location = new System.Drawing.Point(66, 19);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.ReadOnly = true;
            this.txtTableName.Size = new System.Drawing.Size(100, 20);
            this.txtTableName.TabIndex = 4;
            // 
            // lbTableName
            // 
            this.lbTableName.AutoSize = true;
            this.lbTableName.Location = new System.Drawing.Point(26, 22);
            this.lbTableName.Name = "lbTableName";
            this.lbTableName.Size = new System.Drawing.Size(34, 13);
            this.lbTableName.TabIndex = 3;
            this.lbTableName.Text = "名称:";
            // 
            // tabPageColumn
            // 
            this.tabPageColumn.Controls.Add(this.groupBoxColumn2);
            this.tabPageColumn.Controls.Add(this.groupBoxColumn1);
            this.tabPageColumn.Location = new System.Drawing.Point(4, 22);
            this.tabPageColumn.Name = "tabPageColumn";
            this.tabPageColumn.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageColumn.Size = new System.Drawing.Size(417, 387);
            this.tabPageColumn.TabIndex = 1;
            this.tabPageColumn.Text = "表格列";
            this.tabPageColumn.UseVisualStyleBackColor = true;
            // 
            // groupBoxColumn2
            // 
            this.groupBoxColumn2.Controls.Add(this.txtColumnWidth);
            this.groupBoxColumn2.Controls.Add(this.lbColumnWidth);
            this.groupBoxColumn2.Controls.Add(this.txtColumnName);
            this.groupBoxColumn2.Controls.Add(this.lbColumnName);
            this.groupBoxColumn2.Location = new System.Drawing.Point(6, 210);
            this.groupBoxColumn2.Name = "groupBoxColumn2";
            this.groupBoxColumn2.Size = new System.Drawing.Size(403, 108);
            this.groupBoxColumn2.TabIndex = 1;
            this.groupBoxColumn2.TabStop = false;
            this.groupBoxColumn2.Text = "列属性";
            // 
            // txtColumnWidth
            // 
            this.txtColumnWidth.Location = new System.Drawing.Point(245, 25);
            this.txtColumnWidth.Name = "txtColumnWidth";
            this.txtColumnWidth.Size = new System.Drawing.Size(100, 20);
            this.txtColumnWidth.TabIndex = 13;
            this.txtColumnWidth.Validated += new System.EventHandler(this.txtColumnWidth_Validated);
            // 
            // lbColumnWidth
            // 
            this.lbColumnWidth.AutoSize = true;
            this.lbColumnWidth.Location = new System.Drawing.Point(205, 28);
            this.lbColumnWidth.Name = "lbColumnWidth";
            this.lbColumnWidth.Size = new System.Drawing.Size(34, 13);
            this.lbColumnWidth.TabIndex = 12;
            this.lbColumnWidth.Text = "宽度:";
            // 
            // txtColumnName
            // 
            this.txtColumnName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtColumnName.Location = new System.Drawing.Point(64, 25);
            this.txtColumnName.Name = "txtColumnName";
            this.txtColumnName.Size = new System.Drawing.Size(100, 20);
            this.txtColumnName.TabIndex = 6;
            this.txtColumnName.TextChanged += new System.EventHandler(this.txtColumnName_TextChanged);
            // 
            // lbColumnName
            // 
            this.lbColumnName.AutoSize = true;
            this.lbColumnName.Location = new System.Drawing.Point(24, 28);
            this.lbColumnName.Name = "lbColumnName";
            this.lbColumnName.Size = new System.Drawing.Size(34, 13);
            this.lbColumnName.TabIndex = 5;
            this.lbColumnName.Text = "名称:";
            // 
            // groupBoxColumn1
            // 
            this.groupBoxColumn1.Controls.Add(this.btnDeleteColumn);
            this.groupBoxColumn1.Controls.Add(this.btnAddColumn);
            this.groupBoxColumn1.Controls.Add(this.lisBoxColumn);
            this.groupBoxColumn1.Location = new System.Drawing.Point(6, 6);
            this.groupBoxColumn1.Name = "groupBoxColumn1";
            this.groupBoxColumn1.Size = new System.Drawing.Size(403, 198);
            this.groupBoxColumn1.TabIndex = 0;
            this.groupBoxColumn1.TabStop = false;
            this.groupBoxColumn1.Text = "表格列";
            // 
            // btnDeleteColumn
            // 
            this.btnDeleteColumn.Location = new System.Drawing.Point(270, 111);
            this.btnDeleteColumn.Name = "btnDeleteColumn";
            this.btnDeleteColumn.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteColumn.TabIndex = 14;
            this.btnDeleteColumn.Text = "删除列";
            this.btnDeleteColumn.UseVisualStyleBackColor = true;
            this.btnDeleteColumn.Click += new System.EventHandler(this.btnDeleteColumn_Click);
            // 
            // btnAddColumn
            // 
            this.btnAddColumn.Location = new System.Drawing.Point(270, 57);
            this.btnAddColumn.Name = "btnAddColumn";
            this.btnAddColumn.Size = new System.Drawing.Size(75, 23);
            this.btnAddColumn.TabIndex = 13;
            this.btnAddColumn.Text = "添加列";
            this.btnAddColumn.UseVisualStyleBackColor = true;
            this.btnAddColumn.Click += new System.EventHandler(this.btnAddColumn_Click);
            // 
            // lisBoxColumn
            // 
            this.lisBoxColumn.DisplayMember = "columnname";
            this.lisBoxColumn.FormattingEnabled = true;
            this.lisBoxColumn.Location = new System.Drawing.Point(18, 19);
            this.lisBoxColumn.Name = "lisBoxColumn";
            this.lisBoxColumn.Size = new System.Drawing.Size(146, 173);
            this.lisBoxColumn.TabIndex = 0;
            this.lisBoxColumn.ValueMember = "columnvalue";
            this.lisBoxColumn.SelectedIndexChanged += new System.EventHandler(this.lisBoxColumn_SelectedIndexChanged);
            // 
            // tabPageRow
            // 
            this.tabPageRow.Controls.Add(this.groupBoxCell);
            this.tabPageRow.Controls.Add(this.groupBoxRow);
            this.tabPageRow.Location = new System.Drawing.Point(4, 22);
            this.tabPageRow.Name = "tabPageRow";
            this.tabPageRow.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRow.Size = new System.Drawing.Size(417, 387);
            this.tabPageRow.TabIndex = 2;
            this.tabPageRow.Text = "表格行";
            this.tabPageRow.UseVisualStyleBackColor = true;
            // 
            // groupBoxCell
            // 
            this.groupBoxCell.Controls.Add(this.cmbCellLineAlignment);
            this.groupBoxCell.Controls.Add(this.cmbCellAlignment);
            this.groupBoxCell.Controls.Add(this.lbCellLineAlignment);
            this.groupBoxCell.Controls.Add(this.lbCellAlignment);
            this.groupBoxCell.Controls.Add(this.btnCellColor);
            this.groupBoxCell.Controls.Add(this.btnCellFont);
            this.groupBoxCell.Controls.Add(this.txtCellColor);
            this.groupBoxCell.Controls.Add(this.txtCellFont);
            this.groupBoxCell.Controls.Add(this.lbCellColor);
            this.groupBoxCell.Controls.Add(this.lbCellFont);
            this.groupBoxCell.Controls.Add(this.lbCellContent);
            this.groupBoxCell.Controls.Add(this.txtCellConent);
            this.groupBoxCell.Controls.Add(this.txtCellName);
            this.groupBoxCell.Controls.Add(this.lbCellName);
            this.groupBoxCell.Location = new System.Drawing.Point(11, 174);
            this.groupBoxCell.Name = "groupBoxCell";
            this.groupBoxCell.Size = new System.Drawing.Size(403, 203);
            this.groupBoxCell.TabIndex = 3;
            this.groupBoxCell.TabStop = false;
            this.groupBoxCell.Text = "单元格";
            // 
            // cmbCellLineAlignment
            // 
            this.cmbCellLineAlignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCellLineAlignment.FormattingEnabled = true;
            this.cmbCellLineAlignment.Location = new System.Drawing.Point(243, 162);
            this.cmbCellLineAlignment.Name = "cmbCellLineAlignment";
            this.cmbCellLineAlignment.Size = new System.Drawing.Size(76, 21);
            this.cmbCellLineAlignment.TabIndex = 19;
            this.cmbCellLineAlignment.SelectedIndexChanged += new System.EventHandler(this.cmbCellLineAlignment_SelectedIndexChanged);
            // 
            // cmbCellAlignment
            // 
            this.cmbCellAlignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCellAlignment.FormattingEnabled = true;
            this.cmbCellAlignment.Location = new System.Drawing.Point(64, 162);
            this.cmbCellAlignment.Name = "cmbCellAlignment";
            this.cmbCellAlignment.Size = new System.Drawing.Size(76, 21);
            this.cmbCellAlignment.TabIndex = 18;
            this.cmbCellAlignment.SelectedIndexChanged += new System.EventHandler(this.cmbCellAlignment_SelectedIndexChanged);
            // 
            // lbCellLineAlignment
            // 
            this.lbCellLineAlignment.AutoSize = true;
            this.lbCellLineAlignment.Location = new System.Drawing.Point(179, 165);
            this.lbCellLineAlignment.Name = "lbCellLineAlignment";
            this.lbCellLineAlignment.Size = new System.Drawing.Size(58, 13);
            this.lbCellLineAlignment.TabIndex = 17;
            this.lbCellLineAlignment.Text = "上下对齐:";
            // 
            // lbCellAlignment
            // 
            this.lbCellAlignment.AutoSize = true;
            this.lbCellAlignment.Location = new System.Drawing.Point(0, 165);
            this.lbCellAlignment.Name = "lbCellAlignment";
            this.lbCellAlignment.Size = new System.Drawing.Size(58, 13);
            this.lbCellAlignment.TabIndex = 16;
            this.lbCellAlignment.Text = "左右对齐:";
            // 
            // btnCellColor
            // 
            this.btnCellColor.Location = new System.Drawing.Point(303, 129);
            this.btnCellColor.Name = "btnCellColor";
            this.btnCellColor.Size = new System.Drawing.Size(75, 23);
            this.btnCellColor.TabIndex = 15;
            this.btnCellColor.Text = "选择颜色";
            this.btnCellColor.UseVisualStyleBackColor = true;
            this.btnCellColor.Click += new System.EventHandler(this.btnCellColor_Click);
            // 
            // btnCellFont
            // 
            this.btnCellFont.Location = new System.Drawing.Point(303, 90);
            this.btnCellFont.Name = "btnCellFont";
            this.btnCellFont.Size = new System.Drawing.Size(75, 23);
            this.btnCellFont.TabIndex = 14;
            this.btnCellFont.Text = "选择字体";
            this.btnCellFont.UseVisualStyleBackColor = true;
            this.btnCellFont.Click += new System.EventHandler(this.btnCellFont_Click);
            // 
            // txtCellColor
            // 
            this.txtCellColor.Enabled = false;
            this.txtCellColor.Location = new System.Drawing.Point(64, 131);
            this.txtCellColor.Name = "txtCellColor";
            this.txtCellColor.ReadOnly = true;
            this.txtCellColor.Size = new System.Drawing.Size(224, 20);
            this.txtCellColor.TabIndex = 13;
            // 
            // txtCellFont
            // 
            this.txtCellFont.Location = new System.Drawing.Point(64, 93);
            this.txtCellFont.Name = "txtCellFont";
            this.txtCellFont.ReadOnly = true;
            this.txtCellFont.Size = new System.Drawing.Size(224, 20);
            this.txtCellFont.TabIndex = 12;
            // 
            // lbCellColor
            // 
            this.lbCellColor.AutoSize = true;
            this.lbCellColor.Location = new System.Drawing.Point(24, 134);
            this.lbCellColor.Name = "lbCellColor";
            this.lbCellColor.Size = new System.Drawing.Size(34, 13);
            this.lbCellColor.TabIndex = 11;
            this.lbCellColor.Text = "颜色:";
            // 
            // lbCellFont
            // 
            this.lbCellFont.AutoSize = true;
            this.lbCellFont.Location = new System.Drawing.Point(24, 96);
            this.lbCellFont.Name = "lbCellFont";
            this.lbCellFont.Size = new System.Drawing.Size(34, 13);
            this.lbCellFont.TabIndex = 10;
            this.lbCellFont.Text = "字体:";
            // 
            // lbCellContent
            // 
            this.lbCellContent.AutoSize = true;
            this.lbCellContent.Location = new System.Drawing.Point(24, 54);
            this.lbCellContent.Name = "lbCellContent";
            this.lbCellContent.Size = new System.Drawing.Size(34, 13);
            this.lbCellContent.TabIndex = 8;
            this.lbCellContent.Text = "文本:";
            // 
            // txtCellConent
            // 
            this.txtCellConent.Location = new System.Drawing.Point(64, 51);
            this.txtCellConent.Multiline = true;
            this.txtCellConent.Name = "txtCellConent";
            this.txtCellConent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCellConent.Size = new System.Drawing.Size(314, 36);
            this.txtCellConent.TabIndex = 7;
            this.txtCellConent.TextChanged += new System.EventHandler(this.txtCellConent_TextChanged);
            // 
            // txtCellName
            // 
            this.txtCellName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCellName.Location = new System.Drawing.Point(64, 25);
            this.txtCellName.Name = "txtCellName";
            this.txtCellName.ReadOnly = true;
            this.txtCellName.Size = new System.Drawing.Size(100, 20);
            this.txtCellName.TabIndex = 6;
            // 
            // lbCellName
            // 
            this.lbCellName.AutoSize = true;
            this.lbCellName.Location = new System.Drawing.Point(24, 28);
            this.lbCellName.Name = "lbCellName";
            this.lbCellName.Size = new System.Drawing.Size(34, 13);
            this.lbCellName.TabIndex = 5;
            this.lbCellName.Text = "名称:";
            // 
            // groupBoxRow
            // 
            this.groupBoxRow.Controls.Add(this.btnDeleteRow);
            this.groupBoxRow.Controls.Add(this.btnAddRow);
            this.groupBoxRow.Controls.Add(this.txtRowHeight);
            this.groupBoxRow.Controls.Add(this.lbRowHeight);
            this.groupBoxRow.Controls.Add(this.txtRowName);
            this.groupBoxRow.Controls.Add(this.laRowName);
            this.groupBoxRow.Controls.Add(this.pictureBoxDirection);
            this.groupBoxRow.Controls.Add(this.listBoxCell);
            this.groupBoxRow.Controls.Add(this.listBoxRow);
            this.groupBoxRow.Location = new System.Drawing.Point(8, 6);
            this.groupBoxRow.Name = "groupBoxRow";
            this.groupBoxRow.Size = new System.Drawing.Size(403, 162);
            this.groupBoxRow.TabIndex = 1;
            this.groupBoxRow.TabStop = false;
            this.groupBoxRow.Text = "表格行";
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.Location = new System.Drawing.Point(165, 76);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteRow.TabIndex = 19;
            this.btnDeleteRow.Text = "删除行";
            this.btnDeleteRow.UseVisualStyleBackColor = true;
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Location = new System.Drawing.Point(165, 51);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(75, 23);
            this.btnAddRow.TabIndex = 18;
            this.btnAddRow.Text = "添加行";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // txtRowHeight
            // 
            this.txtRowHeight.Location = new System.Drawing.Point(153, 133);
            this.txtRowHeight.Name = "txtRowHeight";
            this.txtRowHeight.Size = new System.Drawing.Size(100, 20);
            this.txtRowHeight.TabIndex = 17;
            this.txtRowHeight.Validated += new System.EventHandler(this.txtRowHeight_Validated);
            // 
            // lbRowHeight
            // 
            this.lbRowHeight.AutoSize = true;
            this.lbRowHeight.Location = new System.Drawing.Point(123, 136);
            this.lbRowHeight.Name = "lbRowHeight";
            this.lbRowHeight.Size = new System.Drawing.Size(34, 13);
            this.lbRowHeight.TabIndex = 16;
            this.lbRowHeight.Text = "高度:";
            // 
            // txtRowName
            // 
            this.txtRowName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRowName.Location = new System.Drawing.Point(154, 105);
            this.txtRowName.Name = "txtRowName";
            this.txtRowName.Size = new System.Drawing.Size(100, 20);
            this.txtRowName.TabIndex = 15;
            this.txtRowName.TextChanged += new System.EventHandler(this.txtRowName_TextChanged);
            // 
            // laRowName
            // 
            this.laRowName.AutoSize = true;
            this.laRowName.Location = new System.Drawing.Point(123, 108);
            this.laRowName.Name = "laRowName";
            this.laRowName.Size = new System.Drawing.Size(34, 13);
            this.laRowName.TabIndex = 14;
            this.laRowName.Text = "名称:";
            // 
            // pictureBoxDirection
            // 
            this.pictureBoxDirection.Image = global::AojReport.AojWinForm.Properties.Resources.direction;
            this.pictureBoxDirection.Location = new System.Drawing.Point(127, 19);
            this.pictureBoxDirection.Name = "pictureBoxDirection";
            this.pictureBoxDirection.Size = new System.Drawing.Size(153, 26);
            this.pictureBoxDirection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxDirection.TabIndex = 2;
            this.pictureBoxDirection.TabStop = false;
            // 
            // listBoxCell
            // 
            this.listBoxCell.FormattingEnabled = true;
            this.listBoxCell.Location = new System.Drawing.Point(286, 19);
            this.listBoxCell.Name = "listBoxCell";
            this.listBoxCell.Size = new System.Drawing.Size(100, 134);
            this.listBoxCell.TabIndex = 1;
            this.listBoxCell.SelectedIndexChanged += new System.EventHandler(this.listBoxCell_SelectedIndexChanged);
            // 
            // listBoxRow
            // 
            this.listBoxRow.DisplayMember = "columnname";
            this.listBoxRow.FormattingEnabled = true;
            this.listBoxRow.Location = new System.Drawing.Point(18, 19);
            this.listBoxRow.Name = "listBoxRow";
            this.listBoxRow.Size = new System.Drawing.Size(100, 134);
            this.listBoxRow.TabIndex = 0;
            this.listBoxRow.ValueMember = "columnvalue";
            this.listBoxRow.SelectedIndexChanged += new System.EventHandler(this.listBoxRow_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(342, 428);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(261, 428);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // fontDialogForm
            // 
            this.fontDialogForm.AllowScriptChange = false;
            // 
            // AojTableProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 463);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabControlTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AojTableProperties";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TableProperties";
            this.tabControlTable.ResumeLayout(false);
            this.tabPageTable.ResumeLayout(false);
            this.tabPageTable.PerformLayout();
            this.tabPageColumn.ResumeLayout(false);
            this.groupBoxColumn2.ResumeLayout(false);
            this.groupBoxColumn2.PerformLayout();
            this.groupBoxColumn1.ResumeLayout(false);
            this.tabPageRow.ResumeLayout(false);
            this.groupBoxCell.ResumeLayout(false);
            this.groupBoxCell.PerformLayout();
            this.groupBoxRow.ResumeLayout(false);
            this.groupBoxRow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDirection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlTable;
        private System.Windows.Forms.TabPage tabPageTable;
        private System.Windows.Forms.TabPage tabPageColumn;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabPage tabPageRow;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label lbTableName;
        private System.Windows.Forms.TextBox txtTableHeight;
        private System.Windows.Forms.TextBox txtTableWidth;
        private System.Windows.Forms.Label lbTableHeight;
        private System.Windows.Forms.Label lbTableWidth;
        private System.Windows.Forms.GroupBox groupBoxColumn1;
        private System.Windows.Forms.GroupBox groupBoxColumn2;
        private System.Windows.Forms.TextBox txtColumnName;
        private System.Windows.Forms.Label lbColumnName;
        private System.Windows.Forms.TextBox txtColumnWidth;
        private System.Windows.Forms.Label lbColumnWidth;
        private System.Windows.Forms.ListBox lisBoxColumn;
        private System.Windows.Forms.GroupBox groupBoxRow;
        private System.Windows.Forms.ListBox listBoxRow;
        private System.Windows.Forms.ListBox listBoxCell;
        private System.Windows.Forms.PictureBox pictureBoxDirection;
        private System.Windows.Forms.GroupBox groupBoxCell;
        private System.Windows.Forms.TextBox txtCellName;
        private System.Windows.Forms.Label lbCellName;
        private System.Windows.Forms.TextBox txtRowHeight;
        private System.Windows.Forms.Label lbRowHeight;
        private System.Windows.Forms.TextBox txtRowName;
        private System.Windows.Forms.Label laRowName;
        private System.Windows.Forms.Label lbCellContent;
        private System.Windows.Forms.TextBox txtCellConent;
        private System.Windows.Forms.Button btnCellColor;
        private System.Windows.Forms.Button btnCellFont;
        private System.Windows.Forms.TextBox txtCellColor;
        private System.Windows.Forms.TextBox txtCellFont;
        private System.Windows.Forms.Label lbCellColor;
        private System.Windows.Forms.Label lbCellFont;
        private System.Windows.Forms.ComboBox cmbCellLineAlignment;
        private System.Windows.Forms.ComboBox cmbCellAlignment;
        private System.Windows.Forms.Label lbCellLineAlignment;
        private System.Windows.Forms.Label lbCellAlignment;
        private System.Windows.Forms.FontDialog fontDialogForm;
        private System.Windows.Forms.ColorDialog colorDialogForm;
        private System.Windows.Forms.Button btnDeleteColumn;
        private System.Windows.Forms.Button btnAddColumn;
        private System.Windows.Forms.Button btnDeleteRow;
        private System.Windows.Forms.Button btnAddRow;
    }
}