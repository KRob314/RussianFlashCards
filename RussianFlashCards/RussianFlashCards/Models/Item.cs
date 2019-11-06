using System;

namespace RussianFlashCards.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string English { get; set; }
        public string Russian { get; set; }
        public string Phonetic { get; set; }
        public string ItemType { get; set; }
    }

    public static class ItemTypes
    {
        public static string Word = "Word";
        public static string Phrase = "Phrase";
        public static string Weekdays = "Weekdays";
        public static string Numbers = "Numbers";
    }
}