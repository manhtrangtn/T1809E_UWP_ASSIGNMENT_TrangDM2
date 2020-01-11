using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using T1809E_UWP_ASSIGNMENT_TrangDM2.Models;
using T1809E_UWP_ASSIGNMENT_TrangDM2.Services;
using T1809E_UWP_ASSIGNMENT_TrangDM2.Services.Implements;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace T1809E_UWP_ASSIGNMENT_TrangDM2.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UserInformationPage : Page
    {
        private IMemberService memberService = new MemberService();
        private IFileIoService fileIoService = new FileIoService();
        public UserInformationPage()
        {
            this.InitializeComponent();
        }

        private void LogoutHandle(object sender, RoutedEventArgs e)
        {
            ApplicationLayout.token = "";
            fileIoService.WriteToFile("token.dat", "");
            this.Frame.Navigate(typeof(LoginPage));
        }

        private async void InformationLoadHandle(object sender, RoutedEventArgs e)
        {
            MainContent.Visibility = Visibility.Collapsed;
            loading.Visibility = Visibility.Visible;
            loading.IsActive = true;
            var info = await memberService.GetMemberInformation(ApplicationLayout.token);
            Member member = JsonConvert.DeserializeObject<Member>(info);
            FullName.Text = member.firstName + " " + member.lastName;
            Phone.Text = member.phone;
            Email.Text = member.email;
            Address.Text = member.address;
            BirthDay.Text = member.birthday;
            try
            {
                var uri = new Uri(member.avatar);
                ProfilePicture.ProfilePicture = new BitmapImage(uri);
            }
            catch
            {
                ProfilePicture.ProfilePicture = null;
            }
            loading.Visibility = Visibility.Collapsed;
            loading.IsActive = false;
            MainContent.Visibility = Visibility.Visible;
        }
    }
}
