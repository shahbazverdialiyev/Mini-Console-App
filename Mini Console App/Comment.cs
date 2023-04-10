using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Console_App
{
    internal class Comment
    {
        private static int id = 0;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string CreatedDate { get; init; }
        private string content;

        public string Content
        {
            get { return content; }
            set
            {
                if (value.Length <= 255)
                {
                    content = value;
                }
                else
                {
                    for (int i = 0; i <= 255; i++)
                    {
                        content += value[i];
                    }
                }
            }
        }
        public Comment(string creatDate,string content)
        {
            id++;
            Id = id;
            CreatedDate = creatDate;
            this.Content = content;
        }

    }
}
