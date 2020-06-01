using System;
using System.Collections.Generic;
using System.Text;


namespace GasApp.Models
{
    using SQLite;
    
    public class Registration
    {
        [PrimaryKey, AutoIncrement, Unique]
        public string User { get; set; }
        [MaxLength(10)]
        public string Pass { get; set; }
        public string Email { get; set; }
        public byte[] Image { get; set; }
        public int Remembered { get; set; }       
    }
}
