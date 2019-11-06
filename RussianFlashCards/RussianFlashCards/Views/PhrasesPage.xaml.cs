﻿using Plugin.TextToSpeech;
using Plugin.TextToSpeech.Abstractions;
using RussianFlashCards.Models;
using RussianFlashCards.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RussianFlashCards.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PhrasesPage : ContentPage
	{
        ItemsViewModel viewModel;

        public PhrasesPage (ItemsViewModel viewModel)
		{
			InitializeComponent ();
            BindingContext = this.viewModel = viewModel;
            Application.Current.Properties["Items"] = viewModel.Items;
        }

        public PhrasesPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ItemsViewModel();
            Application.Current.Properties["Items"] = viewModel.Items;
        }

        public async void Speak(string str)
        {
            var languages = CrossTextToSpeech.Current.GetInstalledLanguages();
            CrossLocale crossLocale = new CrossLocale();
            crossLocale.Language = "ru-RU";

            await CrossTextToSpeech.Current.Speak(str, crossLocale);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadPhrasesCommand.Execute(null);

        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }
    }
}