using System;
namespace GasApp.Models
{
    public class UserRequest
    {
        public string Name { get; set; }
        public string Pass { get; set; }
        public string ConfPass { get; set; }
        public bool Remembered { get; set; }
        public string Email { get; set; }
        public string _ImagePath { get; set; }
        public byte[] _Image { get; set; }
        public DateTime Date { get; set; }
        public string Phone { get; set; }
    }
}
