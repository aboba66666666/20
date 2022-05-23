using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace _PR20
{
    public partial class PostRequest : ContentPage
    {
        public PostRequest()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var user = new PostUser();
            user.Name = "stas polyanskiy";
            user.Job = "Student";
            string json = JsonConvert.SerializeObject(user);
            HttpContent content = new StringContent(json);
            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = await client.PutAsync("https://reqres.in/api/users", content);
                response.EnsureSuccessStatusCode();
                var answer = await response.Content.ReadAsStringAsync();
                PostUser answer_user = JsonConvert.DeserializeObject<PostUser>(answer);
                Label1.Text = "Имя: " + answer_user.Name + "\r\n" + "Работа: " + answer_user.Job + "\r\n" + "ID: " + Convert.ToString(answer_user.ID) + "\r\n" + "Время обновления: " + Convert.ToString(answer_user.UpdateAt);
            }
            catch
            {

            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new PutRequest());
        }
    }
}