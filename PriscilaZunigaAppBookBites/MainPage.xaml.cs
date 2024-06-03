using Newtonsoft.Json;
using PriscilaZunigaAppBookBites.Models;

namespace PriscilaZunigaAppBookBites
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
            var response = client.GetAsync("Pzlibro").Result;
            if (response.IsSuccessStatusCode)
            {
                var Pzlibros = response.Content.ReadAsStringAsync().Result;
                var PzlibrosList = JsonConvert.DeserializeObject<List<PZLibro>>(Pzlibros);
                listView.ItemsSource = PzlibrosList;
            }

        }
    }

}
