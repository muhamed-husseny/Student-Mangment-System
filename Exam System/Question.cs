using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_System
{
    public abstract class Question
    {


        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answer[] AnswerList { get; set; }
        public int RightAnswer { get; set; }

        public List<int> ChoiceUser { get; set; }

        public Question()
        {
            Header = string.Empty;
            Body = string.Empty;
            Mark = 0;
            AnswerList = new Answer[0]; 
        }



    }
}
