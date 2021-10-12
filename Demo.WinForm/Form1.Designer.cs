namespace Demo.WinForm
{
    partial class Form1
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.tllueList = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.tllueListTreeList = new DevExpress.XtraTreeList.TreeList();
            this.icbeEdit = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.icbe = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tllueList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tllueListTreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbeEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.tllueList);
            this.layoutControl1.Controls.Add(this.icbeEdit);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(409, 0, 812, 500);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(843, 385);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // tllueList
            // 
            this.tllueList.Location = new System.Drawing.Point(148, 40);
            this.tllueList.Name = "tllueList";
            this.tllueList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tllueList.Properties.TreeList = this.tllueListTreeList;
            this.tllueList.Size = new System.Drawing.Size(683, 24);
            this.tllueList.StyleController = this.layoutControl1;
            this.tllueList.TabIndex = 5;
            // 
            // tllueListTreeList
            // 
            this.tllueListTreeList.Location = new System.Drawing.Point(0, 0);
            this.tllueListTreeList.Name = "tllueListTreeList";
            this.tllueListTreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.tllueListTreeList.Size = new System.Drawing.Size(400, 200);
            this.tllueListTreeList.TabIndex = 0;
            this.tllueListTreeList.CustomDrawNodeImages += new DevExpress.XtraTreeList.CustomDrawNodeImagesEventHandler(this.tllueListTreeList_CustomDrawNodeImages);
            // 
            // icbeEdit
            // 
            this.icbeEdit.Location = new System.Drawing.Point(148, 12);
            this.icbeEdit.Name = "icbeEdit";
            this.icbeEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbeEdit.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("11", "选项1", 111),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("22", "选项2", 222)});
            this.icbeEdit.Size = new System.Drawing.Size(683, 24);
            this.icbeEdit.StyleController = this.layoutControl1;
            this.icbeEdit.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.icbe,
            this.emptySpaceItem1,
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(843, 385);
            this.Root.TextVisible = false;
            // 
            // icbe
            // 
            this.icbe.Control = this.icbeEdit;
            this.icbe.CustomizationFormText = "下拉列表";
            this.icbe.Location = new System.Drawing.Point(0, 0);
            this.icbe.Name = "icbe";
            this.icbe.Size = new System.Drawing.Size(823, 28);
            this.icbe.TextSize = new System.Drawing.Size(124, 18);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 56);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(823, 309);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.tllueList;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(823, 28);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(124, 18);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 385);
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tllueList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tllueListTreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbeEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbeEdit;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem icbe;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TreeListLookUpEdit tllueList;
        private DevExpress.XtraTreeList.TreeList tllueListTreeList;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}

