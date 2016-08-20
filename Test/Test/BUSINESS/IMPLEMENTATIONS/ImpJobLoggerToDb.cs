using System.Configuration;
using System.Data.SqlClient;
using Test.BUSINESS.INTERFACES;
using Test.BUSINESS.UTIL;

namespace Test.BUSINESS.IMPLEMENTATIONS
{
    public class ImpJobLoggerToDb : IJobLogger
    {
        private readonly string _message;

        public ImpJobLoggerToDb(string message)
        {            
            _message = message;
        }

        public void LogMessage()
        {
            Validation();
            LogToDb(LogType.Message);
        }

        public void LogWarning()
        {
            Validation();
            LogToDb(LogType.Warning);
        }

        public void LogError()
        {
            Validation();
            LogToDb(LogType.Error);
        }

        private void LogToDb(LogType logType)
        {
            using (var cnx = new SqlConnection())
            {
                cnx.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                cnx.Open();                
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "Insert into Log Values('" + _message + "', " + (int)logType + ")";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void Validation()
        {
            _message.Trim();

            if (string.IsNullOrEmpty(_message))
                return;            
        }
    }
}