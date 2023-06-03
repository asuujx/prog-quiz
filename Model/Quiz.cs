using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizini.Model
{
    class Quiz
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();

        public Quiz()
        {
            this.Id = 1;
            this.Questions.Add(new Question(0, ""));
            List<Answer> answers = new List<Answer>();
            for (int i = 0; i < 4; i++)
            {
                answers.Add(new Answer(i, "", 0));
            }
            this.Questions[0].Answers = answers;
        }

        public Quiz(long id, string name) 
        {
            this.Id = id;
            this.Name = name;
            this.Questions = new List<Question>();
        }
    }
}
