using System.Net.Http.Json;

namespace GoldTodayApp
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();

            RadioButton_CheckedChanged(null, null);
        }

        HttpClient httpClient = new HttpClient();


        private async void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {

            if (rbGold.IsChecked)
            {
                var response = await httpClient.GetAsync("https://api.gold-api.com/price/XAU");

                var goldInfo = await response.Content.ReadFromJsonAsync<GoldData>();

                if (goldInfo != null)
                {
                     lblName.Text = goldInfo.Name;
                    lblSymbol.Text = goldInfo.Symbol;
                    lblPrice.Text = goldInfo.Price.ToString() + " $ ";
                    lblUpdated.Text = goldInfo.UpdatedAt.ToString();
                }
               

            }
            else if (rbBitCoin.IsChecked)
            {

                var response = await httpClient.GetAsync("https://api.gold-api.com/price/BTC");

                var goldInfo = await response.Content.ReadFromJsonAsync<GoldData>();

                if (goldInfo != null)
                {
                    lblName.Text = goldInfo.Name;
                    lblSymbol.Text = goldInfo.Symbol;
                    lblPrice.Text = goldInfo.Price.ToString() + " $ ";
                    lblUpdated.Text = goldInfo.UpdatedAt.ToString();
                }

            }
            else
            {
                var response = await httpClient.GetAsync("https://api.gold-api.com/price/XAG");

                var goldInfo = await response.Content.ReadFromJsonAsync<GoldData>();

                if (goldInfo != null)
                {
                    lblName.Text = goldInfo.Name;
                    lblSymbol.Text = goldInfo.Symbol;
                    lblPrice.Text = goldInfo.Price.ToString() + " $ ";
                    lblUpdated.Text = goldInfo.UpdatedAt.ToString();
                }

            }

        }

        public class GoldData
        {
            public string Symbol { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
            public DateTime UpdatedAt { get; set; }

            public GoldData(string symbol,string name , double price, DateTime updatedAt)
            {
                this.Symbol = symbol;
                this.Name = name;
                this.Price = price;
                this.UpdatedAt = updatedAt;
            }
        }

    }

}
