using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        List<genericObj> data = new List<genericObj>();
        public MainPage()
        {
            InitializeComponent();
            BtnLogin.Clicked += BtnLogin_Clicked;
            BtnRegister.Clicked += BtnRegister_Clicked;
        }

        private void BtnRegister_Clicked(object sender, EventArgs e)
        {
            genericObj obj = new genericObj()
            {
                name = UserName.Text,
                password = UserPass.Text
            };
            data.Add(obj);
            UserName.Text = string.Empty;
            UserPass.Text = string.Empty;
            lblResult.Text = "Usuario Registado";
            lblResult.TextColor = Color.Green;
            Thread.Sleep(1000);
        }

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            if(data.Capacity > 0)
            {
                genericObj obj = new genericObj() { name = UserName.Text, password = UserPass.Text };
                var res = data.Find(c => c.name.Equals(UserName.Text) && c.password.Equals(UserPass.Text));


                if (res != null)
                {
                    lblResult.Text = "Bienvenido " + UserName.Text;
                    lblResult.TextColor = Color.Green;
                    UserName.Text = string.Empty;
                    UserPass.Text = string.Empty;
                }
                else
                {
                    lblResult.Text = "Nombre o contraseña incorrectos";
                    lblResult.TextColor = Color.Red;
                    UserName.Text = string.Empty;
                    UserPass.Text = string.Empty;
                }
            }
            else
            {
                lblResult.Text = "Debes registrar al menos 1 usuario...";
                lblResult.TextColor = Color.Orange;
                UserName.Text = string.Empty;
                UserPass.Text = string.Empty;
            }
        }
    }
}
