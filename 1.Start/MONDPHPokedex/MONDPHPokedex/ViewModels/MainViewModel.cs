using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            PopulateList();
        }

        void PopulateList()
        {
            PokemonsList = new ObservableCollection<Pokemon>();
            PokemonsList.Add(new Pokemon
            {
                Name = "Pikachu",
                Description = "Pikachu is an Electric type Pokémon introduced in Generation 1. It is known as the Mouse Pokémon.",
                ImageUrl = "https://mondphpokedexapi.azurewebsites.net/images/pikachu.jpg"
            });

            PokemonsList.Add(new Pokemon
            {
                Name = "Bulbasaur",
                Description = "Bulbasaur is a Grass/Poison type Pokémon introduced in Generation 1. It is known as the Seed Pokémon.",
                ImageUrl = "https://mondphpokedexapi.azurewebsites.net/images/bulbasaur.jpg"
            });

            PokemonsList.Add(new Pokemon
            {
                Name = "Charmander",
                Description = "Charmander is a Fire type Pokémon introduced in Generation 1. It is known as the Lizard Pokémon.",
                ImageUrl = "https://mondphpokedexapi.azurewebsites.net/images/charmander.jpg"
            });

            PokemonsList.Add(new Pokemon
            {
                Name = "Butterfree",
                Description = "Butterfree is a Bug/Flying type Pokémon introduced in Generation 1. It is known as the Butterfly Pokémon.",
                ImageUrl = "https://mondphpokedexapi.azurewebsites.net/images/butterfree.jpg"
            });

            PokemonsList.Add(new Pokemon
            {
                Name = "Pidgeotto",
                Description = "Pidgeotto is a Normal/Flying type Pokémon introduced in Generation 1. It is known as the Bird Pokémon.",
                ImageUrl = "https://mondphpokedexapi.azurewebsites.net/images/pidgeotto.jpg"
            });

            PokemonsList.Add(new Pokemon
            {
                Name = "Raichu",
                Description = "Raichu is an Electric type Pokémon introduced in Generation 1. It is known as the Mouse Pokémon.\nRaichu has a new Alolan form introduced in Pokémon Sun/Moon.",
                ImageUrl = "https://mondphpokedexapi.azurewebsites.net/images/raichu.jpg"
            });
        }

        void SearchList(string parameter)
        {

            if (!string.IsNullOrWhiteSpace(parameter))
            {
                var searchResult = PokemonsList.Where(c => c.Name.ToLower().Contains(parameter.ToLower()));
                PokemonsList = new ObservableCollection<Pokemon>(searchResult);
            }
            else
            {
                PopulateList();
            }
        }

        async  void NavigateToPokemonDetails(Pokemon selectedItem)
        {
            await App.Page.Navigation.PushAsync(new PokemonDetailsPage(selectedItem));
        }
    }
}
