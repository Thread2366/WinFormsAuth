using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WinFormsAuth
{
    public partial class RecoveryForm : Form
    {
        TableLayoutPanel panel = new TableLayoutPanel() { Dock = DockStyle.Fill };
        TableLayoutPanel inputsPanel = new TableLayoutPanel() { Dock = DockStyle.Fill };
        TableLayoutPanel buttonsPanel = new TableLayoutPanel() { Dock = DockStyle.Fill };
        TextBox loginInput = new TextBox() { Dock = DockStyle.Fill };
        TextBox passwordInput = new TextBox() { Dock = DockStyle.Fill, PasswordChar = '*' };
        TextBox mailInput = new TextBox() { Dock = DockStyle.Fill };
        Label loginLabel = new Label() { 
            Dock = DockStyle.Fill, 
            Text = "Логин",
            TextAlign = ContentAlignment.TopCenter,
            Padding = new Padding(0, 5, 0, 0)
        };
        Label mailLabel = new Label()
        {
            Dock = DockStyle.Fill,
            Text = "E-mail",
            TextAlign = ContentAlignment.TopCenter,
            Padding = new Padding(0, 5, 0, 0)
        };
        Label passwordLabel = new Label() { 
            Dock = DockStyle.Fill, 
            Text = "Новый пароль",
            TextAlign = ContentAlignment.TopCenter,
            Padding = new Padding(0, 5, 0, 0)
        };
        Button submit = new Button() { Dock = DockStyle.Fill, Text = "Восстановить" };
        Button goBack = new Button() { Dock = DockStyle.Fill, Text = "Назад" };

        void Initialize()
        {
            buttonsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            buttonsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50));

            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 100));

            inputsPanel.Controls.Add(loginLabel, 0, 0);
            inputsPanel.Controls.Add(loginInput, 1, 0);
            inputsPanel.Controls.Add(mailLabel, 0, 1);
            inputsPanel.Controls.Add(mailInput, 1, 1);
            inputsPanel.Controls.Add(passwordLabel, 0, 2);
            inputsPanel.Controls.Add(passwordInput, 1, 2);
            buttonsPanel.Controls.Add(submit, 0, 0);
            buttonsPanel.Controls.Add(goBack, 0, 1);

            panel.Controls.Add(inputsPanel);
            panel.Controls.Add(buttonsPanel);
            panel.Controls.Add(new Panel());
            this.Controls.Add(panel);

            submit.Click += (sender, e) => Recover();
            goBack.Click += (sender, e) => this.Close();
        }
    }
}
