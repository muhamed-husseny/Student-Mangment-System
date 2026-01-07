using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
    public class Subject : Exam
    {

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam exam { get; set; }

        int TypeOfExam, TimeOfExam, NumberOfQuestions, typeOfQuestion;


        List<Question> questions = new List<Question>();
        List<int> answeruser = new List<int>();
        DateTime startTime;
        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }
        public void CreateExam()
        {
            startTime = DateTime.Now;
            do
            {
                Console.Write("Please Enter The Type Of Exam You Want To Create (1 for Practical and 2 for Final): ");

            } while (!int.TryParse(Console.ReadLine(), out TypeOfExam));
            do
            {
                Console.Write("Please Enter The Time Of in Miuntes: ");
            } while (!int.TryParse(Console.ReadLine(), out TimeOfExam));

            do
            {
                Console.Write("Please Enter The Number Of Questions You Wanted To Create: ");

            } while (!int.TryParse(Console.ReadLine(), out NumberOfQuestions));



            Console.Clear();


            if (TypeOfExam == 2)
            {

                for (int i = 0; i < NumberOfQuestions; i++)
                {

                    do
                    {
                        Console.WriteLine($"Please Choose The Type Of Question Number({i + 1}) (1 for True Or False || 2 For Mcq) ");
                    } while (!int.TryParse(Console.ReadLine(), out typeOfQuestion));


                    Console.Clear();

                    if (typeOfQuestion == 1)
                    {
                        TFQuestion tfQuestion = new TFQuestion();

                        Console.WriteLine("True | False Qusetion");
                        tfQuestion.Header = "True | False Qusetion";

                        do
                        {
                            Console.WriteLine("Please Enter The Body of Question");
                            tfQuestion.Body = Console.ReadLine() ?? "0";
                        } while (string.IsNullOrEmpty(tfQuestion.Body));


                        int mark;
                        do
                        {
                            Console.WriteLine("Please Enter The Marks of Question");

                        } while (!int.TryParse(Console.ReadLine(), out mark));

                        tfQuestion.Mark = mark;

                        int ans;
                        do
                        {

                            Console.WriteLine("Please Enter The Right Answer of Question (1 for True and 2 for False):");
                        } while (!int.TryParse(Console.ReadLine(), out ans));

                        tfQuestion.RightAnswer = ans;



                        questions.Add(tfQuestion);
                        Console.Clear();
                    }
                    else
                    {
                        MCQ mCQAndChoices = new MCQ();

                        Console.WriteLine("Choose One Answer Question");
                        mCQAndChoices.Header = "Choose One Answer Question";
                        Console.WriteLine("Please Enter The Body of Question");
                        mCQAndChoices.Body = Console.ReadLine() ?? "0";

                        int mark;
                        do
                        {
                            Console.WriteLine("Please Enter The Marks of Question");
                        } while (!int.TryParse(Console.ReadLine(), out mark));

                        mCQAndChoices.Mark = mark;

                        Console.WriteLine("The Choices Of Question:");

                        for (int j = 0; j < 3; j++)
                        {
                            Console.Write($"Please Enter The Choice Number {j + 1}:");
                            string answer = Console.ReadLine() ?? "0";
                            mCQAndChoices.AnswerList[j].AnswerText = answer;
                        }

                        int rightChoice;
                        do
                        {
                            Console.WriteLine("Please Specify The Right Choice of Question");
                        } while (!int.TryParse(Console.ReadLine(), out rightChoice) || rightChoice < 1 || rightChoice > 3);
                        mCQAndChoices.RightAnswer = rightChoice;

                        questions.Add(mCQAndChoices);
                        Console.Clear();
                    }
                }

            }
            else
            {
                for (int i = 0; i < NumberOfQuestions; i++)
                {
                    MCQ mCQ = new MCQ();

                    Console.WriteLine("Choose One Answer Question");
                    mCQ.Header = "Choose One Answer Question";
                    Console.WriteLine("Please Enter The Body of Question");
                    mCQ.Body = Console.ReadLine() ?? "0";

                    int mark;
                    do
                    {
                        Console.WriteLine("Please Enter The Marks of Question");
                    } while (!int.TryParse(Console.ReadLine(), out mark));

                    mCQ.Mark = mark;

                    Console.WriteLine("The Choices Of Question:");

                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write($"Please Enter The Choice Number {j + 1}:");
                        string answer = Console.ReadLine() ?? "0";
                        mCQ.AnswerList[j].AnswerText = answer;
                    }

                    int rightChoice;
                    do
                    {
                        Console.WriteLine("Please Specify The Right Choice of Question");
                    } while (!int.TryParse(Console.ReadLine(), out rightChoice) || rightChoice < 1 || rightChoice > 3);
                    mCQ.RightAnswer = rightChoice;

                    questions.Add(mCQ);
                    Console.Clear();
                }
            }
        }

        public override void ShowExam()
        {

            foreach (Question question in questions)
            {
                Console.Write(question.Header);
                Console.WriteLine($"{question.Mark} Mark");
                Console.WriteLine(question.Body);
                if (question.Header == "True | False Qusetion")
                {
                    Console.WriteLine("1.True  2. False");
                }
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine($"{i + 1}.{question.AnswerList[i].AnswerText}            ");
                    }
                }
                Console.WriteLine("============================================");
                int answer = Convert.ToInt32(Console.ReadLine());
                answeruser.Add(answer);
                Console.WriteLine("============================================");
            }

            Console.Clear();
            Console.WriteLine("Your Answers:");
            int grade = 0;
            int totalgrade = 0;
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.Write($"Q{i + 1} {questions[i].Body} :");
                if (questions[i].RightAnswer == answeruser[i])
                {
                    Console.WriteLine("true");
                    grade += questions[i].Mark;
                }
                else
                {
                    Console.WriteLine("false");
                    Console.WriteLine("Your Grade : 0 ");

                }
                totalgrade += questions[i].Mark;
            }
            Console.WriteLine($"Your Grade is : {grade}  from  {totalgrade} ");
            
        }
    }
}
