namespace Lab2MPPC.Domain
{
    public class Oficiu_
    {
        private string User;
        private string Password;

        public Oficiu_(string user, string password)
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