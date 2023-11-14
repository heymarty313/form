using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class Authorization
    {
        static public string Role, familia, User;
        static public void Authorization1(string login, string password)
        {
            try
            {
                DBConnection.msCommand.CommandText = @"SELECT name_role from sp_role join account on account.id_role = sp_role.id_role WHERE login = '" + login + "' and Password = '" + password + "' ";
                Object result = DBConnection.msCommand.ExecuteScalar();
                if(result != null)
                {
                    Role = result.ToString();
                    User = login;
                }
                else
                {
                    Role = null;
                    familia = null;
                }
            }
            catch 
            {
                Role = User = null;
                MessageBox.Show("Ошибка при авторизации!");
            }
        }
        static public string AuthorizationName(string login)
        {
            try
            {
                DBConnection.msCommand.CommandText = @"SELECT familia FROM account WHERE Login = '" + login + "'";
                Object result = DBConnection.msCommand.ExecuteScalar() ;
                familia = result.ToString();
                return familia;
            }
            catch 
            { 
                return null;
            }
        }
    }
}
