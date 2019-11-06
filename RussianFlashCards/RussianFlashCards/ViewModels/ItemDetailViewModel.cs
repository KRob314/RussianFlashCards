using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Plugin.TextToSpeech;
using Plugin.TextToSpeech.Abstractions;
using RussianFlashCards.Models;
using RussianFlashCards.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace RussianFlashCards.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public ICommand SpeakCommand => new Command((item) => Speak());
        public ICommand NextCommand => new Command((item) => Next());
        public ICommand GoogleTranslate => new Command((item) => OpenGoogleTranslate());

        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.English;
            Item = item;

           
        }

        public async void Speak()
        {
            var languages = CrossTextToSpeech.Current.GetInstalledLanguages();
            CrossLocale crossLocale = new CrossLocale();
            crossLocale.Language = "ru-RU";

            await CrossTextToSpeech.Current.Speak(Item.Russian, crossLocale);
        }

        public  void Next()
        {
            var items = (ObservableCollection<Models.Item>)Application.Current.Properties["Items"];
            int currentIndex = items.IndexOf(Item);
            int maxIndex = items.Count;
            var item = items[0] ; 

          

            if (currentIndex + 1 < maxIndex)
            {              
                item = items[currentIndex + 1] as Item;
            }
            else
            {
                item = items[0] as Item;
            }

            var a = App.Current.MainPage;

            ContentPage cp = new ContentPage();

            cp.Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
            //LoadNextItem(item);

        }

        public  void LoadNextItem(Item item)
        {
            ItemsPage itemsPage = new ItemsPage();
            itemsPage.NextItem(item);
            //await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
        }

        public void OpenGoogleTranslate()
        {
            Device.OpenUri(new Uri("https://translate.google.com/#view=home&op=translate&sl=ru&tl=en&text=" + Item.Russian));


        }
    }
}
