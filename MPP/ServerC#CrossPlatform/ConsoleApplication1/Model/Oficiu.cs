using System;
namespace Model
{
    
     public class Oficiu
    {
        private string User;
        private string Password;

        public Oficiu(string user, string password)
        {
            User = user;
            Password = password;
        }

        public string User1
        {
            get { return User; }
            set { User = value; }
        }

        public string Password1
        {
            get { return Password; }
            set { Password = value; }
        }
    }
    
}