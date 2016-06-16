namespace CopyOneByOne
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.lblSortBy = new System.Windows.Forms.Label();
            this.cbxSortBy = new System.Windows.Forms.ComboBox();
            this.chkRepeat = new System.Windows.Forms.CheckBox();
            this.lvViewShortcut = new System.Windows.Forms.ListView();
            this.lvRecentlyCopied = new System.Windows.Forms.ListView();
            this.lblWidgets = new System.Windows.Forms.Label();
            this.lbWidgets = new System.Windows.Forms.CheckedListBox();
            this.chkAutoMinimize = new System.Windows.Forms.CheckBox();
            this.tltpMsg = new System.Windows.Forms.ToolTip(this.components);
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.lvShortcuts = new System.Windows.Forms.ListView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSortBy
            // 
            this.lblSortBy.AutoSize = true;
            this.lblSortBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSortBy.Location = new System.Drawing.Point(704, 26);
            this.lblSortBy.Name = "lblSortBy";
            this.lblSortBy.Size = new System.Drawing.Size(43, 14);
            this.lblSortBy.TabIndex = 9;
            this.lblSortBy.Text = "Sort By";
            // 
            // cbxSortBy
            // 
            this.cbxSortBy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbxSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSortBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSortBy.FormattingEnabled = true;
            this.cbxSortBy.Items.AddRange(new object[] {
            "Name",
            "Created On"});
            this.cbxSortBy.Location = new System.Drawing.Point(751, 21);
            this.cbxSortBy.Name = "cbxSortBy";
            this.cbxSortBy.Size = new System.Drawing.Size(121, 22);
            this.cbxSortBy.TabIndex = 10;
            this.cbxSortBy.SelectedIndexChanged += new System.EventHandler(this.cbxSortBy_SelectedIndexChanged);
            // 
            // chkRepeat
            // 
            this.chkRepeat.AutoSize = true;
            this.chkRepeat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkRepeat.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRepeat.Location = new System.Drawing.Point(637, 25);
            this.chkRepeat.Name = "chkRepeat";
            this.chkRepeat.Size = new System.Drawing.Size(65, 18);
            this.chkRepeat.TabIndex = 8;
            this.chkRepeat.Text = "Repeat";
            this.chkRepeat.UseVisualStyleBackColor = true;
            this.chkRepeat.CheckedChanged += new System.EventHandler(this.chkRepeat_CheckedChanged);
            // 
            // lvViewShortcut
            // 
            this.lvViewShortcut.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvViewShortcut.BackColor = System.Drawing.Color.MistyRose;
            this.lvViewShortcut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvViewShortcut.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvViewShortcut.GridLines = true;
            this.lvViewShortcut.Location = new System.Drawing.Point(725, 268);
            this.lvViewShortcut.MultiSelect = false;
            this.lvViewShortcut.Name = "lvViewShortcut";
            this.lvViewShortcut.Size = new System.Drawing.Size(147, 202);
            this.lvViewShortcut.TabIndex = 13;
            this.lvViewShortcut.TileSize = new System.Drawing.Size(147, 20);
            this.lvViewShortcut.UseCompatibleStateImageBehavior = false;
            this.lvViewShortcut.View = System.Windows.Forms.View.Tile;
            this.lvViewShortcut.ItemActivate += new System.EventHandler(this.lvViewShortcut_ItemActivate);
            // 
            // lvRecentlyCopied
            // 
            this.lvRecentlyCopied.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvRecentlyCopied.BackColor = System.Drawing.Color.LemonChiffon;
            this.lvRecentlyCopied.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvRecentlyCopied.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvRecentlyCopied.GridLines = true;
            this.lvRecentlyCopied.Location = new System.Drawing.Point(725, 60);
            this.lvRecentlyCopied.MultiSelect = false;
            this.lvRecentlyCopied.Name = "lvRecentlyCopied";
            this.lvRecentlyCopied.Size = new System.Drawing.Size(147, 202);
            this.lvRecentlyCopied.TabIndex = 12;
            this.lvRecentlyCopied.TileSize = new System.Drawing.Size(147, 20);
            this.lvRecentlyCopied.UseCompatibleStateImageBehavior = false;
            this.lvRecentlyCopied.View = System.Windows.Forms.View.Tile;
            this.lvRecentlyCopied.ItemActivate += new System.EventHandler(this.lvRecentlyCopied_ItemActivate);
            // 
            // lblWidgets
            // 
            this.lblWidgets.AutoSize = true;
            this.lblWidgets.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWidgets.Location = new System.Drawing.Point(336, 21);
            this.lblWidgets.Name = "lblWidgets";
            this.lblWidgets.Size = new System.Drawing.Size(60, 18);
            this.lblWidgets.TabIndex = 5;
            this.lblWidgets.Text = "Widgets";
            // 
            // lbWidgets
            // 
            this.lbWidgets.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.lbWidgets.CheckOnClick = true;
            this.lbWidgets.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbWidgets.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWidgets.FormattingEnabled = true;
            this.lbWidgets.Items.AddRange(new object[] {
            "Recently Copied",
            "View Snippet"});
            this.lbWidgets.Location = new System.Drawing.Point(403, 13);
            this.lbWidgets.Name = "lbWidgets";
            this.lbWidgets.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbWidgets.Size = new System.Drawing.Size(121, 38);
            this.lbWidgets.TabIndex = 6;
            this.lbWidgets.ThreeDCheckBoxes = true;
            this.lbWidgets.SelectedIndexChanged += new System.EventHandler(this.lbWidgets_SelectedIndexChanged);
            // 
            // chkAutoMinimize
            // 
            this.chkAutoMinimize.AutoSize = true;
            this.chkAutoMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkAutoMinimize.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoMinimize.Location = new System.Drawing.Point(530, 25);
            this.chkAutoMinimize.Name = "chkAutoMinimize";
            this.chkAutoMinimize.Size = new System.Drawing.Size(105, 18);
            this.chkAutoMinimize.TabIndex = 7;
            this.chkAutoMinimize.Text = "Auto Minimize";
            this.chkAutoMinimize.UseVisualStyleBackColor = true;
            // 
            // btnSettings
            // 
            this.btnSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSettings.BackgroundImage")));
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Location = new System.Drawing.Point(126, 12);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(32, 32);
            this.btnSettings.TabIndex = 4;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnReload
            // 
            this.btnReload.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReload.BackgroundImage")));
            this.btnReload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.Location = new System.Drawing.Point(164, 12);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(32, 32);
            this.btnReload.TabIndex = 3;
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Visible = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // lvShortcuts
            // 
            this.lvShortcuts.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvShortcuts.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.lvShortcuts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvShortcuts.Cursor = System.Windows.Forms.Cursors.Default;
            this.lvShortcuts.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvShortcuts.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lvShortcuts.GridLines = true;
            this.lvShortcuts.Location = new System.Drawing.Point(13, 60);
            this.lvShortcuts.MultiSelect = false;
            this.lvShortcuts.Name = "lvShortcuts";
            this.lvShortcuts.Size = new System.Drawing.Size(705, 410);
            this.lvShortcuts.TabIndex = 11;
            this.lvShortcuts.TileSize = new System.Drawing.Size(100, 50);
            this.lvShortcuts.UseCompatibleStateImageBehavior = false;
            this.lvShortcuts.View = System.Windows.Forms.View.Tile;
            this.lvShortcuts.ItemActivate += new System.EventHandler(this.lvShortcuts_ItemActivate);
            this.lvShortcuts.SelectedIndexChanged += new System.EventHandler(this.lvShortcuts_SelectedIndexChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(88, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(32, 32);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUpdate.BackgroundImage")));
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdate.Location = new System.Drawing.Point(50, 12);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(32, 32);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCreate.BackgroundImage = global::CopyOneByOne.Properties.Resources.create;
            this.btnCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCreate.Location = new System.Drawing.Point(12, 13);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(32, 32);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(884, 494);
            this.Controls.Add(this.chkAutoMinimize);
            this.Controls.Add(this.lbWidgets);
            this.Controls.Add(this.lblWidgets);
            this.Controls.Add(this.lvRecentlyCopied);
            this.Controls.Add(this.lvViewShortcut);
            this.Controls.Add(this.chkRepeat);
            this.Controls.Add(this.cbxSortBy);
            this.Controls.Add(this.lblSortBy);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.lvShortcuts);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCreate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Copy 1/1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListView lvShortcuts;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label lblSortBy;
        private System.Windows.Forms.ComboBox cbxSortBy;
        private System.Windows.Forms.CheckBox chkRepeat;
        private System.Windows.Forms.ListView lvViewShortcut;
        private System.Windows.Forms.ListView lvRecentlyCopied;
        private System.Windows.Forms.Label lblWidgets;
        private System.Windows.Forms.CheckedListBox lbWidgets;
        private System.Windows.Forms.CheckBox chkAutoMinimize;
        private System.Windows.Forms.ToolTip tltpMsg;


    }
}

