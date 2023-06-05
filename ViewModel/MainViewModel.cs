using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using quizini.Model;
using System.Timers;
using System.Windows.Controls;
using System.Reflection;

namespace quizini.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private Model.DataAccess DataAccess = new Model.DataAccess();
        private static Timer? timer;
        private static bool isRun = false;
        private Quiz quiz;

        public MainViewModel()
        {
            quiz = new Quiz();
            timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;
        }

        public void LoadQuiz(string connection)
        {
            FinishQuiz();
            Quiz newQuiz = DataAccess.ReadQuiz(connection);

            if (newQuiz == null)
            {
                return;
            }

            List<Question> questions = DataAccess.ReadQuestions(newQuiz.Id, connection);
            newQuiz.Questions = questions;

            if (questions == null)
            {
                return;
            }

            foreach (Question question in questions)
            {
                List<Answer> answers = DataAccess.ReadAnswers(question.Id, connection);
                question.Answers = answers;
            }

            quiz = newQuiz;

            QuizName = quiz.Name;
            TotalPoints = "0";
            MaximumPoints = " / " + quiz.Questions.Count.ToString();
        }

        private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            if (int.Parse(TimerValue) > 0)
            {
                TimerValue = (int.Parse(timerValue) - 1).ToString();
            }
            else
            {
                FinishQuiz();
            }
        }

        public string TotalTime()
        {
            return (quiz.Questions.Count * 30).ToString();
        }

        public void StartQuizLogic()
        {
            QuestionId = 0;
            TotalPoints = "0";
            TimerValue = TotalTime();
            timer?.Start();
            isRun = true;
        }

        public void HandleQuestionChange()
        {
            QuestionName = quiz.Questions[(int)QuestionId].Name;
            Answers = quiz.Questions[(int)QuestionId].Answers.ToArray();
        }

        public void FinishQuiz()
        {
            QuestionName = "";
            Question question = new Question();
            Answers = question.Answers.ToArray();
            TotalPoints = totalPoints;
            isRun = false;
            timer?.Stop();
        }

        private string timerValue;
        public string TimerValue
        {
            get => timerValue;
            set
            {
                timerValue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TimerValue)));
            }
        }

        private string quizName = string.Empty;
        public string QuizName
        {
            get => quizName;
            set
            {
                quizName = value;
                quiz.Name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuizName)));
            }
        }

        private long questionId = 0;
        public long QuestionId
        {
            get => questionId;
            set
            {
                questionId = value;
                HandleQuestionChange();
            }
        }

        private string questionName = string.Empty;
        public string QuestionName
        {
            get => questionName;
            set
            {
                questionName = value;
                quiz.Questions[(int)questionId].Name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuestionName)));
            }
        }

        private Answer[] answers;
        public Answer[] Answers
        {
            get => answers;
            set
            {
                answers = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Answers)));
            }
        }

        private string totalPoints = "0";
        public string TotalPoints
        {
            get => totalPoints;
            set
            {
                totalPoints = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TotalPoints)));
            }
        }

        private string maximumPoints;
        public string MaximumPoints
        {
            get => maximumPoints;
            set
            {
                maximumPoints = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MaximumPoints)));
            }
        }

        private ICommand startQuiz;
        public ICommand StartQuiz
        {
            get
            {
                if (startQuiz == null)
                    startQuiz = new RelayCommand(
                        (o) =>
                        {
                            StartQuizLogic();
                        }
                        ,
                        (o) => !isRun
                        );
                return startQuiz;
            }
        }

        private ICommand button1Logic;
        public ICommand Button1Logic
        {
            get
            {
                if (button1Logic == null)
                    button1Logic = new RelayCommand(
                        (o) =>
                        {
                            if (Answers[0].IsCorrect == 1)
                            {

                                TotalPoints = (int.Parse(totalPoints) + 1).ToString();
                            }

                            if(QuestionId < quiz.Questions.Count - 1)
                            {
                                QuestionId++;
                            }
                            else
                            {
                                FinishQuiz();
                            }
                        }
                        ,
                        (o) => isRun = false
                        );
                return button1Logic;
            }
        }

        private ICommand button2Logic;
        public ICommand Button2Logic
        {
            get
            {
                if (button2Logic == null)
                    button2Logic = new RelayCommand(
                        (o) =>
                        {
                            if (Answers[1].IsCorrect == 1)
                            {
                                TotalPoints = (int.Parse(totalPoints) + 1).ToString();
                            }

                            if (QuestionId < quiz.Questions.Count - 1)
                            {
                                QuestionId++;
                            }
                            else
                            {
                                FinishQuiz();
                            }
                        }
                        ,
                        (o) => isRun = false
                        );
                return button2Logic;
            }
        }

        private ICommand button3Logic;
        public ICommand Button3Logic
        {
            get
            {
                if (button3Logic == null)
                    button3Logic = new RelayCommand(
                        (o) =>
                        {
                            if (Answers[2].IsCorrect == 1)
                            {
                                TotalPoints = (int.Parse(totalPoints) + 1).ToString();
                            }

                            if (QuestionId < quiz.Questions.Count - 1)
                            {
                                QuestionId++;
                            }
                            else
                            {
                                FinishQuiz();
                            }
                        }
                        ,
                        (o) => isRun = false
                        );
                return button3Logic;
            }
        }

        private ICommand button4Logic;
        public ICommand Button4Logic
        {
            get
            {
                if (button4Logic == null)
                    button4Logic = new RelayCommand(
                        (o) =>
                        {
                            if (Answers[3].IsCorrect == 1)
                            {
                                TotalPoints = (int.Parse(totalPoints) + 1).ToString();
                            }

                            if (QuestionId < quiz.Questions.Count - 1)
                            {
                                QuestionId++;
                            }
                            else
                            {
                                FinishQuiz();
                            }
                        }
                        ,
                        (o) => isRun = false
                        );
                return button4Logic;
            }
        }
    }
}
