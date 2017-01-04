using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace MathadorLibrairie
{
    public class sqlite
    {
        private SQLiteConnection connexion = new SQLiteConnection("Data Source=usersdb.sqlite;Version=3;");

        public void Start ()
        {
            SQLiteConnection.CreateFile("usersdb.sqlite");
            connexion.Open();
            string sql = "CREATE TABLE users (username, password, minScore int, maxScore int, averageScore float, gameCount int, averagePointsPerGame float, averagePointsPerRound float, averageTimePerGame, additionUseRate float, substractionUseRate float, multiplicationUseRate float, divisionUseRate float)";
            SQLiteCommand commande = new SQLiteCommand(sql, connexion);
            commande.ExecuteNonQuery();
        }
        public void Stop ()
        {
            connexion.Close();
        }
        public string GetPasswordFromUsername(string username)
        {
            string password = "";
            string sql = "SELECT password FROM users WHERE username = " + username;

            SQLiteCommand commande = new SQLiteCommand(sql, connexion);
            SQLiteDataReader reader = commande.ExecuteReader();
            while (reader.Read())
            {
                password = reader["password"].ToString();
            }
            return password;
        }
    }
}
