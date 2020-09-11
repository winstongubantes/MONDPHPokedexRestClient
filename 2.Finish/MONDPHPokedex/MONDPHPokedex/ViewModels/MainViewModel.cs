using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MONDPHPokedex.ViewModel
{
    public class MainViewModel:BaseViewModel
    {
       

        private string _search;
        public string Search
        {
            get => _search;
            set {
                SetProperty(ref _search, value);
                SearchList(_search);
            }
        }
        public Pokemon _pokemon;
        public Pokemon Pokemon
        {
            get => _pokemon;
            set {
                SetProperty(ref _pokemon, value);
                if(_pokemon != null) {
                    NavigateToPokemonDetailsCommand.Execute(_pokemon);
                    _pokemon = null;
                }

            }
        }

        private ObservableCollection<Pokemon> _pokemonsList;
        public ObservableCollection<Pokemon> PokemonsList
        {
            get => _pokemonsList;
            set => SetProperty(ref _pokemonsList, value);
        }

        public ICommand NavigateToPokemonDetailsCommand { get; set; }

        public MainViewModel()
        {
            NavigateToPokemonDetailsCommand = new Command<Pokemon>(NavigateToPokemonDetails);
            SearchList(string.Empty);
        }

        private async void SearchList(string parameter)
        {
            using (var httpClient = new HttpClient())
            {
                var baseUrl = "https://mondphpokedexapi.azurewebsites.net/pokemon/";
                var response = await httpClient.GetAsync($"{baseUrl}{parameter}");
                var stringValue = await response.Content.ReadAsStringAsync();
                var pokemonList = JsonConvert.DeserializeObject<List<Pokemon>>(stringValue);

                Debug.WriteLine($"response status{response.StatusCode}\n\nresult: {stringValue}");

                PokemonsList = new ObservableCollection<Pokemon>(pokemonList);
            }
        }

        async  void NavigateToPokemonDetails(Pokemon selectedItem)
        {
            await App.Page.Navigation.PushAsync(new PokemonDetailsPage(selectedItem));
        }
    }
}
