using System;
namespace MONDPHPokedex.ViewModel
{
    public class PokemonDetailsViewModel:BaseViewModel
    {
        private Pokemon _pokemon;
        public Pokemon Pokemon
        {
            get => _pokemon;
            set
            {
                SetProperty(ref _pokemon, value);
            }
        }
        public PokemonDetailsViewModel(Pokemon pokemon)
        {
            Pokemon = pokemon;
        }
    }
}
