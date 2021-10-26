using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AppSampledb
{
    public class App : Application
    {
        public static TodoDB _database;

        public App()
        {
            _database = new TodoDB();

            MainPage = new NavigationPage( new MainPage());
        }

        public class SwitchCellPage: ContentPage
        {
            public SwitchCellPage()
            {
                Label header = new Label
            {
                Text = "SwitchCell",
                HorizontalOptions = LayoutOptions.Center
            };

            TableView tableView = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot
                {
                    new TableSection
                    {
                        new SwitchCell
                        {
                            Text = "SwitchCell:"
                        }
                    }
                }
            };
                Content = new StackLayout(){Children={header, tableView}};
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
