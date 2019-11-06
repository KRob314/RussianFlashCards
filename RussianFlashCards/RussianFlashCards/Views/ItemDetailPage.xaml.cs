
using Plugin.TextToSpeech;
using Plugin.TextToSpeech.Abstractions;
using RussianFlashCards.Models;
using RussianFlashCards.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RussianFlashCards.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        //public ICommand NextCommand => new Command((item) => Next());

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            Button button = new Button
            {
                Text = "Speak"
            };

            button.Clicked += async (s, e) =>
            {
                Speak(viewModel.Item.Russian);
            };

            BindingContext = this.viewModel = viewModel;


            Speak(viewModel.Item.Russian);

        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                English = "Item 1",
                Russian = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        public async void Speak(string str)
        {
            var languages = CrossTextToSpeech.Current.GetInstalledLanguages();
            CrossLocale crossLocale = new CrossLocale();
            crossLocale.Language = "ru-RU";


            await CrossTextToSpeech.Current.Speak(str, crossLocale);
        }

        public async void Next()
        {
            var items = (ObservableCollection<Models.Item>)Application.Current.Properties["Items"];
            int currentIndex = items.IndexOf(viewModel.Item);
            int maxIndex = items.Count;

            if (currentIndex + 1 < maxIndex)
            {
                ContentPage cp = new ContentPage();
                var item = items[currentIndex + 1] as Item;

                await cp.Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            }


        }
    }
}
