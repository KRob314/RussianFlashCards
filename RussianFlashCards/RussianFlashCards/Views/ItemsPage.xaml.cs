using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using RussianFlashCards.Models;
using RussianFlashCards.Views;
using RussianFlashCards.ViewModels;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace RussianFlashCards.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
            Application.Current.Properties["Items"] = viewModel.Items;

        }

        public async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;


                await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        public async void NextItem( Item item)
        {

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
        }

        public async void LoopItems(Models.Item item)
        {
            var items = (ObservableCollection<Models.Item>)Application.Current.Properties["Items"];
            int currentIndex = items.IndexOf(item);
            int maxIndex = items.Count;

            if (currentIndex + 1 < maxIndex)
            {
                ContentPage cp = new ContentPage();
                var newItem = items[currentIndex + 1] as Item;

                await cp.Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(newItem)));

            }
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}