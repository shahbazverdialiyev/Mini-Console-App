using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Mini_Console_App
{
    internal class User : IAccaount
    {
        private static int id = 0;
        public int Id { get { return id; } set { id = value; } }
        public string CreatedDate { get; init; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public User(string createdDate, string name, string surname, string password)
        {
            id++;
            Id = id;
            CreatedDate = createdDate;
            Name = name;
            Surname = surname;
            if (PasswordChecker(password))
            {
                Password = password;
            }
            Username = name.ToLower().ReplaceLetter() + "_" + surname.ToLower().ReplaceLetter();
        }

        public bool PasswordChecker(string password)
        {
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
            return isupper&&islower&&isdigit;
        }
    }
    internal static class StringExtension
    {
        public static string ReplaceLetter(this string str)
        {
            string newstr = "";
            foreach (var letter in str)
            {
                switch (letter)
                {
                    case 'ə':
                        newstr += "e";
                        break;
                    case 'ı':
                        newstr += "i";
                        break;
                    case 'ğ':
                        newstr += "g";
                        break;
                    case 'ş':
                        newstr += "sh";
                        break;
                    case 'ü':
                        newstr += "u";
                        break;
                    case 'ç':
                        newstr += "c";
                        break;
                    case 'ö':
                        newstr += "o";
                        break;
                    default:
                        newstr += letter;
                        break;
                }
            }
            return newstr;
        }
    }
}
