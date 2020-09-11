using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MONDPHPokedex.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MONDPHPokedex
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PokemonDetailsPage : ContentPage
    {


        public PokemonDetailsPage(Pokemon pokemon)
        {
            InitializeComponent();
            this.Title = pokemon.Name;
            this.BindingContext = new PokemonDetailsViewModel(pokemon);
        }
    }
}