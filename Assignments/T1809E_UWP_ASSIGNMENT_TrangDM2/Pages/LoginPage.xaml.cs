using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using T1809E_UWP_ASSIGNMENT_TrangDM2.Services;
using T1809E_UWP_ASSIGNMENT_TrangDM2.Utils;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using T1809E_UWP_ASSIGNMENT_TrangDM2.Services.Implements;
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace T1809E_UWP_ASSIGNMENT_TrangDM2.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        private Validator validator = new Validator();
        private readonly IMemberService memberService = new MemberService();
        private readonly IFileIoService fileIoService = new FileIoService();

        public LoginPage()
        {
            this.InitializeComponent();
        }

        public void IsEmailValid(object sender, KeyRoutedEventArgs e)
        {
            if (!validator.IsEmail(email.Text))
            {
                emailAlert.Text = "Please enter valid email.";
            }
            else
            {
                emailAlert.Text = "";
            }
        }
        private void redirectRegister(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pages.RegisterPage));
        }

        private async void LoginHandle(object sender, RoutedEventArgs e)
        {
            loading.IsActive = true;
            var em = email.Text;
            var pass = password.Password;

            if (validator.IsEmail(em)){
                emailAlert.Text = "";
                if (!string.IsNullOrEmpty(pass)){
                    passwordAlert.Text = "";
                    var resp = await memberService.Login(em, pass);
                    var token = (string)JObject.Parse(resp)["token"];
                    if (token != null)
                    {
                        fileIoService.WriteToFile("token.dat", token);
                        ApplicationLayout.token = token;
                        this.Frame.Navigate(typeof(UserInformationPage));
                    } else
                    {

                    }
                }
                else
                {
                    passwordAlert.Text = "Please enter password";
                }
            }
            else
            {
                emailAlert.Text = "Inlavid email, please enter valid email format.";
            }
        }
    }
}
