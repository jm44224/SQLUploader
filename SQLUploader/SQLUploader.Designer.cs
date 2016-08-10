namespace SQLUploader
{
    partial class SQLUploader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SQLUploader));
            this.btnBrowseSqlToUpload = new System.Windows.Forms.Button();
            this.sqlFileName = new System.Windows.Forms.TextBox();
            this.databaseList = new System.Windows.Forms.CheckedListBox();
            this.gbxOptions = new System.Windows.Forms.GroupBox();
            this.lblNumberDatabasesSelected = new System.Windows.Forms.Label();
            this.tbCheckLike = new System.Windows.Forms.TextBox();
            this.chkAllDatabasesLike = new System.Windows.Forms.CheckBox();
            this.chkAllDatabases = new System.Windows.Forms.CheckBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblUserPassword = new System.Windows.Forms.Label();
            this.lblUserLogin = new System.Windows.Forms.Label();
            this.lblServerName = new System.Windows.Forms.Label();
            this.gbxSelectDatabaseServer = new System.Windows.Forms.GroupBox();
            this.lblTimeout = new System.Windows.Forms.Label();
            this.ddlTimeout = new System.Windows.Forms.ComboBox();
            this.trustedConnection = new System.Windows.Forms.CheckBox();
            this.serverNameList = new System.Windows.Forms.ComboBox();
            this.lblRefreshButton = new System.Windows.Forms.Label();
            this.userPassword = new System.Windows.Forms.TextBox();
            this.userLogin = new System.Windows.Forms.TextBox();
            this.gbxSqlToUpload = new System.Windows.Forms.GroupBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.gbxResults = new System.Windows.Forms.GroupBox();
            this.gbxOptions.SuspendLayout();
            this.gbxSelectDatabaseServer.SuspendLayout();
            this.gbxSqlToUpload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.gbxResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowseSqlToUpload
            // 
            this.btnBrowseSqlToUpload.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBrowseSqlToUpload.Location = new System.Drawing.Point(304, 26);
            this.btnBrowseSqlToUpload.Margin = new System.Windows.Forms.Padding(2);
            this.btnBrowseSqlToUpload.Name = "btnBrowseSqlToUpload";
            this.btnBrowseSqlToUpload.Size = new System.Drawing.Size(56, 21);
            this.btnBrowseSqlToUpload.TabIndex = 1;
            this.btnBrowseSqlToUpload.Text = "Browse ...";
            this.btnBrowseSqlToUpload.Click += new System.EventHandler(this.btnBrowseSqlToUpload_Click);
            // 
            // sqlFileName
            // 
            this.sqlFileName.AllowDrop = true;
            this.sqlFileName.Location = new System.Drawing.Point(12, 26);
            this.sqlFileName.Margin = new System.Windows.Forms.Padding(2);
            this.sqlFileName.Name = "sqlFileName";
            this.sqlFileName.ReadOnly = true;
            this.sqlFileName.Size = new System.Drawing.Size(275, 20);
            this.sqlFileName.TabIndex = 0;
            this.sqlFileName.TabStop = false;
            this.sqlFileName.DragDrop += new System.Windows.Forms.DragEventHandler(this.sqlFileName_DragDrop);
            this.sqlFileName.DragOver += new System.Windows.Forms.DragEventHandler(this.sqlFileName_DragOver);
            // 
            // databaseList
            // 
            this.databaseList.CheckOnClick = true;
            this.databaseList.Location = new System.Drawing.Point(12, 35);
            this.databaseList.Margin = new System.Windows.Forms.Padding(2);
            this.databaseList.Name = "databaseList";
            this.databaseList.Size = new System.Drawing.Size(349, 94);
            this.databaseList.Sorted = true;
            this.databaseList.TabIndex = 3;
            this.databaseList.Validating += new System.ComponentModel.CancelEventHandler(this.databaseList_Validating);
            this.databaseList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.databaseList_MouseUp);
            this.databaseList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.databaseList_KeyUp);
            // 
            // gbxOptions
            // 
            this.gbxOptions.Controls.Add(this.lblNumberDatabasesSelected);
            this.gbxOptions.Controls.Add(this.tbCheckLike);
            this.gbxOptions.Controls.Add(this.chkAllDatabasesLike);
            this.gbxOptions.Controls.Add(this.chkAllDatabases);
            this.gbxOptions.Controls.Add(this.databaseList);
            this.gbxOptions.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.gbxOptions.Location = new System.Drawing.Point(9, 233);
            this.gbxOptions.Margin = new System.Windows.Forms.Padding(2);
            this.gbxOptions.Name = "gbxOptions";
            this.gbxOptions.Padding = new System.Windows.Forms.Padding(2);
            this.gbxOptions.Size = new System.Drawing.Size(378, 162);
            this.gbxOptions.TabIndex = 2;
            this.gbxOptions.TabStop = false;
            this.gbxOptions.Text = "Select Databases";
            // 
            // lblNumberDatabasesSelected
            // 
            this.lblNumberDatabasesSelected.AutoSize = true;
            this.lblNumberDatabasesSelected.Location = new System.Drawing.Point(12, 135);
            this.lblNumberDatabasesSelected.Name = "lblNumberDatabasesSelected";
            this.lblNumberDatabasesSelected.Size = new System.Drawing.Size(0, 13);
            this.lblNumberDatabasesSelected.TabIndex = 4;
            // 
            // tbCheckLike
            // 
            this.tbCheckLike.Location = new System.Drawing.Point(179, 13);
            this.tbCheckLike.Name = "tbCheckLike";
            this.tbCheckLike.Size = new System.Drawing.Size(181, 20);
            this.tbCheckLike.TabIndex = 2;
            this.tbCheckLike.TextChanged += new System.EventHandler(this.tbCheckLike_TextChanged);
            // 
            // chkAllDatabasesLike
            // 
            this.chkAllDatabasesLike.AutoSize = true;
            this.chkAllDatabasesLike.Location = new System.Drawing.Point(102, 16);
            this.chkAllDatabasesLike.Name = "chkAllDatabasesLike";
            this.chkAllDatabasesLike.Size = new System.Drawing.Size(80, 17);
            this.chkAllDatabasesLike.TabIndex = 1;
            this.chkAllDatabasesLike.Text = "Check Like";
            this.chkAllDatabasesLike.UseVisualStyleBackColor = true;
            this.chkAllDatabasesLike.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chkAllDatabasesLike_MouseUp);
            // 
            // chkAllDatabases
            // 
            this.chkAllDatabases.AutoSize = true;
            this.chkAllDatabases.Location = new System.Drawing.Point(15, 16);
            this.chkAllDatabases.Name = "chkAllDatabases";
            this.chkAllDatabases.Size = new System.Drawing.Size(71, 17);
            this.chkAllDatabases.TabIndex = 0;
            this.chkAllDatabases.Text = "Check All";
            this.chkAllDatabases.UseVisualStyleBackColor = true;
            this.chkAllDatabases.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chkAllDatabases_MouseUp);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(252, 562);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(56, 21);
            this.btnUpload.TabIndex = 4;
            this.btnUpload.Text = "Upload";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(313, 562);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 21);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRefresh.Location = new System.Drawing.Point(304, 124);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(56, 21);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblUserPassword
            // 
            this.lblUserPassword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUserPassword.Location = new System.Drawing.Point(10, 98);
            this.lblUserPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserPassword.Name = "lblUserPassword";
            this.lblUserPassword.Size = new System.Drawing.Size(88, 21);
            this.lblUserPassword.TabIndex = 7;
            this.lblUserPassword.Text = "User Password";
            this.lblUserPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUserLogin
            // 
            this.lblUserLogin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUserLogin.Location = new System.Drawing.Point(10, 72);
            this.lblUserLogin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserLogin.Name = "lblUserLogin";
            this.lblUserLogin.Size = new System.Drawing.Size(88, 21);
            this.lblUserLogin.TabIndex = 5;
            this.lblUserLogin.Text = "User Login";
            this.lblUserLogin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblServerName
            // 
            this.lblServerName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblServerName.Location = new System.Drawing.Point(10, 22);
            this.lblServerName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(88, 21);
            this.lblServerName.TabIndex = 0;
            this.lblServerName.Text = "Server Name";
            this.lblServerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbxSelectDatabaseServer
            // 
            this.gbxSelectDatabaseServer.Controls.Add(this.lblTimeout);
            this.gbxSelectDatabaseServer.Controls.Add(this.ddlTimeout);
            this.gbxSelectDatabaseServer.Controls.Add(this.trustedConnection);
            this.gbxSelectDatabaseServer.Controls.Add(this.serverNameList);
            this.gbxSelectDatabaseServer.Controls.Add(this.lblRefreshButton);
            this.gbxSelectDatabaseServer.Controls.Add(this.btnRefresh);
            this.gbxSelectDatabaseServer.Controls.Add(this.lblUserPassword);
            this.gbxSelectDatabaseServer.Controls.Add(this.lblUserLogin);
            this.gbxSelectDatabaseServer.Controls.Add(this.lblServerName);
            this.gbxSelectDatabaseServer.Controls.Add(this.userPassword);
            this.gbxSelectDatabaseServer.Controls.Add(this.userLogin);
            this.gbxSelectDatabaseServer.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.gbxSelectDatabaseServer.Location = new System.Drawing.Point(9, 74);
            this.gbxSelectDatabaseServer.Margin = new System.Windows.Forms.Padding(2);
            this.gbxSelectDatabaseServer.Name = "gbxSelectDatabaseServer";
            this.gbxSelectDatabaseServer.Padding = new System.Windows.Forms.Padding(2);
            this.gbxSelectDatabaseServer.Size = new System.Drawing.Size(378, 154);
            this.gbxSelectDatabaseServer.TabIndex = 1;
            this.gbxSelectDatabaseServer.TabStop = false;
            this.gbxSelectDatabaseServer.Text = "Enter Database Server Information";
            // 
            // lblTimeout
            // 
            this.lblTimeout.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTimeout.Location = new System.Drawing.Point(259, 48);
            this.lblTimeout.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTimeout.Name = "lblTimeout";
            this.lblTimeout.Size = new System.Drawing.Size(56, 21);
            this.lblTimeout.TabIndex = 3;
            this.lblTimeout.Text = "Timeout";
            this.lblTimeout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ddlTimeout
            // 
            this.ddlTimeout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTimeout.FormattingEnabled = true;
            this.ddlTimeout.Items.AddRange(new object[] {
            "0",
            "15",
            "30",
            "60",
            "120",
            "180",
            "300"});
            this.ddlTimeout.Location = new System.Drawing.Point(317, 48);
            this.ddlTimeout.Name = "ddlTimeout";
            this.ddlTimeout.Size = new System.Drawing.Size(43, 21);
            this.ddlTimeout.TabIndex = 4;
            // 
            // trustedConnection
            // 
            this.trustedConnection.AutoSize = true;
            this.trustedConnection.Location = new System.Drawing.Point(102, 50);
            this.trustedConnection.Margin = new System.Windows.Forms.Padding(2);
            this.trustedConnection.Name = "trustedConnection";
            this.trustedConnection.Size = new System.Drawing.Size(119, 17);
            this.trustedConnection.TabIndex = 2;
            this.trustedConnection.Text = "Trusted Connection";
            this.trustedConnection.UseVisualStyleBackColor = true;
            this.trustedConnection.CheckedChanged += new System.EventHandler(this.trustedConnection_CheckedChanged);
            // 
            // serverNameList
            // 
            this.serverNameList.FormattingEnabled = true;
            this.serverNameList.Location = new System.Drawing.Point(102, 22);
            this.serverNameList.Margin = new System.Windows.Forms.Padding(2);
            this.serverNameList.Name = "serverNameList";
            this.serverNameList.Size = new System.Drawing.Size(259, 21);
            this.serverNameList.TabIndex = 1;
            this.serverNameList.Validating += new System.ComponentModel.CancelEventHandler(this.serverNameList_Validating);
            this.serverNameList.SelectedIndexChanged += new System.EventHandler(this.serverNameList_SelectedIndexChanged);
            // 
            // lblRefreshButton
            // 
            this.lblRefreshButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRefreshButton.Location = new System.Drawing.Point(10, 124);
            this.lblRefreshButton.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRefreshButton.Name = "lblRefreshButton";
            this.lblRefreshButton.Size = new System.Drawing.Size(276, 21);
            this.lblRefreshButton.TabIndex = 9;
            this.lblRefreshButton.Text = "Click the Refresh button to refresh the database list below.";
            this.lblRefreshButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // userPassword
            // 
            this.userPassword.Location = new System.Drawing.Point(102, 98);
            this.userPassword.Margin = new System.Windows.Forms.Padding(2);
            this.userPassword.Name = "userPassword";
            this.userPassword.PasswordChar = '*';
            this.userPassword.Size = new System.Drawing.Size(259, 20);
            this.userPassword.TabIndex = 8;
            this.userPassword.TextChanged += new System.EventHandler(this.userPassword_TextChanged);
            this.userPassword.Validating += new System.ComponentModel.CancelEventHandler(this.userPassword_Validating);
            // 
            // userLogin
            // 
            this.userLogin.Location = new System.Drawing.Point(102, 72);
            this.userLogin.Margin = new System.Windows.Forms.Padding(2);
            this.userLogin.Name = "userLogin";
            this.userLogin.Size = new System.Drawing.Size(259, 20);
            this.userLogin.TabIndex = 6;
            this.userLogin.TextChanged += new System.EventHandler(this.userLogin_TextChanged);
            this.userLogin.Validating += new System.ComponentModel.CancelEventHandler(this.userLogin_Validating);
            // 
            // gbxSqlToUpload
            // 
            this.gbxSqlToUpload.Controls.Add(this.btnBrowseSqlToUpload);
            this.gbxSqlToUpload.Controls.Add(this.sqlFileName);
            this.gbxSqlToUpload.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.gbxSqlToUpload.Location = new System.Drawing.Point(9, 9);
            this.gbxSqlToUpload.Margin = new System.Windows.Forms.Padding(2);
            this.gbxSqlToUpload.Name = "gbxSqlToUpload";
            this.gbxSqlToUpload.Padding = new System.Windows.Forms.Padding(2);
            this.gbxSqlToUpload.Size = new System.Drawing.Size(378, 58);
            this.gbxSqlToUpload.TabIndex = 0;
            this.gbxSqlToUpload.TabStop = false;
            this.gbxSqlToUpload.Text = "Select a SQL To Upload";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 18);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(2);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessage.Size = new System.Drawing.Size(349, 109);
            this.txtMessage.TabIndex = 0;
            this.txtMessage.TabStop = false;
            this.txtMessage.Visible = false;
            this.txtMessage.WordWrap = false;
            // 
            // gbxResults
            // 
            this.gbxResults.Controls.Add(this.txtMessage);
            this.gbxResults.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.gbxResults.Location = new System.Drawing.Point(9, 400);
            this.gbxResults.Name = "gbxResults";
            this.gbxResults.Size = new System.Drawing.Size(378, 143);
            this.gbxResults.TabIndex = 3;
            this.gbxResults.TabStop = false;
            this.gbxResults.Text = "Results";
            // 
            // SQLUploader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 597);
            this.Controls.Add(this.gbxResults);
            this.Controls.Add(this.gbxOptions);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbxSelectDatabaseServer);
            this.Controls.Add(this.gbxSqlToUpload);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "SQLUploader";
            this.Text = "SQL Uploader";
            this.Load += new System.EventHandler(this.SQLUploader_Load);
            this.gbxOptions.ResumeLayout(false);
            this.gbxOptions.PerformLayout();
            this.gbxSelectDatabaseServer.ResumeLayout(false);
            this.gbxSelectDatabaseServer.PerformLayout();
            this.gbxSqlToUpload.ResumeLayout(false);
            this.gbxSqlToUpload.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.gbxResults.ResumeLayout(false);
            this.gbxResults.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnBrowseSqlToUpload;
        internal System.Windows.Forms.TextBox sqlFileName;
        internal System.Windows.Forms.CheckedListBox databaseList;
        internal System.Windows.Forms.GroupBox gbxOptions;
        internal System.Windows.Forms.Button btnUpload;
        internal System.Windows.Forms.OpenFileDialog OpenFileDialog1;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnRefresh;
        internal System.Windows.Forms.Label lblUserPassword;
        internal System.Windows.Forms.Label lblUserLogin;
        internal System.Windows.Forms.Label lblServerName;
        internal System.Windows.Forms.GroupBox gbxSelectDatabaseServer;
        internal System.Windows.Forms.Label lblRefreshButton;
        internal System.Windows.Forms.TextBox userPassword;
        internal System.Windows.Forms.TextBox userLogin;
        internal System.Windows.Forms.GroupBox gbxSqlToUpload;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox serverNameList;
        private System.Windows.Forms.CheckBox trustedConnection;
        internal System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.GroupBox gbxResults;
        internal System.Windows.Forms.Label lblTimeout;
        private System.Windows.Forms.ComboBox ddlTimeout;
        private System.Windows.Forms.CheckBox chkAllDatabases;
        private System.Windows.Forms.TextBox tbCheckLike;
        private System.Windows.Forms.CheckBox chkAllDatabasesLike;
        private System.Windows.Forms.Label lblNumberDatabasesSelected;
    }
}

