using System;
using System.Collections.Generic;
using System.Text;

namespace GasApp.Models
{
    public class Registration
    {
        public string User { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public int Remembered { get; set; }
    }
}
