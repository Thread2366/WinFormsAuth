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
    public partial class AuthForm : Form
    {

        public AuthForm()
        {
            Initialize();
        }

        private void Auth()
        {
            var manager = new CredentialsManager();
            var message = manager.Auth(
                loginInput.Text,
                passwordInput.Text);
            MessageBox.Show(message);
        }
    }
}
