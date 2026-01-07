namespace Exam_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject(10, "C#");

            subject.CreateExam();

            Console.WriteLine("Do you want to start the exam? (Y/N)");
            string startExam = Console.ReadLine() ?? "0";

            if (startExam.ToUpper() == "Y")
            {
                subject.ShowExam();
            }
        }
    }
}
