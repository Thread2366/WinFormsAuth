using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace WinFormsAuth.Model
{
    class CredentialsManager
    {
        private static Regex mailValidateRegex = new Regex(@"^[\d\w_\.\-]+?@\w+\.\w+$");

        private CredContext context;

        public CredentialsManager()
        {
            context = new CredContext();
        }

        public string Register(string username, string password, string mail, Sex sex)
        {
            if (string.IsNullOrEmpty(username)) return "Empty username";
            if (string.IsNullOrEmpty(password)) return "Empty password";
            if (!mailValidateRegex.IsMatch(mail)) return "Invalid mail";
            context.Credentials.Add(new Credential()
            {
                Username = username,
                PasswordHash = Crypto.HashPassword(password),
                Mail = mail,
                Sex = sex
            });
            return Accept();
        }

        public string Auth(string username, string password)
        {
            if (string.IsNullOrEmpty(username)) return "Empty username";
            if (string.IsNullOrEmpty(password)) return "Empty password";
            var cred = context.Credentials.Find(username);
            if (cred == null) return "Such login does not exist";
            if (!Crypto.VerifyHashedPassword(cred.PasswordHash, password)) return "Wrong password";
            return "Success";
        }

        public string PasswordRecovery(string username, string mail, string password)
        {
            if (string.IsNullOrEmpty(username)) return "Empty username";
            if (string.IsNullOrEmpty(password)) return "Empty password";
            if (!mailValidateRegex.IsMatch(mail)) return "Invalid mail";
            var cred = context.Credentials.Find(username);
            if (cred == null) return "Such login does not exist";
            if (!cred.Mail.Equals(mail)) return "Wrong mail";
            cred.PasswordHash = Crypto.HashPassword(password);

            return Accept();
        }

        private string Accept()
        {
            try
            {
                context.SaveChanges();
                return "Success";
            }
            catch (Exception exception)
            {
                while (exception.InnerException != null) exception = exception.InnerException;
                return exception.Message;
            }
        }
    }
}
