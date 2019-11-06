using System;
using System.Collections.Generic;
using System.Text;

namespace RussianFlashCards.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Words,
        Phrases,
        Weekdays,
        Numbers
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
