
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace DataBaseProject
{
    public static class Server
    {
        private static string dbPath = ApplicationData.Current.LocalFolder.Path; //נתיב מסד נתונים במחשב
        private static string connectionString = "Filename=" + dbPath + "\\DBGame.db"; //המחרוזת שבאמצעותה נוכל להתחבר למסד הנתונים
        /*
          הפעולה בודקת אם המשתמש הזין נתונים נכונים ונמצא במאגר משתמשים אם הכל תקין,
          null של המשתמש אם הנתונים אינם תקינים הפעולה מחזירה ערך UserId הפעולה מחזירה את  
        */
        public static int? ValidateUser(string userName, string userPassword)
        {
            string query = $"SELECT UserId FROM [User] WHERE UserName = '{userName}' AND UserPassword = '{userPassword}'";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(query, connection);
                SqliteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return reader.GetInt32(0);
                }
                return null;
            }
        }
    }
}
