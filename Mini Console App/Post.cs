using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Console_App
{
    internal class Post
    {
        private static int id = 0;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}
		public string CreatedDate { get; init; }
		private string title;

		public string Title
		{
			get { return title; }
			set {
				if (value.Length<=50)
				{
                    title = value;
                }
				else
				{
					for (int i = 0; i <= 50; i++)
					{
						title += value[i];
					}
				}
			}
		}

        private string description;

        public string Description
        {
            get { return description; }
            set
            {
                if (value.Length <= 255)
                {
                    description = value;
                }
                else
                {
                    for (int i = 0; i <= 255; i++)
                    {
                        description += value[i];
                    }
                }
            }
        }

        private Comment[] comments=new Comment[0];

        public Comment[] Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        public string postType { get; set; }
        public enum PostType
        {
            News,
            Blogs,
            Product
        }
        public Post(string createdDate, string title,  string description, string postType)
        {
            id++;
            Id = id;
            CreatedDate = createdDate;
            Title = title;
            Description = description;
            this.postType = postType;
        }
    }
}
