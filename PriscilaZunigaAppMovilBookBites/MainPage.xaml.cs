using Newtonsoft.Json;
using PriscilaZunigaAppMovilBookBites.Models;

namespace PriscilaZunigaAppMovilBookBites
{
    public partial class MainPage : ContentPage
    {
       

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7223/api/");
            var response = client.GetAsync("pzlibro").Result;
            if (response.IsSuccessStatusCode)
            {
                var pzlibros = response.Content.ReadAsStringAsync().Result;
                var pzlibrosList = JsonConvert.DeserializeObject<List<PZLibro>>(pzlibros);
                listView.ItemsSource = pzlibrosList;
            }
        }
    }

}
