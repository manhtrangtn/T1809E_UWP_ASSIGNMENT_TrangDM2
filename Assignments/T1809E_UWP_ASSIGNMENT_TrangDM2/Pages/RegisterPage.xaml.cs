using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using T1809E_UWP_ASSIGNMENT_TrangDM2.Models;
using T1809E_UWP_ASSIGNMENT_TrangDM2.Services;
using T1809E_UWP_ASSIGNMENT_TrangDM2.Services.Implements;
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

namespace T1809E_UWP_ASSIGNMENT_TrangDM2.Pages
{

    public sealed partial class RegisterPage : Page
    {
        private int _choosedGender = 2;
        private String _birthDay;
        private Validator validator = new Validator();
        private readonly IMemberService memberService = new MemberService();
        public RegisterPage()
        {
            this.InitializeComponent();
        }

        private void Gender_Choose(object sender, RoutedEventArgs e)
        {
            var chooseRadioButton = (RadioButton)sender;
            if (chooseRadioButton == null) return;
            switch (chooseRadioButton.Tag)
            {
                case "Male":
                    _choosedGender = 1;
                    break;
                case "Female":
                    _choosedGender = 0;
                    break;
                case "Other":
                    _choosedGender = 2;
                    break;
            }
        }

        public void IsPasswordConfirm(object sender, KeyRoutedEventArgs e)
        {
            if (!validator.IsPasswordMatch(password.Password, confirmPassword.Password))
            {
                pcfAlert.Text = "Password did not match.";
            }
            else
            {
                pcfAlert.Text = "";
            }
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
        public void IsPhoneNumberValid(object sender, KeyRoutedEventArgs e)
        {
            if (!validator.IsPhoneNumber(phone.Text))
            {
                phoneAlert.Text = "Enter Viet Nam's phone number (+84xxxxxxxxx).";
            }
            else
            {
                phoneAlert.Text = "";
            }
        }
        public bool IsNotNull(string str)
        {
            if (!validator.IsNotNullAndNotEmpty(str))
            {
                NotNullAlert.Text = "Please fill all field before submit";
                return false;
            }
            else
            {
                NotNullAlert.Text = "";
                return true;
            }
        }
        private void Birthday_OnDateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            if (sender.Date.HasValue)
            {
                _birthDay = sender.Date.Value.Date.ToString("yyyy-MM-dd");
            }
        }

        private async void RegisterSubmit(object sender, RoutedEventArgs e)
        {
            loading.IsActive = true;
            var member = new Member();
            member.firstName = firstName.Text;
            member.lastName = lastName.Text;
            member.address = address.Text;
            member.password = password.Password;
            member.phone = phone.Text;
            member.gender = _choosedGender;
            member.birthday = _birthDay;
            member.email = email.Text;
            member.avatar = avatar.Text;
            if (member.IsValid())
            {
                NotNullAlert.Text = "Please wait!";
                string resp = await memberService.Register(member);
                var statusCode = (string)JObject.Parse(resp)["status"];
                if (statusCode == "1")
                {
                    this.Frame.Navigate(typeof(Pages.LoginPage));
                } else
                {
                    NotNullAlert.Text = "Register failed!";
                }
            }
            else
            {
                NotNullAlert.Text = "Please fill all field before submit!";
            }
        }

        private void redirectLogin(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pages.LoginPage));
        }
    }
}
