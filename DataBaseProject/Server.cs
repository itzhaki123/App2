
using DataBaseProject.Models;
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

        /*
         הפעולה מוסיפה משתמש חדש למסד הנתונים. בפועל הפעולה מוסיפה נתונים ל- 3 טבלאות
         GameData יתווספו הנתונים האישיים של המשתמש.לטבלת User לטבלת.User,GameData,UserProduct :שהם 
         יתווספו נתוני ברירת מחדל של המשחק מפני שהמשתמש משחק בפעם הראשונה
         Fitcher שהוא בעצם המחסן המשותף תתווסף שורה המציינת שהשחקן החדש מקבל בחינם UserProduct לטבלת 
         ברירת מחדל
         חשוב להדגיש: הפעולה מחזירה עצם משתמש שהוא מלא בנתונים ומוכן לשחק
         */
        public static GameUser AddNewUser(string name, string password, string mail)
        {
            int? userId = ValidateUser(name, password); // בדיקה אם המשתמש כבר נמצא במאגר
            if (userId != null) // המשתמש כבר קיים - לשלוח להתחברות במקום הרשמה
                return null;
            // אם המשכנו, זאת אומרת המשתמש בעל הנתונים שהזין לא נמצא במאגר
            //User מסיפים את נתוניו האישיים של המשתמש שהזין לטבלת 
            string query = $"INSERT INTO [User] (UserName,UserPassword,UserMail) VALUES ('{name}','{password}','{mail}')";
            Execute(query);
            userId = ValidateUser(name, password); //User של המשתמש לאחר הוספתו לטבלת UserId קבלת 

            AddGameData(userId.Value);
            AddUserProduct(userId.Value);
            return GetUser(userId.Value);
        }
        private static void AddGameData(int userid)
        {
            string query = $"INSERT INTO [GameData] (UserID, Score, CurentProductId)" +
                $"VALUES ({userid}, {1},{0})";
            Execute(query);
        }
        private static void Execute(string query)
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        private static void AddUserProduct(int userId, int productId = 1)
        {
            string query = $"INSERT INTO [UserProduct] (UserId, ProductId) VALUES ({userId}, {1})";
            Execute(query);
        }
        /*
   הפעולה מחזירה משתמש אשר כל שדותיו מלאים
   הפעולה אוספת נתונים מ- 4 טבלאות וממלאה באמצעותם את המשתמש 
   ולוקחת משם User כדי שיוכל לגשת למשחק. בשלב התחלתי הפעולה ניגשת לטבלת
   של המשתמש Id,Name,Mail
   הממשיכה למלא את נתוני המשתמש,SetUser לאחר מכן הפעולה נעזרת בפעולת עזר 
 */
        public static GameUser GetUser(int userId)
        {
            GameUser user = null;
            string query = $"SELECT UserId, UserName, UserMail FROM [User] WHERE UserId={userId}";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(query, connection);
                SqliteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    user = new GameUser
                    {
                        UserId = reader.GetInt32(0),
                        UserName = reader.GetString(1),
                        Usermail = reader.GetString(2),
                    };
                }
            }
            if (user != null)
            {
                SetUser(user);//המשך מילוי משתמש
            }
            return user; // user doesnt exsit
        }

        /*
          הפעולה ממשיכה למלא את שדותיו של המשתמש. בשלב הראשון
          MaxLevel,Money,CurrentLevelId,CurrentProductId :ושולפת משם את נתוני המשחק של המשתמש GameData היא ניגשת לטבלת 
          נכנסים וממלאים משתמש MaxLevel,Money ,כמו כן 
          במשתמש CurrentLevel -על מנת למלא את ה Level ניגשים לטבלת CurrentLevelId לאחר מכן באמצעות 
          SetCurrentLevel על זה תהיה אחראית פעולת עזר  
          GameData ששלפנו מהטבלה currentProductId בשלב הבא בעזרת 
          אשר השחקן שיחק בפעם האחרונה Feature -כדי לשלוף ממנה את השם ה Product ניגשים לטבלה 
          SetCurrentProduct על זה תהיה אחראית הפעולה .GameUser -הנתון הזה גם יכנס ל
          GameUser לסיכום, באופן מדורג נאספו הנתונים מארבע טבלאות ומילאו את העצם   
          כעת יוכל המשתמש לגשת למשחק
          */
        private static void SetUser(GameUser user)
        {
            int currentProductId = 0;
            string query = $"SELECT Score, CurentProductId FROM [GameData] WHERE UserId={user.UserId}";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(query, connection);
                SqliteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    user.Score = reader.GetInt32(1);
                }
            }
            SetCurrentProduct(user, currentProductId);
        }
        /*
Fitcher -שולפת ממנה את שם ה currentProductId ולפי Product הפעולה מסייעת לגשת לטבלת 
GameUser מסוג user אותו היא שמה במשתנה  
 */
        private static void SetCurrentProduct(GameUser user, int currentProductId)
        {
            string query = $"SELECT ProducteName FROM [Product] WHERE ProductId={currentProductId}";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(query, connection);
                SqliteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    user.UsingProduct = reader.GetString(0);
                }
            }
        }
    }
}
