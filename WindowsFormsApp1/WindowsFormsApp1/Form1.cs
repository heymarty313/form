using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static public string loginActive;
        static public string whois;
        public Form1()
        {
            InitializeComponent();
        }
        private void From1_Load(object sender, EventArgs e)
        {
            DBConnection.ConnectionDB();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            if(textBox3.Text != "" && textBox4.Text != "")
            {
                Authorization.Authorization1(textBox3.Text, textBox4.Text);
                switch(Authorization.Role)
                {
                    case null:
                        {
                            MessageBox.Show("Такого аккаунта не существует!", "Проверьте данные и попробуйте снова", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                   case "Администратор":
                        {
                            loginActive= textBox3.Text;
                            whois= "Администратор";
                            Authorization.User = textBox3.Text;

                            string familia = Authorization.AuthorizationName(textBox3.Text);
                            Authorization.familia = familia;
                            MessageBox.Show(familia + ", добро пожаловать в меню администратора!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            AdminForm admin = new AdminForm();
                            admin.Show();
                            break;
                        }
                    case "Пользователь":
                        {
                            loginActive = textBox3.Text;
                            whois = "Пользователь";
                            Authorization.User = textBox3.Text;

                            string familia = Authorization.AuthorizationName(textBox3.Text);
                            Authorization.familia = familia;
                            MessageBox.Show(familia + ", добро пожаловать в меню пользователя!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            UserForm user = new UserForm();
                            user.Show();
                            break;
                        }
                }
            }
            else
            {
                MessageBox.Show("Заполните все обязательные поля!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}
