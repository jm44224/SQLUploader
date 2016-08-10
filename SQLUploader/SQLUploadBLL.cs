using System;
using System.Collections;
using System.IO;

namespace SQLUploader
{
    /// <summary>
    /// this class is for the business logic of the uploader
    /// </summary>
    class SQLUploadBLL
    {
        /// <summary>
        /// This function reads each line of the SQL file and
        ///     uploads in into each database of the arraylist. 
        /// If a USE statement is encountered, the arraylist will
        ///     be ignored.
        /// The file is parsed on the GO command. 
        /// </summary>
        /// <param name="sqlUploadDal">a reference to a DAL object</param>
        /// <param name="sqlFileName">the file to read and upload</param>
        /// <param name="databaseArrayList">default databases to upload to</param>
        public void UploadSqlFileIntoDatabase(SQLUploadDAL sqlUploadDal,
                                              string sqlFileName, 
                                              ArrayList databaseArrayList,
                                              ArrayList feedbackArrayList)
        {
            string myCommandString = "";

            StreamReader sr;
            try
            {
                sr = File.OpenText(sqlFileName);
                string input = "";
                // Read and display the lines from the file until the end 
                // of the file is reached.
                string overrideDB = "";
                bool ignoreNextGO = false;
                while ((input = sr.ReadLine()) != null)
                {
                    // GO ... run the script so far, and clear the string
                    if (input.ToUpper().StartsWith("USE "))
                    {
                        overrideDB = input.Substring(4);
                        ignoreNextGO = true;
                    }
                    else if (input.ToUpper() == "GO" && ignoreNextGO == false)
                    {
                        if (overrideDB == string.Empty)
                            sqlUploadDal.LaunchCommand(databaseArrayList,
                                                        myCommandString,
                                                        feedbackArrayList);
                        else
                            sqlUploadDal.LaunchCommand(overrideDB,
                                                        myCommandString,
                                                        feedbackArrayList);
                        // overrideDB = "";
                        myCommandString = "";
                    }
                    else 
                    {
                        if (input.ToUpper() == "GO" && ignoreNextGO == true)
                            ignoreNextGO = false;
                        else
                        {
                            myCommandString = myCommandString + input;
                            myCommandString = myCommandString + "\n";
                        }
                    }
                }
                // launch the string if there is anything left
                if (myCommandString.Length > 0)
                {
                    sqlUploadDal.LaunchCommand(databaseArrayList,
                                                myCommandString,
                                                feedbackArrayList);
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }
        }
    }
}
