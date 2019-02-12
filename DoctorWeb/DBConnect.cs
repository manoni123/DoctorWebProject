using MySql.Data;
using MySql.Data.MySqlClient;
using System;

namespace Data
{
    public class DBConnect
    {
        private DBConnect()
        {
        }

        private string databaseName = string.Empty;
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public string Password { get; set; }
        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static DBConnect _instance = null;
        public static DBConnect Instance()
        {
            if (_instance == null)
                _instance = new DBConnect();
            return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(databaseName))
                    return false;
                string connstring = string.Format("Server=db-qa1.cgzowvzgqfhl.eu-central-1.rds.amazonaws.com; database={0}; UID=doctorweb; password=your password", databaseName);
                connection = new MySqlConnection(connstring);
                connection.Open();
            }

            return true;
        }

        public void Close()
        {
            connection.Close();
        }
    }
}