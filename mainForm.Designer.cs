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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.orderListPlaceholder = new System.Windows.Forms.Label();
            this.orderList = new System.Windows.Forms.Panel();
            this.loadOrderTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.optionsMoveUp = new System.Windows.Forms.Label();
            this.optionsMoveDown = new System.Windows.Forms.Label();
            this.orderOptions = new System.Windows.Forms.Panel();
            this.optionsModInfo = new System.Windows.Forms.Label();
            this.optionsOpenOrder = new System.Windows.Forms.Label();
            this.optionsClearCache = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFAQ = new System.Windows.Forms.Label();
            this.orderList.SuspendLayout();
            this.orderOptions.SuspendLayout();
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
            this.orderList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.orderList.AutoScroll = true;
            this.orderList.Controls.Add(this.orderListPlaceholder);
            this.orderList.Location = new System.Drawing.Point(24, 46);
            this.orderList.Name = "orderList";
            this.orderList.Size = new System.Drawing.Size(461, 529);
            this.orderList.TabIndex = 1;
            // 
            // loadOrderTitle
            // 
            this.loadOrderTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadOrderTitle.Location = new System.Drawing.Point(27, 16);
            this.loadOrderTitle.Name = "loadOrderTitle";
            this.loadOrderTitle.Size = new System.Drawing.Size(457, 22);
            this.loadOrderTitle.TabIndex = 2;
            this.loadOrderTitle.Text = "Load Order";
            this.loadOrderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(486, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 529);
            this.panel1.TabIndex = 3;
            // 
            // optionsMoveUp
            // 
            this.optionsMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsMoveUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.optionsMoveUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.optionsMoveUp.Font = new System.Drawing.Font("Bahnschrift", 20F);
            this.optionsMoveUp.ForeColor = System.Drawing.Color.DodgerBlue;
            this.optionsMoveUp.Location = new System.Drawing.Point(108, 112);
            this.optionsMoveUp.Name = "optionsMoveUp";
            this.optionsMoveUp.Size = new System.Drawing.Size(75, 75);
            this.optionsMoveUp.TabIndex = 4;
            this.optionsMoveUp.Text = "˄";
            this.optionsMoveUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.optionsMoveUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.optionsMoveUp_MouseDown);
            this.optionsMoveUp.MouseEnter += new System.EventHandler(this.optionsMoveUp_MouseEnter);
            this.optionsMoveUp.MouseLeave += new System.EventHandler(this.optionsMoveUp_MouseLeave);
            // 
            // optionsMoveDown
            // 
            this.optionsMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsMoveDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.optionsMoveDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.optionsMoveDown.Font = new System.Drawing.Font("Bahnschrift", 20F);
            this.optionsMoveDown.ForeColor = System.Drawing.Color.DodgerBlue;
            this.optionsMoveDown.Location = new System.Drawing.Point(108, 195);
            this.optionsMoveDown.Name = "optionsMoveDown";
            this.optionsMoveDown.Size = new System.Drawing.Size(75, 75);
            this.optionsMoveDown.TabIndex = 5;
            this.optionsMoveDown.Text = "˅";
            this.optionsMoveDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.optionsMoveDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.optionsMoveDown_MouseDown);
            this.optionsMoveDown.MouseEnter += new System.EventHandler(this.optionsMoveDown_MouseEnter);
            this.optionsMoveDown.MouseLeave += new System.EventHandler(this.optionsMoveDown_MouseLeave);
            // 
            // orderOptions
            // 
            this.orderOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.orderOptions.Controls.Add(this.optionsModInfo);
            this.orderOptions.Controls.Add(this.optionsOpenOrder);
            this.orderOptions.Controls.Add(this.optionsClearCache);
            this.orderOptions.Controls.Add(this.optionsMoveUp);
            this.orderOptions.Controls.Add(this.optionsMoveDown);
            this.orderOptions.Location = new System.Drawing.Point(502, 46);
            this.orderOptions.Name = "orderOptions";
            this.orderOptions.Size = new System.Drawing.Size(290, 529);
            this.orderOptions.TabIndex = 6;
            // 
            // optionsModInfo
            // 
            this.optionsModInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsModInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.optionsModInfo.Font = new System.Drawing.Font("Bahnschrift Light", 9F);
            this.optionsModInfo.Location = new System.Drawing.Point(3, 299);
            this.optionsModInfo.Name = "optionsModInfo";
            this.optionsModInfo.Size = new System.Drawing.Size(284, 114);
            this.optionsModInfo.TabIndex = 8;
            this.optionsModInfo.Text = "Mod name: N/A\r\n\r\n\r\nMod version: N/A\r\n\r\n\r\nMod author: N/A";
            this.optionsModInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // optionsOpenOrder
            // 
            this.optionsOpenOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsOpenOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.optionsOpenOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.optionsOpenOrder.Font = new System.Drawing.Font("Bahnschrift Light", 9F);
            this.optionsOpenOrder.Location = new System.Drawing.Point(3, 41);
            this.optionsOpenOrder.Name = "optionsOpenOrder";
            this.optionsOpenOrder.Size = new System.Drawing.Size(284, 37);
            this.optionsOpenOrder.TabIndex = 7;
            this.optionsOpenOrder.Text = "   Open order.json with default editor";
            this.optionsOpenOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.optionsOpenOrder.Click += new System.EventHandler(this.optionsOpenOrder_Click);
            this.optionsOpenOrder.MouseEnter += new System.EventHandler(this.optionsOpenOrder_MouseEnter);
            this.optionsOpenOrder.MouseLeave += new System.EventHandler(this.optionsOpenOrder_MouseLeave);
            // 
            // optionsClearCache
            // 
            this.optionsClearCache.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsClearCache.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.optionsClearCache.Cursor = System.Windows.Forms.Cursors.Hand;
            this.optionsClearCache.Font = new System.Drawing.Font("Bahnschrift Light", 9F);
            this.optionsClearCache.Location = new System.Drawing.Point(3, 1);
            this.optionsClearCache.Name = "optionsClearCache";
            this.optionsClearCache.Size = new System.Drawing.Size(284, 37);
            this.optionsClearCache.TabIndex = 6;
            this.optionsClearCache.Text = "   Clear cache";
            this.optionsClearCache.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.optionsClearCache.Click += new System.EventHandler(this.optionsClearCache_Click);
            this.optionsClearCache.MouseEnter += new System.EventHandler(this.optionsClearCache_MouseEnter);
            this.optionsClearCache.MouseLeave += new System.EventHandler(this.optionsClearCache_MouseLeave);
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
            // 
            // btnFAQ
            // 
            this.btnFAQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFAQ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnFAQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFAQ.Font = new System.Drawing.Font("Bahnschrift Light", 9F);
            this.btnFAQ.Location = new System.Drawing.Point(754, 8);
            this.btnFAQ.Name = "btnFAQ";
            this.btnFAQ.Size = new System.Drawing.Size(35, 30);
            this.btnFAQ.TabIndex = 8;
            this.btnFAQ.Text = "FAQ";
            this.btnFAQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnFAQ.Click += new System.EventHandler(this.btnFAQ_Click);
            this.btnFAQ.MouseEnter += new System.EventHandler(this.btnFAQ_MouseEnter);
            this.btnFAQ.MouseLeave += new System.EventHandler(this.btnFAQ_MouseLeave);
            // 
            // mainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(804, 604);
            this.Controls.Add(this.btnFAQ);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.orderOptions);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.loadOrderTitle);
            this.Controls.Add(this.orderList);
            this.Font = new System.Drawing.Font("Bahnschrift Light", 10F);
            this.ForeColor = System.Drawing.Color.LightGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(692, 527);
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Load Order Editor";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainForm_KeyDown);
            this.orderList.ResumeLayout(false);
            this.orderOptions.ResumeLayout(false);
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
        private System.Windows.Forms.Label optionsClearCache;
        private System.Windows.Forms.Label optionsOpenOrder;
        private System.Windows.Forms.Label optionsModInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label btnFAQ;
    }
}

