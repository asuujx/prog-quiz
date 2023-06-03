using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Data.Sqlite;

namespace quizini.Model
{
    class DataAccess
    {
        public Quiz ReadQuiz(string connection)
        {
            SqliteConnection conn = new SqliteConnection($"Data Source={connection}");
            conn.Open();

            string readQuizQuery = "SELECT * FROM quiz LIMIT 1";
            var command = new SqliteCommand(readQuizQuery, conn);
            SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Quiz quiz = new Quiz((long)reader["id"], (string)reader["title"]);
                conn.Close();
                return quiz;
            }
            
            conn.Close();
            return null;
        }

        public List<Question> ReadQuestions(long quizId, string connection)
        {
            List<Question> questions = new List<Question>();
            SqliteConnection conn = new SqliteConnection($"Data Source={connection}");
            conn.Open();

            string readQuizQuery = "SELECT * FROM question WHERE quiz_id=$1";
            var command = new SqliteCommand(readQuizQuery, conn);
            command.Parameters.Add(new SqliteParameter("$1", quizId));
            SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Question question = new Question((long)reader["id"], (string)reader["title"]);
                questions.Add(question);
            }
            conn.Close();
            return questions;
        }

        public List<Answer> ReadAnswers(long questionId, string connection)
        {
            List<Answer> answers = new List<Answer>();
            SqliteConnection conn = new SqliteConnection($"Data Source={connection}");
            conn.Open();

            string readQuizQuery = "SELECT * FROM answer WHERE question_id=$1";
            var command = new SqliteCommand(readQuizQuery, conn);
            command.Parameters.Add(new SqliteParameter("$1", questionId));
            SqliteDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Answer answer = new Answer((long)reader["id"], (string)reader["text"], (long)reader["is_correct"]);
                answers.Add(answer);
            }
            conn.Close();
            return answers;
        }
    }
}
