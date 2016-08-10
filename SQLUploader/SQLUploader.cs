using System;
//using System.Collections.Generic;
//using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using DBGrep;

namespace SQLUploader
{
    public partial class SQLUploader : Form
    {
        public SQLUploader()
        {
            InitializeComponent();
        }

        private void btnBrowseSqlToUpload_Click(object sender, EventArgs e)
        {
            this.BrowseForInputFile();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.SetMessage("");
            this.databaseList.Items.Clear();
            this.updateSelectedDatabasesCount();
            errorProvider1.SetError(this.sqlFileName, "");
            errorProvider1.SetError(this.databaseList, "");
            if (!this.ValidateServerNameList())
                return;
            if (!this.ValidateUserLogin())
                return;
            if (!this.ValidateUserPassword())
                return;

            SQLUploadDAL sqlUploadDal = new SQLUploadDAL();
            ArrayList databaseArrayList = new ArrayList();

            try
            {
                sqlUploadDal.ServerName = this.serverNameList.Text;
                sqlUploadDal.Trusted = this.trustedConnection.Checked;
                sqlUploadDal.UserLogin = this.userLogin.Text;
                sqlUploadDal.UserPassword = this.userPassword.Text;
                sqlUploadDal.TimeOut = Convert.ToInt32(this.ddlTimeout.Text);
                sqlUploadDal.GetSystemDatabaseList(ref databaseArrayList);
                foreach (string item in databaseArrayList)
                {
                    databaseList.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                this.SetMessage(ex.Message);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (!this.ValidateFileName())
                return;
            if (!this.ValidateServerNameList())
                return;
            if (!this.ValidateUserLogin())
                return;
            if (!this.ValidateUserPassword())
                return;
            if (!ValidateDatabaseCount())
                return;

            SQLUploadDAL sqlUploadDal = new SQLUploadDAL();
            sqlUploadDal.ServerName = this.serverNameList.Text;
            sqlUploadDal.Trusted = this.trustedConnection.Checked;
            sqlUploadDal.UserLogin = this.userLogin.Text;
            sqlUploadDal.UserPassword = this.userPassword.Text;
            sqlUploadDal.TimeOut = Convert.ToInt32(this.ddlTimeout.Text);

            ArrayList feedbackArrayList = new ArrayList();
            feedbackArrayList.Clear();

            ArrayList databaseArrayList = new ArrayList();
            databaseArrayList.Clear();
            foreach (string item in this.databaseList.CheckedItems)
            {
                databaseArrayList.Add(item);
            }


            // clear old message
            string exceptionMessage = "";
            this.SetMessage("");
            this.ToggleInputFields(false);
            try
            {
                SQLUploadBLL sqlUploadBLL = new SQLUploadBLL();
                sqlUploadBLL.UploadSqlFileIntoDatabase(sqlUploadDal, this.sqlFileName.Text, databaseArrayList, feedbackArrayList);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
            }
            finally
            {
                string Feedback = "";
                foreach (string item in feedbackArrayList)
                {
                    Feedback = Feedback + item + "\r\n";
                }
                Feedback = Feedback + "\r\nEnd of Process:\r\n";
                if (exceptionMessage != string.Empty)
                    Feedback = Feedback + exceptionMessage;
                else
                    Feedback = Feedback + "Upload was successful";
                this.SetMessage(Feedback);
                this.ToggleInputFields(true);
            }
        }

        private void userLogin_TextChanged(object sender, EventArgs e)
        {
            this.SetMessage("");
            this.databaseList.Items.Clear();
            this.updateSelectedDatabasesCount();
        }

        private void userPassword_TextChanged(object sender, EventArgs e)
        {
            this.SetMessage("");
            this.databaseList.Items.Clear();
            this.updateSelectedDatabasesCount();
        }

        private void BrowseForInputFile()
        {
            this.SetMessage("");
            try
            {
                // prepare the SaveFileDialog, customized for Excel
                this.OpenFileDialog1.Title = "Select SQL File To Be Uploaded";
                this.OpenFileDialog1.Filter = "SQL files (*.sql)|*.sql";
                this.OpenFileDialog1.FilterIndex = 1;
                this.OpenFileDialog1.RestoreDirectory = true;
                this.OpenFileDialog1.FileName = this.sqlFileName.Text;
                if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
                    this.sqlFileName.Text = this.OpenFileDialog1.FileName;
            }
            catch (Exception ex)
            {
                this.SetMessage(ex.Message);
            }
        }

        private void ToggleInputFields(bool bEnable)
        {
            this.btnBrowseSqlToUpload.Enabled = bEnable;
            this.btnCancel.Enabled = bEnable;
            this.btnRefresh.Enabled = bEnable;
            this.btnUpload.Enabled = bEnable;
            this.trustedConnection.Enabled = bEnable;
            if (bEnable)
            {
                this.userLogin.Enabled = (this.trustedConnection.Checked == false);
                this.userPassword.Enabled = (this.trustedConnection.Checked == false);
            }
            else
            {
                this.userLogin.Enabled = bEnable;
                this.userPassword.Enabled = bEnable;
            }
            this.serverNameList.Enabled = bEnable;
            this.databaseList.Enabled = bEnable;
        }

        private void SetMessage(string newMessage)
        {
    		this.txtMessage.Text = newMessage;
		    this.txtMessage.Visible = (newMessage.Length > 0);
		    this.Update();
            Application.DoEvents();
        }

        private bool ValidateServerNameList()
        {
            bool bStatus = true;
            if (this.serverNameList.Text == "")
            {
                errorProvider1.SetError(this.serverNameList, SQLUploadConst.SERVER_NAME_REQUIRED);
                bStatus = false;
            }
            else
                errorProvider1.SetError(this.serverNameList, "");
            return bStatus;
        }

        private bool ValidateDatabaseCount()
        {
            bool bStatus = true;
            if (this.databaseList.CheckedItems.Count == 0)
            {
                errorProvider1.SetError(this.databaseList, SQLUploadConst.DATABASE_REQUIRED);
                bStatus = false;
            }
            else
                errorProvider1.SetError(this.databaseList, "");
            return bStatus;
        }


        private bool ValidateFileName()
        {
            bool bStatus = true;
            if (this.sqlFileName.Text == "")
            {
                errorProvider1.SetError(this.sqlFileName, SQLUploadConst.SQL_FILE_REQUIRED);
                bStatus = false;
            }
            else
                errorProvider1.SetError(this.sqlFileName, "");
            return bStatus;
        }

        private bool ValidateUserLogin()
        {
            bool bStatus = true;
            if (this.userLogin.Text == "" && this.trustedConnection.Checked == false)
            {
                errorProvider1.SetError(this.userLogin, SQLUploadConst.USER_LOGIN_REQUIRED);
                bStatus = false;
            }
            else
                errorProvider1.SetError(this.userLogin, "");
            return bStatus;
        }

        private bool ValidateUserPassword()
        {
            bool bStatus = true;
            //if (this.userPassword.Text == "" && this.trustedConnection.Checked == false)
            //{
            //    errorProvider1.SetError(this.userPassword, SQLUploadConst.USER_PASSWORD_REQUIRED);
            //    bStatus = false;
            //}
            //else
            //    errorProvider1.SetError(this.userPassword, "");
            return bStatus;
        }

        private void userLogin_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateUserLogin();
        }

        private void userPassword_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateUserPassword();
        }

        private void sqlFileName_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void sqlFileName_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("FileNameW"))
            {
                // Create a new ArrayList
                ArrayList FileNameArray = new ArrayList();
                foreach (string item in (System.Array) e.Data.GetData("FileNameW"))
                {
                    FileNameArray.Add(item);
                }

                // Perform drag and drop, depending upon the effect.
                if (e.Effect == DragDropEffects.Copy || e.Effect == DragDropEffects.Move)
                {
                    string fileName = FileNameArray[0].ToString();
                    if (File.Exists(fileName))
                        sqlFileName.Text = fileName;
                }
            }
            // move focus to Browse button
            this.btnBrowseSqlToUpload.Focus();
        }

        private void databaseList_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateDatabaseCount();
        }

        private void serverNameList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetMessage("");
            this.databaseList.Items.Clear();
            this.updateSelectedDatabasesCount();
        }

        private void serverNameList_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateServerNameList();
        }

	    /// <summary>
	    /// 
	    /// </summary>
	    /// <param name="sender"></param>
	    /// <param name="e"></param>
        private void trustedConnection_CheckedChanged(object sender, EventArgs e)
        {
            this.userLogin.Enabled = (this.trustedConnection.Checked == false);
            this.userPassword.Enabled = (this.trustedConnection.Checked == false);
        }

        private void SQLUploader_Load(object sender, EventArgs e)
        {
            string[] serverNames = SqlLocator.GetServers();
            ArrayList serverNameArray = new ArrayList();

            foreach (string serverName in serverNames)
            {
                serverNameArray.Add(serverName);
            }
            this.serverNameList.DataSource = serverNameArray;
            this.ddlTimeout.SelectedIndex = 1;           
        }

        private void checkAllDatabases(bool checkedValue)
        {
            for (int i = 0; i < this.databaseList.Items.Count; i++)
            {
                this.databaseList.SetItemChecked(i, checkedValue);
            }
            this.updateSelectedDatabasesCount();
        }

        private void checkSomeDatabases()
        {
            this.checkAllDatabases(false);
            int iSelected = 0;
            if (this.tbCheckLike.Text.Length > 0 && this.chkAllDatabasesLike.Checked)
            {
                for (int i = 0; i < this.databaseList.Items.Count; i++)
                {
                    string dbName = this.databaseList.Items[i].ToString();
                    if (dbName.ToLower().IndexOf(this.tbCheckLike.Text.ToLower()) >= 0)
                    {
                        iSelected++;
                        this.databaseList.SetItemChecked(i, true);
                    }
                }
            }
            this.updateSelectedDatabasesCount();
        }

        private void tbCheckLike_TextChanged(object sender, EventArgs e)
        {
            this.chkAllDatabases.Checked = false;
            this.chkAllDatabasesLike.Checked = true;
            this.checkSomeDatabases();
        }

        private void updateSelectedDatabasesCount()
        {
            this.lblNumberDatabasesSelected.Text = String.Format("{0} database(s) selected", this.databaseList.CheckedItems.Count);
        }

        private void databaseList_KeyUp(object sender, KeyEventArgs e)
        {
            this.chkAllDatabasesLike.Checked = false;
            this.chkAllDatabases.Checked = false;
            // this fires an event that is not desired at this time
            //this.tbCheckLike.Text = "";
            this.updateSelectedDatabasesCount();
        }

        private void databaseList_MouseUp(object sender, MouseEventArgs e)
        {
            this.chkAllDatabasesLike.Checked = false;
            this.chkAllDatabases.Checked = false;
            // this fires an event that is not desired at this time
            //this.tbCheckLike.Text = "";
            this.updateSelectedDatabasesCount();
        }

        private void chkAllDatabases_MouseUp(object sender, MouseEventArgs e)
        {
            this.chkAllDatabasesLike.Checked = false;
            this.tbCheckLike.Text = "";
            this.checkAllDatabases(this.chkAllDatabases.Checked);
        }

        private void chkAllDatabasesLike_MouseUp(object sender, MouseEventArgs e)
        {
            this.chkAllDatabases.Checked = false;
            this.checkSomeDatabases();
        }
    }
}