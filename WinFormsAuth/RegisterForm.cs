using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsAuth.Model;

namespace WinFormsAuth
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            Initialize();
        }

        private void Register()
        {
            var manager = new CredentialsManager();
            var message = manager.Register(
                loginInput.Text,
                passwordInput.Text,
                mailInput.Text,
                (Sex)Enum.Parse(typeof(Sex), sexInput.Text));
            MessageBox.Show(message);
        }
    }
}
