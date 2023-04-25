namespace LoadOrderEditor
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.orderListPlaceholder = new System.Windows.Forms.Label();
            this.orderList = new System.Windows.Forms.Panel();
            this.loadOrderTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.optionsMoveUp = new System.Windows.Forms.Label();
            this.optionsMoveDown = new System.Windows.Forms.Label();
            this.orderOptions = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFAQ = new System.Windows.Forms.Label();
            this.btnFolder = new System.Windows.Forms.Label();
            this.dropdownMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnClearServerCache = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenOrderJson = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDeleteMod = new System.Windows.Forms.Label();
            this.hoverTip = new System.Windows.Forms.ToolTip(this.components);
            this.orderList.SuspendLayout();
            this.orderOptions.SuspendLayout();
            this.dropdownMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // orderListPlaceholder
            // 
            this.orderListPlaceholder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.orderListPlaceholder.AutoEllipsis = true;
            this.orderListPlaceholder.Location = new System.Drawing.Point(0, 2);
            this.orderListPlaceholder.Name = "orderListPlaceholder";
            this.orderListPlaceholder.Size = new System.Drawing.Size(461, 25);
            this.orderListPlaceholder.TabIndex = 0;
            this.orderListPlaceholder.Text = "Placeholder";
            this.orderListPlaceholder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // orderList
            // 
            this.orderList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.orderList.AutoScroll = true;
            this.orderList.Controls.Add(this.orderListPlaceholder);
            this.orderList.Location = new System.Drawing.Point(24, 51);
            this.orderList.Name = "orderList";
            this.orderList.Size = new System.Drawing.Size(461, 524);
            this.orderList.TabIndex = 1;
            // 
            // loadOrderTitle
            // 
            this.loadOrderTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadOrderTitle.AutoSize = true;
            this.loadOrderTitle.Location = new System.Drawing.Point(24, 19);
            this.loadOrderTitle.Name = "loadOrderTitle";
            this.loadOrderTitle.Size = new System.Drawing.Size(80, 17);
            this.loadOrderTitle.TabIndex = 2;
            this.loadOrderTitle.Text = "Load Order";
            this.loadOrderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.panel1.Location = new System.Drawing.Point(486, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 603);
            this.panel1.TabIndex = 3;
            // 
            // optionsMoveUp
            // 
            this.optionsMoveUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.optionsMoveUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.optionsMoveUp.Font = new System.Drawing.Font("Bahnschrift", 20F);
            this.optionsMoveUp.ForeColor = System.Drawing.Color.DodgerBlue;
            this.optionsMoveUp.Location = new System.Drawing.Point(2, 180);
            this.optionsMoveUp.Name = "optionsMoveUp";
            this.optionsMoveUp.Size = new System.Drawing.Size(49, 75);
            this.optionsMoveUp.TabIndex = 4;
            this.optionsMoveUp.Text = "˄";
            this.optionsMoveUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hoverTip.SetToolTip(this.optionsMoveUp, "Move the selected mod one slot up");
            this.optionsMoveUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.optionsMoveUp_MouseDown);
            this.optionsMoveUp.MouseEnter += new System.EventHandler(this.optionsMoveUp_MouseEnter);
            this.optionsMoveUp.MouseLeave += new System.EventHandler(this.optionsMoveUp_MouseLeave);
            // 
            // optionsMoveDown
            // 
            this.optionsMoveDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.optionsMoveDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.optionsMoveDown.Font = new System.Drawing.Font("Bahnschrift", 20F);
            this.optionsMoveDown.ForeColor = System.Drawing.Color.DodgerBlue;
            this.optionsMoveDown.Location = new System.Drawing.Point(2, 277);
            this.optionsMoveDown.Name = "optionsMoveDown";
            this.optionsMoveDown.Size = new System.Drawing.Size(49, 75);
            this.optionsMoveDown.TabIndex = 5;
            this.optionsMoveDown.Text = "˅";
            this.optionsMoveDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hoverTip.SetToolTip(this.optionsMoveDown, "Move the selected mod one slot down");
            this.optionsMoveDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.optionsMoveDown_MouseDown);
            this.optionsMoveDown.MouseEnter += new System.EventHandler(this.optionsMoveDown_MouseEnter);
            this.optionsMoveDown.MouseLeave += new System.EventHandler(this.optionsMoveDown_MouseLeave);
            // 
            // orderOptions
            // 
            this.orderOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.orderOptions.Controls.Add(this.btnDeleteMod);
            this.orderOptions.Controls.Add(this.btnFolder);
            this.orderOptions.Controls.Add(this.optionsMoveUp);
            this.orderOptions.Controls.Add(this.optionsMoveDown);
            this.orderOptions.Controls.Add(this.btnFAQ);
            this.orderOptions.Location = new System.Drawing.Point(493, 0);
            this.orderOptions.Name = "orderOptions";
            this.orderOptions.Size = new System.Drawing.Size(52, 575);
            this.orderOptions.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Light", 9F);
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(21, 582);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "NOTE: Mod #1 will load first, mod #2 will load 2nd, etc.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hoverTip.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // btnFAQ
            // 
            this.btnFAQ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnFAQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFAQ.Font = new System.Drawing.Font("Bahnschrift Light", 9F);
            this.btnFAQ.Location = new System.Drawing.Point(0, 10);
            this.btnFAQ.Name = "btnFAQ";
            this.btnFAQ.Size = new System.Drawing.Size(52, 35);
            this.btnFAQ.TabIndex = 8;
            this.btnFAQ.Text = "FAQ";
            this.btnFAQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hoverTip.SetToolTip(this.btnFAQ, "");
            this.btnFAQ.Click += new System.EventHandler(this.btnFAQ_Click);
            this.btnFAQ.MouseEnter += new System.EventHandler(this.btnFAQ_MouseEnter);
            this.btnFAQ.MouseLeave += new System.EventHandler(this.btnFAQ_MouseLeave);
            // 
            // btnFolder
            // 
            this.btnFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnFolder.ContextMenuStrip = this.dropdownMenu;
            this.btnFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFolder.Font = new System.Drawing.Font("Bahnschrift Light", 10F);
            this.btnFolder.Location = new System.Drawing.Point(0, 53);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(52, 35);
            this.btnFolder.TabIndex = 9;
            this.btnFolder.Text = "\\/";
            this.btnFolder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hoverTip.SetToolTip(this.btnFolder, "Open the context menu");
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            this.btnFolder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnFolder_MouseDown);
            this.btnFolder.MouseEnter += new System.EventHandler(this.btnFolder_MouseEnter);
            this.btnFolder.MouseLeave += new System.EventHandler(this.btnFolder_MouseLeave);
            // 
            // dropdownMenu
            // 
            this.dropdownMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClearServerCache,
            this.btnOpenOrderJson});
            this.dropdownMenu.Name = "dropdownMenu";
            this.dropdownMenu.Size = new System.Drawing.Size(170, 48);
            // 
            // btnClearServerCache
            // 
            this.btnClearServerCache.Name = "btnClearServerCache";
            this.btnClearServerCache.Size = new System.Drawing.Size(169, 22);
            this.btnClearServerCache.Text = "Clear server cache";
            this.btnClearServerCache.Click += new System.EventHandler(this.btnClearServerCache_Click);
            // 
            // btnOpenOrderJson
            // 
            this.btnOpenOrderJson.Name = "btnOpenOrderJson";
            this.btnOpenOrderJson.Size = new System.Drawing.Size(169, 22);
            this.btnOpenOrderJson.Text = "Open order.json";
            this.btnOpenOrderJson.Click += new System.EventHandler(this.btnOpenOrderJson_Click);
            // 
            // btnDeleteMod
            // 
            this.btnDeleteMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteMod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnDeleteMod.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteMod.Font = new System.Drawing.Font("Bahnschrift Light", 21F);
            this.btnDeleteMod.ForeColor = System.Drawing.Color.LightGray;
            this.btnDeleteMod.Location = new System.Drawing.Point(2, 533);
            this.btnDeleteMod.Name = "btnDeleteMod";
            this.btnDeleteMod.Size = new System.Drawing.Size(49, 42);
            this.btnDeleteMod.TabIndex = 10;
            this.btnDeleteMod.Text = "x";
            this.btnDeleteMod.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.hoverTip.SetToolTip(this.btnDeleteMod, "Delete the currently selected mod");
            this.btnDeleteMod.Click += new System.EventHandler(this.btnDeleteMod_Click);
            this.btnDeleteMod.MouseEnter += new System.EventHandler(this.btnDeleteMod_MouseEnter);
            this.btnDeleteMod.MouseLeave += new System.EventHandler(this.btnDeleteMod_MouseLeave);
            // 
            // hoverTip
            // 
            this.hoverTip.AutoPopDelay = 60000;
            this.hoverTip.InitialDelay = 350;
            this.hoverTip.ReshowDelay = 100;
            this.hoverTip.ShowAlways = true;
            this.hoverTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.hoverTip.ToolTipTitle = "Load Order Editor";
            // 
            // mainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(551, 604);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.orderOptions);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.loadOrderTitle);
            this.Controls.Add(this.orderList);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Bahnschrift Light", 10F);
            this.ForeColor = System.Drawing.Color.LightGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(16, 643);
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Load Order Editor";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainForm_KeyDown);
            this.orderList.ResumeLayout(false);
            this.orderOptions.ResumeLayout(false);
            this.dropdownMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label orderListPlaceholder;
        private System.Windows.Forms.Panel orderList;
        private System.Windows.Forms.Label loadOrderTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label optionsMoveUp;
        private System.Windows.Forms.Label optionsMoveDown;
        private System.Windows.Forms.Panel orderOptions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label btnFAQ;
        private System.Windows.Forms.Label btnFolder;
        private System.Windows.Forms.ContextMenuStrip dropdownMenu;
        private System.Windows.Forms.ToolStripMenuItem btnClearServerCache;
        private System.Windows.Forms.ToolStripMenuItem btnOpenOrderJson;
        private System.Windows.Forms.Label btnDeleteMod;
        private System.Windows.Forms.ToolTip hoverTip;
    }
}

