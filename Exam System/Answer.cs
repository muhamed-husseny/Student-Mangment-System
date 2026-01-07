using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        // Constructor
        public Answer()
        {
            AnswerId = 0;
            AnswerText = string.Empty;
        }
    }
}
