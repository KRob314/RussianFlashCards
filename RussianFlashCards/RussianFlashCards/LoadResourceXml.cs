using RussianFlashCards.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace RussianFlashCards
{
    public class LoadResourceXml : ContentPage
    {
        public LoadResourceXml()
        {
            #region How to load an XML file embedded resource
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(LoadResourceText)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("RussianFlashCards.Russian.xml");

            List<Item> monkeys;
            using (var reader = new StreamReader(stream))
            {
                var serializer = new XmlSerializer(typeof(List<Item>));
                monkeys = (List<Item>)serializer.Deserialize(reader);
            }
            #endregion

            var listView = new ListView();
            listView.ItemTemplate = new DataTemplate(() =>
            {
                var textCell = new TextCell();
                textCell.SetBinding(TextCell.TextProperty, "Name");
                textCell.SetBinding(TextCell.DetailProperty, "Location");
                return textCell;
            });
            listView.ItemsSource = monkeys;

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    new Label { Text = "Embedded Resource XML File",
                        FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
                        FontAttributes = FontAttributes.Bold
                    }, listView
                }
            };

            // NOTE: use for debugging, not in released app code!
            //foreach (var res in assembly.GetManifestResourceNames()) 
            //	System.Diagnostics.Debug.WriteLine("found resource: " + res);
        }
    }
}
