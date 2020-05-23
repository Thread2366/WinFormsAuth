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
    public partial class RecoveryForm : Form
    {

        public RecoveryForm()
        {
            Initialize();
        }

        private void Recover()
        {
            var manager = new CredentialsManager();
            var message = manager.PasswordRecovery(
                loginInput.Text,
                mailInput.Text,
                passwordInput.Text);
            MessageBox.Show(message);
        }
    }
}
