using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WinFormsAuth
{
    public partial class AuthForm : Form
    {
        TableLayoutPanel panel = new TableLayoutPanel() { Dock = DockStyle.Fill };
        TableLayoutPanel inputsPanel = new TableLayoutPanel() { Dock = DockStyle.Fill };
        TableLayoutPanel buttonsPanel = new TableLayoutPanel() { Dock = DockStyle.Fill };
        TextBox loginInput = new TextBox() { Dock = DockStyle.Fill };
        TextBox passwordInput = new TextBox() { Dock = DockStyle.Fill, PasswordChar = '*' };
        Label loginLabel = new Label() { 
            Dock = DockStyle.Fill, 
            Text = "Логин", 
            TextAlign = ContentAlignment.TopCenter, 
            Padding = new Padding(0, 5, 0, 0) };
        Label passwordLabel = new Label() {
            Dock = DockStyle.Fill,
            Text = "Пароль",
            TextAlign = ContentAlignment.TopCenter,
            Padding = new Padding(0, 5, 0, 0) };
        Button submit = new Button() { Dock = DockStyle.Fill, Text = "Войти" };
        Button register = new Button() { Dock = DockStyle.Fill, Text = "Регистрация" };
        Button recovery = new Button() { Dock = DockStyle.Fill, Text = "Восстановление пароля" };

        void Initialize()
        {
            inputsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            inputsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50));

            buttonsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            buttonsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            buttonsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            buttonsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 100));

            inputsPanel.Controls.Add(loginLabel, 0, 0);
            inputsPanel.Controls.Add(loginInput, 1, 0);
            inputsPanel.Controls.Add(passwordLabel, 0, 1);
            inputsPanel.Controls.Add(passwordInput, 1, 1);
            buttonsPanel.Controls.Add(submit, 0, 0);
            buttonsPanel.Controls.Add(register, 0, 1);
            buttonsPanel.Controls.Add(recovery, 1, 1);
            buttonsPanel.SetColumnSpan(submit, 2);

            panel.Controls.Add(inputsPanel);
            panel.Controls.Add(buttonsPanel);
            panel.Controls.Add(new Panel());
            this.Controls.Add(panel);

            submit.Click += (sender, e) => Auth();
            register.Click += (sender, e) => new RegisterForm().ShowDialog();
            recovery.Click += (sender, e) => new RecoveryForm().ShowDialog();
        }
    }
}
