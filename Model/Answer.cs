using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizini.Model
{
    class Answer
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public long IsCorrect { get; set; }
       
        public Answer(long id, string text, long isCorrect)
        {
            this.Id = id;
            this.Text = text;
            this.IsCorrect = isCorrect;
        }

        public Answer(string text, long isCorrect)
        {
            this.Text = text;
            this.IsCorrect = isCorrect;
        }
    }
}
