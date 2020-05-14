using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Oficii")]
     [Serializable]public class Oficiu
    {
        [Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string User { get; set; }
        [StringLength(40)]
        public string Password { get; set; }

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