using RussianFlashCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RussianFlashCards.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;

        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Browse, Title="Browse" },
                new HomeMenuItem {Id = MenuItemType.About, Title="About" }, 
                new HomeMenuItem {Id = MenuItemType.Words, Title = "Words" },
                new HomeMenuItem{Id = MenuItemType.Phrases, Title = "Phrases"},
                new HomeMenuItem{Id = MenuItemType.Weekdays, Title="Weekdays"},
                new HomeMenuItem{Id = MenuItemType.Numbers, Title = "Numbers"}
            };

            ListViewMenu.ItemsSource = menuItems.OrderBy(m => m.Title);

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}