using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizini.Model
{
    class Question
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();

        public Question()
        {
            this.Name = "";
            List<Answer> answers = new List<Answer>();
            for (int i = 0; i < 4; i++)
            {
                answers.Add(new Answer("", 0));
            }
        }

        public Question(long id, string name) 
        {
            this.Id = id;
            this.Name = name;
            List<Answer> answers = new List<Answer>();
            for(int i=0; i < 4; i++)
            {
                answers.Add(new Answer("", 0));
            }
        }
    }
}
