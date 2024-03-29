﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace RussianFlashCards
{
  public  class LoadResourceText : ContentPage
    {
        public LoadResourceText()
        {
            var editor = new Label { Text = "loading...", HeightRequest = 300 };

            #region How to load a text file embedded resource
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(LoadResourceText)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("RussianFlashCards.LibTextResource.txt");

            string text = "";
            using (var reader = new StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }
            #endregion

            editor.Text = text;

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    new Label { Text = "Embedded Resource Text File",
                        FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
                        FontAttributes = FontAttributes.Bold
                    }, editor
                }
            };

            // NOTE: use for debugging, not in released app code!
            //foreach (var res in assembly.GetManifestResourceNames()) 
            //	System.Diagnostics.Debug.WriteLine("found resource: " + res);
        }
    }
}
