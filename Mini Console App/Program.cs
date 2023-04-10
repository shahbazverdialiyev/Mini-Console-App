using Mini_Console_App;
using System.Diagnostics.Metrics;
using System.Drawing;

internal class Program
{
    private static void Main(string[] args)
    {
        User[] users = new User[0];
        Post[] posts = new Post[0];
        Console.WriteLine();
        Console.WriteLine("1. Login");
        Console.WriteLine("2. Register");
        Console.WriteLine("3. Exit");
        Console.WriteLine();
        Console.WriteLine("----   -------   ----------  -------------");
        Console.WriteLine();
        Console.Write(">>>  ");
        string command = Console.ReadLine();
        Console.WriteLine();
        while (command != "3")
        {
            if (command == "1")
            {
                Console.WriteLine("Login");
                Console.WriteLine();
                string username;
                string password;
                Console.Write("username: ");
                username = Console.ReadLine();
                Console.Write("password: ");
                password = Console.ReadLine();
                bool result = false;
                foreach (var user in users)
                {
                    Console.WriteLine(user.Username + " " + user.Password);
                    if (user.Username == username && user.Password == password)
                    {
                        result = true;
                        Console.WriteLine();
                        Console.WriteLine("1. Post create");
                        Console.WriteLine("2. Comment create");
                        Console.WriteLine("3. Exit");
                        Console.WriteLine("-------");
                        Console.WriteLine();
                        Console.Write(">>>  ");
                        command = Console.ReadLine();
                        Console.WriteLine();
                        while (command != "3")
                        {
                            if (command == "1")
                            {
                                Console.WriteLine();
                                Console.WriteLine("Post create");
                                Console.WriteLine();
                                Console.Write("Title: ");
                                string title;
                                title = Console.ReadLine();
                                Console.Write("Description: ");
                                string description;
                                description = Console.ReadLine();
                                Console.Write("Post Type  (");
                                foreach (Post.PostType type in Enum.GetValues(typeof(Post.PostType)))
                                {
                                    Console.Write($"  {type} ");
                                }
                                Console.Write("):  ");
                                string postType;
                                postType = Console.ReadLine();
                                Post post = new Post(DateTime.Now.ToString(), title, description, postType);
                                Array.Resize(ref posts, posts.Length + 1);
                                posts[posts.Length - 1] = post;
                            }
                            else if (command == "2")
                            {
                                bool result2 = false;
                                Console.WriteLine();
                                Console.WriteLine("Comment create");
                                Console.WriteLine();
                                Console.Write("Id: ");
                                int id;
                                while (!Int32.TryParse(Console.ReadLine(), out id))
                                {
                                    Console.WriteLine("eded yazin");
                                    Console.Write("Id: ");
                                }
                                foreach (var post in posts)
                                {
                                    if (post.Id == id)
                                    {
                                        result2 = true;
                                        Console.Write("Content: ");
                                        string content;
                                        content = Console.ReadLine();
                                        Comment comment = new Comment(DateTime.Now.ToString(), content);
                                        Comment[] newComments = post.Comments;
                                        Array.Resize(ref newComments, post.Comments.Length + 1);
                                        newComments[newComments.Length - 1] = comment;
                                        post.Comments = newComments;
                                        break;
                                    }
                                }
                                if (!result2)
                                {
                                    Console.WriteLine("bu id-e uygun post tapilmadi");
                                }
                            }
                            else
                            {
                                Console.WriteLine("1 , 2 ve ya 3 yazin");
                            }
                        }
                        break;
                    }
                    if (!result)
                    {
                        Console.WriteLine("username ve ya password yanlishdir");
                    }
                }

                Console.Write(">>>  ");
                command = Console.ReadLine();
                Console.WriteLine();
            }
            else if (command == "2")
            {
                Console.WriteLine("Register");
                Console.WriteLine();
                string name;
                string surname;
                string password;
                Console.Write("name: ");
                name = Console.ReadLine();
                Console.Write("surname: ");
                surname = Console.ReadLine();
                int userNumber = 0;
                foreach (var user in users)
                {
                    if (user.Name == name && user.Surname == surname)
                    {
                        userNumber++;
                    }
                }
                if (userNumber>0)
                {
                    surname += userNumber;
                }

                while (true)
                {
                    Console.Write("password: ");
                    password = Console.ReadLine();
                    bool isupper = false;
                    bool islower = false;
                    bool isdigit = false;
                    foreach (var letter in password)
                    {
                        if (Char.IsUpper(letter))
                        {
                            isupper = true;
                        }
                        else if (Char.IsLower(letter))
                        {
                            islower = true;
                        }
                        else if (Char.IsDigit(letter))
                        {
                            isdigit = true;
                        }
                    }
                    if (isupper && islower && isdigit)
                    {
                        User user = new User(DateTime.Now.ToString(), name, surname, password);
                        Array.Resize(ref users, users.Length + 1);
                        users[users.Length - 1] = user;
                        break;
                    }
                    Console.WriteLine("kecherli password yazin");
                }
                Console.WriteLine();
                Console.WriteLine("1. Post create");
                Console.WriteLine("2. Comment create");
                Console.WriteLine("3. Exit");
                Console.WriteLine("-------");
                Console.WriteLine();
                Console.Write(">>>  ");
                command = Console.ReadLine();
                Console.WriteLine();
                while (command != "3")
                {
                    if (command == "1")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Post create");
                        Console.WriteLine();
                        Console.Write("Title: ");
                        string title;
                        title = Console.ReadLine();
                        Console.Write("Description: ");
                        string description;
                        description = Console.ReadLine();
                        Console.Write("Post Type  (");
                        foreach (Post.PostType type in Enum.GetValues(typeof(Post.PostType)))
                        {
                            Console.Write($"  {type} ");
                        }
                        Console.Write("):  ");
                        string postType;
                        postType = Console.ReadLine();
                        Post post = new Post(DateTime.Now.ToString(), title, description, postType);
                        Array.Resize(ref posts, posts.Length + 1);
                        posts[posts.Length - 1] = post;
                    }
                    else if (command == "2")
                    {
                        bool result2 = false;
                        Console.WriteLine();
                        Console.WriteLine("Comment create");
                        Console.WriteLine();
                        Console.Write("Id: ");
                        int id;
                        while (!Int32.TryParse(Console.ReadLine(), out id))
                        {
                            Console.WriteLine("eded yazin");
                            Console.Write("Id: ");
                        }
                        foreach (var post in posts)
                        {
                            if (post.Id == id)
                            {
                                result2 = true;
                                Console.Write("Content: ");
                                string content;
                                content = Console.ReadLine();
                                Comment comment = new Comment(DateTime.Now.ToString(), content);
                                Comment[] newComments = post.Comments;
                                Array.Resize(ref newComments, post.Comments.Length + 1);
                                newComments[newComments.Length - 1] = comment;
                                post.Comments = newComments;
                                break;
                            }
                        }
                        if (!result2)
                        {
                            Console.WriteLine("bu id-e uygun post tapilmadi");
                        }
                    }
                    else
                    {
                        Console.WriteLine("1 , 2 ve ya 3 yazin");
                    }
                }
            }
            else
            {
                Console.WriteLine("1 , 2 ve ya 3 yazin");
            }
            Console.WriteLine();
            Console.Write(">>>  ");
            command = Console.ReadLine();
            Console.WriteLine();
        }
    }
}
