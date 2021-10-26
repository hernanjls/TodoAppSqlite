using System;
using AppSampledb.ViewModels;
using AppSampledb.Views;
using Xamarin.Forms;

namespace AppSampledb
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

       

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var todo = e.Item as TodoItem;

            Navigation.PushModalAsync(new EditTodoPage(todo));
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddTodoPage());
        }

        protected override void OnAppearing()
        {
            (this.BindingContext as MainViewModel).GetTodoes();
            base.OnAppearing();
        }


    }
}
