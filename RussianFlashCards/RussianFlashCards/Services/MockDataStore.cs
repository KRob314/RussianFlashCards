using RussianFlashCards.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Storage;
//using Windows.Storage;

namespace RussianFlashCards.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = getData();

            //var mockItems = new List<Item>
            //{
            //    new Item { Id = Guid.NewGuid().ToString(), English = "we have been here", Russian="мы были здесь", Phonetic= "my byli zdes", ItemType = ItemTypes.Phrase },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "has anyone called", Russian="кто-нибудь звонил", Phonetic = "kto-nibud' zvonil", ItemType = ItemTypes.Phrase },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "what is your name", Russian="как тебя зовут", Phonetic = "kak tebya zovut" , ItemType = ItemTypes.Phrase},
            //    new Item { Id = Guid.NewGuid().ToString(), English = "my name is", Russian="меня зовут", Phonetic = "menya zovut", ItemType = ItemTypes.Phrase },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "what time is it", Russian="который сейчас час", Phonetic = "kotoryy seychas chas", ItemType = ItemTypes.Phrase },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "", Russian="", Phonetic = "", ItemType = ItemTypes.Phrase },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "Sixth item", Russian="This is an item Russian.", Phonetic = "", ItemType = ItemTypes.Phrase },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "Sixth item", Russian="This is an item Russian.", Phonetic = "", ItemType = ItemTypes.Phrase },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "Yes", Russian="Da", Phonetic = "", ItemType = ItemTypes.Phrase },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "No", Russian="Net", Phonetic = "", ItemType = ItemTypes.Phrase },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "Excuse me", Russian="Yzveenee ", Phonetic = "", ItemType = ItemTypes.Phrase },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "Excuse me", Russian="Yzveeneete (formal) ", Phonetic = "", ItemType = ItemTypes.Phrase },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "please", Russian="pozhaluista", Phonetic = "", ItemType = ItemTypes.Phrase },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "Can you tell me please", Russian="Skazhite pozhluista", Phonetic = "", ItemType = ItemTypes.Phrase },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "Thank you", Russian="Spaseebo", Phonetic = "", ItemType = ItemTypes.Phrase },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "Thank you very much", Russian="Spaseebo balshoye", Phonetic = "", ItemType = ItemTypes.Phrase },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "don't mention it", Russian="Ne-za-chto", Phonetic = "", ItemType = ItemTypes.Phrase },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "Do you speak Russian?", Russian="Vy gavareeteh pa ru-sky?", Phonetic = "", ItemType = ItemTypes.Phrase },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "Do you speak English?", Russian="Vy gavareeteh pa anglisky?", Phonetic = "", ItemType = ItemTypes.Phrase },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "I don't speak English", Russian="Ya ne gavareeu na angliyskom", Phonetic = "", ItemType = ItemTypes.Phrase },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "I don't speak Russian", Russian="Ya ne gavareeu na ruskom", Phonetic = "", ItemType = ItemTypes.Phrase },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "My Russian is bad", Russian="Ya ploha gavaru pa Ruski", Phonetic = "", ItemType = ItemTypes.Phrase },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "I do not understand", Russian="Ya ne paneemau", Phonetic = "", ItemType = ItemTypes.Phrase },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "Could you speak slowly?", Russian="Gavareeteh medlenie", Phonetic = "", ItemType = ItemTypes.Phrase },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "Could you speak loudly?", Russian="Gavareeteh gromche", Phonetic = "", ItemType = ItemTypes.Phrase },

            //    new Item { Id = Guid.NewGuid().ToString(), English = "I", Russian="я", Phonetic = "ya", ItemType = ItemTypes.Word },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "Me", Russian="мне", Phonetic = "mne", ItemType = ItemTypes.Word },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "We", Russian="мы", Phonetic = "my", ItemType = ItemTypes.Word },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "They", Russian="Oни", Phonetic = "Oni", ItemType = ItemTypes.Word },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "You", Russian="вы", Phonetic = "vy", ItemType = ItemTypes.Word },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "Him", Russian="ему", Phonetic = "yemu", ItemType = ItemTypes.Word },
            //     new Item { Id = Guid.NewGuid().ToString(), English = "He", Russian="он", Phonetic = "on", ItemType = ItemTypes.Word },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "Her", Russian="ей", Phonetic = "yey", ItemType = ItemTypes.Word },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "She", Russian="она", Phonetic = "ona", ItemType = ItemTypes.Word },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "parents", Russian="roditely", Phonetic = "", ItemType = ItemTypes.Word },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "husband", Russian="muzh", Phonetic = "", ItemType = ItemTypes.Word },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "wife", Russian="zhena", Phonetic = "", ItemType = ItemTypes.Word },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "son", Russian="cyn", Phonetic = "", ItemType = ItemTypes.Word },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "daughter", Russian="Dutch", Phonetic = "", ItemType = ItemTypes.Word },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "stepson", Russian="pasynok", Phonetic = "", ItemType = ItemTypes.Word },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "stepdoughter", Russian="stepdaughter", Phonetic = "", ItemType = ItemTypes.Word },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "son-in-law", Russian="zhiat", Phonetic = "", ItemType = ItemTypes.Word },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "daughter-in-law", Russian="nevestka", Phonetic = "", ItemType = ItemTypes.Word },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "older brother", Russian="starshy brat", Phonetic = "", ItemType = ItemTypes.Word },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "sister", Russian="sestra", Phonetic = "", ItemType = ItemTypes.Word },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "younger sister", Russian="mladshaya sestra", Phonetic = "", ItemType = ItemTypes.Word },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "father", Russian="otets", Phonetic = "", ItemType = ItemTypes.Word },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "mother", Russian="mat'", Phonetic = "", ItemType = ItemTypes.Word },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "grand-dad", Russian="dedushka", Phonetic = "", ItemType = ItemTypes.Word },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "grandma", Russian="babushka", Phonetic = "", ItemType = ItemTypes.Word },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "cousin", Russian="dvojurodny brat (male)", Phonetic = "", ItemType = ItemTypes.Word },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "cousin", Russian="dvojurodnaya sestra (female)", Phonetic = "", ItemType = ItemTypes.Word },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "friend", Russian="drug (male)", Phonetic = "", ItemType = ItemTypes.Word },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "friend", Russian="podruga (female)", Phonetic = "", ItemType = ItemTypes.Word },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "colleague", Russian="kollega", Phonetic = "", ItemType = ItemTypes.Word },
            //    new Item { Id = Guid.NewGuid().ToString(), English = "partner", Russian="partner", Phonetic = "", ItemType = ItemTypes.Word },

            //     new Item { Id = Guid.NewGuid().ToString(), English = "Sunday", Russian="Воскресенье", Phonetic = "Voskresen'ye", ItemType = ItemTypes.Weekdays },
            //     new Item { Id = Guid.NewGuid().ToString(), English = "Monday", Russian="понедельник", Phonetic = "ponedel'nik", ItemType = ItemTypes.Weekdays },
            //     new Item { Id = Guid.NewGuid().ToString(), English = "Tuesday", Russian="вторник", Phonetic = "vtornik", ItemType = ItemTypes.Weekdays },
            //     new Item { Id = Guid.NewGuid().ToString(), English = "Wednesday", Russian="среда", Phonetic = "sreda", ItemType = ItemTypes.Weekdays },
            //     new Item { Id = Guid.NewGuid().ToString(), English = "Thursday", Russian="Четверг", Phonetic = "Chetverg", ItemType = ItemTypes.Weekdays },
            //     new Item { Id = Guid.NewGuid().ToString(), English = "Friday", Russian="пятница", Phonetic = "pyatnitsa", ItemType = ItemTypes.Weekdays },
            //     new Item { Id = Guid.NewGuid().ToString(), English = "Saturday", Russian="суббота", Phonetic = "subbota", ItemType = ItemTypes.Weekdays }


            //};

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }



        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<IEnumerable<Item>> GetWordsAsync()
        {
            return await Task.FromResult(items.Where(i => i.ItemType == ItemTypes.Word).OrderBy(i => i.English));
        }

        public async Task<IEnumerable<Item>> GetPhrasesAsync()
        {
            return await Task.FromResult(items.Where(i => i.ItemType == ItemTypes.Phrase).OrderBy(i => i.English));
        }

        public async Task<IEnumerable<Item>> GetWeekdaysAsync()
        {
            return await Task.FromResult(items.Where(i => i.ItemType == ItemTypes.Weekdays));
        }

        public async Task<IEnumerable<Item>> GetNumbersAsync()
        {
            return await Task.FromResult(items.Where(i => i.ItemType == ItemTypes.Numbers));
        }

        private Item[] getData()
        {
            Item[] russianItems = null;
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(LoadResourceText)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("RussianFlashCards.Russian.xml");

            using (var reader = new StreamReader(stream))
            {
                XDocument doc = XDocument.Load(stream);
                XElement arrayOfItems = doc.Element("ArrayOfItems");


                if (arrayOfItems != null)
                {
                    IEnumerable<XElement> items = arrayOfItems.Elements("Item");
                    russianItems = (from itm in items
                                    select new Item()
                                    {
                                        Id = itm.Element("Id").Value,
                                        English = itm.Element("English").Value,
                                        Russian = itm.Element("Russian").Value,
                                        Phonetic = itm.Element("Phonetic").Value,
                                        ItemType = itm.Element("ItemType").Value,
                                    }).ToArray<Item>();
                }
            }
            return russianItems;

        }
    }
}