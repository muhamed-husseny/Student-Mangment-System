using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
    public class MCQ : Question
    {
        public MCQ()
        {
            AnswerList = new Answer[3]; // Initialize the array
            for (int i = 0; i < AnswerList.Length; i++)
            {
                AnswerList[i] = new Answer();
            }
        }
    }
    public class TFQuestion : Question
    {
    }
}
