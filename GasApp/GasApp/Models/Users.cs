using System;
using System.Collections.Generic;
using System.Text;


namespace GasApp.Models
{
    using SQLite;
    
    public class Users
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int IdUser { get; set; }       
        public string Name { get; set; }
        [MaxLength(10)]
        public string Pass { get; set; }
        [Unique]
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public byte[] _Image { get; set; }
        public int Remembered { get; set; }       
    }
}
