namespace ActiveRecordGenerator
{
	partial class GeneratorForm
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
			this.btnConnect = new System.Windows.Forms.Button();
			this.txtServer = new System.Windows.Forms.TextBox();
			this.txtDatabase = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.chkLbTables = new System.Windows.Forms.CheckedListBox();
			this.btnTablesSelectAll = new System.Windows.Forms.Button();
			this.btnTablesSelectNone = new System.Windows.Forms.Button();
			this.btnGenerate = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtOutputDir = new System.Windows.Forms.TextBox();
			this.chkPartial = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.chkPropChange = new System.Windows.Forms.CheckBox();
			this.txtNameSpace = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.chkBizPartial = new System.Windows.Forms.CheckBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tsStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.tsProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.btnClose = new System.Windows.Forms.Button();
			this.chkLbTemplates = new System.Windows.Forms.CheckedListBox();
			this.btnTemplatesSelectNone = new System.Windows.Forms.Button();
			this.btnTemplatesSelectAll = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(317, 12);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(73, 48);
			this.btnConnect.TabIndex = 0;
			this.btnConnect.Text = "Connect and Scan";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// txtServer
			// 
			this.txtServer.Location = new System.Drawing.Point(101, 12);
			this.txtServer.Name = "txtServer";
			this.txtServer.Size = new System.Drawing.Size(210, 20);
			this.txtServer.TabIndex = 1;
			// 
			// txtDatabase
			// 
			this.txtDatabase.Location = new System.Drawing.Point(101, 38);
			this.txtDatabase.Name = "txtDatabase";
			this.txtDatabase.Size = new System.Drawing.Size(210, 20);
			this.txtDatabase.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(51, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Server";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(36, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Database";
			// 
			// chkLbTables
			// 
			this.chkLbTables.CheckOnClick = true;
			this.chkLbTables.FormattingEnabled = true;
			this.chkLbTables.Location = new System.Drawing.Point(415, 28);
			this.chkLbTables.Name = "chkLbTables";
			this.chkLbTables.Size = new System.Drawing.Size(214, 289);
			this.chkLbTables.Sorted = true;
			this.chkLbTables.TabIndex = 5;
			// 
			// btnTablesSelectAll
			// 
			this.btnTablesSelectAll.Location = new System.Drawing.Point(635, 28);
			this.btnTablesSelectAll.Name = "btnTablesSelectAll";
			this.btnTablesSelectAll.Size = new System.Drawing.Size(75, 23);
			this.btnTablesSelectAll.TabIndex = 6;
			this.btnTablesSelectAll.Text = "Select All";
			this.btnTablesSelectAll.UseVisualStyleBackColor = true;
			this.btnTablesSelectAll.Click += new System.EventHandler(this.btnTablesSelectAll_Click);
			// 
			// btnTablesSelectNone
			// 
			this.btnTablesSelectNone.Location = new System.Drawing.Point(635, 57);
			this.btnTablesSelectNone.Name = "btnTablesSelectNone";
			this.btnTablesSelectNone.Size = new System.Drawing.Size(75, 23);
			this.btnTablesSelectNone.TabIndex = 7;
			this.btnTablesSelectNone.Text = "Select None";
			this.btnTablesSelectNone.UseVisualStyleBackColor = true;
			this.btnTablesSelectNone.Click += new System.EventHandler(this.btnTablesSelectNone_Click);
			// 
			// btnGenerate
			// 
			this.btnGenerate.Location = new System.Drawing.Point(635, 86);
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.Size = new System.Drawing.Size(75, 23);
			this.btnGenerate.TabIndex = 8;
			this.btnGenerate.Text = "Generate";
			this.btnGenerate.UseVisualStyleBackColor = true;
			this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(412, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(91, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Tables and Views";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(5, 67);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(84, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Output Directory";
			// 
			// txtOutputDir
			// 
			this.txtOutputDir.Location = new System.Drawing.Point(101, 64);
			this.txtOutputDir.Name = "txtOutputDir";
			this.txtOutputDir.Size = new System.Drawing.Size(289, 20);
			this.txtOutputDir.TabIndex = 11;
			// 
			// chkPartial
			// 
			this.chkPartial.AutoSize = true;
			this.chkPartial.Checked = true;
			this.chkPartial.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkPartial.Location = new System.Drawing.Point(100, 89);
			this.chkPartial.Name = "chkPartial";
			this.chkPartial.Size = new System.Drawing.Size(55, 17);
			this.chkPartial.TabIndex = 12;
			this.chkPartial.Text = "Partial";
			this.chkPartial.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(18, 90);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(71, 13);
			this.label5.TabIndex = 13;
			this.label5.Text = "Class Options";
			// 
			// chkPropChange
			// 
			this.chkPropChange.AutoSize = true;
			this.chkPropChange.Checked = true;
			this.chkPropChange.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkPropChange.Location = new System.Drawing.Point(161, 89);
			this.chkPropChange.Name = "chkPropChange";
			this.chkPropChange.Size = new System.Drawing.Size(98, 17);
			this.chkPropChange.TabIndex = 14;
			this.chkPropChange.Text = "PropertyEvents";
			this.chkPropChange.UseVisualStyleBackColor = true;
			// 
			// txtNameSpace
			// 
			this.txtNameSpace.Location = new System.Drawing.Point(101, 113);
			this.txtNameSpace.Name = "txtNameSpace";
			this.txtNameSpace.Size = new System.Drawing.Size(289, 20);
			this.txtNameSpace.TabIndex = 15;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(25, 116);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 13);
			this.label6.TabIndex = 16;
			this.label6.Text = "Namespace";
			// 
			// chkBizPartial
			// 
			this.chkBizPartial.AutoSize = true;
			this.chkBizPartial.Location = new System.Drawing.Point(265, 89);
			this.chkBizPartial.Name = "chkBizPartial";
			this.chkBizPartial.Size = new System.Drawing.Size(94, 17);
			this.chkBizPartial.TabIndex = 17;
			this.chkBizPartial.Text = "Partial Classes";
			this.chkBizPartial.UseVisualStyleBackColor = true;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatus,
            this.tsProgressBar});
			this.statusStrip1.Location = new System.Drawing.Point(0, 335);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(735, 22);
			this.statusStrip1.TabIndex = 18;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tsStatus
			// 
			this.tsStatus.Name = "tsStatus";
			this.tsStatus.Size = new System.Drawing.Size(618, 17);
			this.tsStatus.Spring = true;
			// 
			// tsProgressBar
			// 
			this.tsProgressBar.Name = "tsProgressBar";
			this.tsProgressBar.Size = new System.Drawing.Size(100, 16);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(635, 115);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 19;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// chkLbTemplates
			// 
			this.chkLbTemplates.CheckOnClick = true;
			this.chkLbTemplates.FormattingEnabled = true;
			this.chkLbTemplates.Location = new System.Drawing.Point(16, 163);
			this.chkLbTemplates.Name = "chkLbTemplates";
			this.chkLbTemplates.Size = new System.Drawing.Size(295, 154);
			this.chkLbTemplates.Sorted = true;
			this.chkLbTemplates.TabIndex = 20;
			// 
			// btnTemplatesSelectNone
			// 
			this.btnTemplatesSelectNone.Location = new System.Drawing.Point(317, 192);
			this.btnTemplatesSelectNone.Name = "btnTemplatesSelectNone";
			this.btnTemplatesSelectNone.Size = new System.Drawing.Size(75, 23);
			this.btnTemplatesSelectNone.TabIndex = 22;
			this.btnTemplatesSelectNone.Text = "Select None";
			this.btnTemplatesSelectNone.UseVisualStyleBackColor = true;
			this.btnTemplatesSelectNone.Click += new System.EventHandler(this.btnTemplatesSelectNone_Click);
			// 
			// btnTemplatesSelectAll
			// 
			this.btnTemplatesSelectAll.Location = new System.Drawing.Point(317, 163);
			this.btnTemplatesSelectAll.Name = "btnTemplatesSelectAll";
			this.btnTemplatesSelectAll.Size = new System.Drawing.Size(75, 23);
			this.btnTemplatesSelectAll.TabIndex = 21;
			this.btnTemplatesSelectAll.Text = "Select All";
			this.btnTemplatesSelectAll.UseVisualStyleBackColor = true;
			this.btnTemplatesSelectAll.Click += new System.EventHandler(this.btnTemplatesSelectAll_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(15, 144);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 13);
			this.label7.TabIndex = 23;
			this.label7.Text = "Templates";
			// 
			// GeneratorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(735, 357);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.btnTemplatesSelectNone);
			this.Controls.Add(this.btnTemplatesSelectAll);
			this.Controls.Add(this.chkLbTemplates);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.chkBizPartial);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtNameSpace);
			this.Controls.Add(this.chkPropChange);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.chkPartial);
			this.Controls.Add(this.txtOutputDir);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnGenerate);
			this.Controls.Add(this.btnTablesSelectNone);
			this.Controls.Add(this.btnTablesSelectAll);
			this.Controls.Add(this.chkLbTables);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtDatabase);
			this.Controls.Add(this.txtServer);
			this.Controls.Add(this.btnConnect);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "GeneratorForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Active Record Class Generator";
			this.Load += new System.EventHandler(this.GeneratorForm_Load);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.TextBox txtServer;
		private System.Windows.Forms.TextBox txtDatabase;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckedListBox chkLbTables;
		private System.Windows.Forms.Button btnTablesSelectAll;
		private System.Windows.Forms.Button btnTablesSelectNone;
		private System.Windows.Forms.Button btnGenerate;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtOutputDir;
		private System.Windows.Forms.CheckBox chkPartial;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox chkPropChange;
		private System.Windows.Forms.TextBox txtNameSpace;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox chkBizPartial;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel tsStatus;
		private System.Windows.Forms.ToolStripProgressBar tsProgressBar;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.CheckedListBox chkLbTemplates;
		private System.Windows.Forms.Button btnTemplatesSelectNone;
		private System.Windows.Forms.Button btnTemplatesSelectAll;
		private System.Windows.Forms.Label label7;
	}
}

