using ApiConsumeApp.MVVM.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiConsumeApp.MVVM.ViewModels
{
    public  partial class MainPageViewModel:ObservableObject
    {
        [ObservableProperty]
        private List<Amiibo> amiibos;

        private List<Amiibo> amiiboList;
        HttpClient client;
        string allAmiibosEndPoint = "https://amiiboapi.com/api/amiibo/";

        public MainPageViewModel() 
        {
            client = new HttpClient();
            
        }
        public async Task FillData()
        {
            client.BaseAddress = new Uri(allAmiibosEndPoint);
            var response = await client.GetAsync(client.BaseAddress);
            if (response.IsSuccessStatusCode)
            {
                var json=await response.Content.ReadAsStringAsync();
                var amiiboModel=JsonSerializer.Deserialize<AmiiboModel>(json);
                amiiboList= amiiboModel.Amiibos;
                Amiibos = amiiboList;
            }
        }
        public void FilterList(String filter)
        {
            Amiibos = amiiboList.Where(x => x.name.ToLower().Contains(filter.ToLower())).ToList();
        }
    }
}
