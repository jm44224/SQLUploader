using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace SQLUploader
{
    /// <summary>
    /// This class is the database access layer of the uploader
    /// </summary>
    class SQLUploadDAL
    {
        #region members
        private string m_serverName;
        private string m_userLogin;
        private string m_userPassword;
        private bool m_trusted;
        private int m_timeout = 15;

        #endregion

        #region properties

        public string ServerName
        {
            get
            {
                return this.m_serverName;
            }
            set
            {
                this.m_serverName = value;
            }
        }

        public string UserLogin
        {
            get
            {
                return this.m_userLogin;
            }
            set
            {
                this.m_userLogin = value;
            }
        }

        public string UserPassword
        {
            get
            {
                return this.m_userPassword;
            }
            set
            {
                this.m_userPassword = value;
            }
        }

        public bool Trusted
        {
            get
            {
                return this.m_trusted;
            }
            set
            {
                this.m_trusted = value;
            }
        }

        public int TimeOut
        {
            get
            {
                return this.m_timeout;
            }
            set
            {
                this.m_timeout = value;
            }
        }

        #endregion

        /// <summary>
        /// creates connections string based on database and
        ///     access information entered via properties
        /// </summary>
        /// <param name="databaseName">current database to connect to</param>
        /// <returns>full connection string</returns>
        private string GetConnectionString(string databaseName)
        {
            if (ServerName == null || ServerName == string.Empty)
                throw new Exception(SQLUploadConst.SERVER_NAME_REQUIRED);
            if (!this.Trusted)
            {
                if (UserLogin == null || UserLogin == string.Empty)
                    throw new Exception(SQLUploadConst.USER_LOGIN_REQUIRED);
                //if (UserPassword == null || UserPassword == string.Empty)
                //    throw new Exception(SQLUploadConst.USER_PASSWORD_REQUIRED);
            }
            string myConnectionString = "";
            // we need to connect to SO_Control, even if only to retrieve the Account Databases
            if (this.Trusted)
            {
                myConnectionString
                    = String.Format("Server={0};Database={1};Trusted_Connection=True;Integrated Security=SSPI;connection timeout={4}",
                                        ServerName,
                                        databaseName,
                                        UserLogin,
                                        UserPassword,
                                        TimeOut);
            }
            else
            {
                myConnectionString
                    = String.Format("Server={0};Database={1};User ID={2};Password={3};Trusted_Connection=False;connection timeout={4}",
                                        ServerName,
                                        databaseName,
                                        UserLogin,
                                        UserPassword,
                                        TimeOut);
            }
            return myConnectionString;
        }

        /// <summary>
        /// fills the arraylist with all databases of the server
        /// </summary>
        /// <param name="databaseArrayList">arraylist to be filled</param>
        public void GetSystemDatabaseList(ref ArrayList databaseArrayList)
        {
            SqlConnection myConnection;
            SqlCommand myCommand;
            SqlDataReader mySQLReader;
            try
            {
                string myMasterConnectionString = this.GetConnectionString("master");
                myConnection = new SqlConnection(myMasterConnectionString);
                string Query = "select * from sysdatabases";
                myCommand = new SqlCommand(Query, myConnection);
                myConnection.Open();
                mySQLReader = myCommand.ExecuteReader();
                // Always call Read before accessing data.
                databaseArrayList.Clear();
                while (mySQLReader.Read())
                {
                    databaseArrayList.Add(mySQLReader.GetString(0));
                }
                myConnection.Close();
                // validation complete ... plus we have the account tables in memory
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                myConnection = null;
                myCommand = null;
            }
        }

        /// <summary>
        /// uploading the SQL string to all databases in an arraylist
        /// </summary>
        /// <param name="databaseArrayList">list of selected databases</param>
        /// <param name="myCommandString">SQL command to upload</param>
        public void LaunchCommand(ArrayList databaseArrayList, 
                                    string myCommandString,
                                    ArrayList feedbackArrayList)
        {
            foreach (string item in databaseArrayList)
            {
                feedbackArrayList.Add("Database " + item.ToString() + ":");
                LaunchCommand(item, myCommandString, feedbackArrayList);
            }
        }

        /// <summary>
        /// uploading the SQL string to a single database
        /// either from a USE statement, or from each in the arraylist
        /// </summary>
        /// <param name="databaseName">the database to upload to</param>
        /// <param name="myCommandString">the SQL command</param>
        public void LaunchCommand(string databaseName,
                                    string myCommandString,
                                    ArrayList feedbackArrayList)
        {
            if (myCommandString == null || myCommandString == string.Empty)
                throw new Exception(SQLUploadConst.SQL_FILE_REQUIRED);
            if (databaseName == null || databaseName == string.Empty)
                throw new Exception(SQLUploadConst.DATABASE_REQUIRED);

            SqlConnection myConnection;
            SqlCommand myCommand;
            string currentDatabase = "";
            try
            {
                // if database information has been entered, use it to find the subject listing
                currentDatabase = databaseName;
                string myConnectionString = this.GetConnectionString(currentDatabase);

                // if database information has been entered, use it to find the subject listing
                myConnection = new SqlConnection(myConnectionString);
                myCommand = new SqlCommand(myCommandString, myConnection);
                myConnection.Open();

                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    string readLine = "";
                    for (int i=0; i<myReader.VisibleFieldCount; i++) 
                    {
                        if (i == 0)
                            readLine = Convert.ToString(myReader[i]);
                        else
                            readLine = readLine + "\t" + Convert.ToString(myReader[i]);
                    }
                    feedbackArrayList.Add(readLine.Replace("\n", "\r\n"));
                }
                myReader.Close();
                myConnection.Close();
                // validation complete ... plus we have the account tables in memory
            }
            catch (Exception ex)
            {
                // format a better string
                string betterMessage = String.Format("Error '{0}' has occurred in database '{1}'. The command string was '{2}'.", ex.Message, currentDatabase, myCommandString.Replace("\n", "  "));
                throw new Exception(betterMessage);
            }
            finally
            {
                myCommand = null;
                myConnection = null;
            }
        }
    }
}
