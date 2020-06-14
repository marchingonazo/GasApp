using System;
using System.Net.Mail;

namespace GasApp.Helpers
{
    public class EmailHelper
    {
        public static bool IsValidEmail(string email)
        {
            try
            {
                var correo = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
