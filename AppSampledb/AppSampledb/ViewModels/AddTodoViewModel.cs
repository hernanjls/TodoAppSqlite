using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace AppSampledb.ViewModels
{
    public class AddTodoViewModel
    {
        //private DataService _dataService = new DataService();

        public TodoItem SelectedTodo { get; set; }

        public ICommand SendTodoCommand => new Command(async () =>
        {
            SelectedTodo.UpdatedAt = DateTime.UtcNow;

            App._database.AddTodoItem(SelectedTodo);

            await App.Current.MainPage.Navigation.PopModalAsync();

        });

        public AddTodoViewModel()
        {
            SelectedTodo = new TodoItem();
        }
    }
}
