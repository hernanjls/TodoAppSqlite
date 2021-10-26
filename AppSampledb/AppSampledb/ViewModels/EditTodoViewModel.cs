using System;
using System.Windows.Input;
//using TodoApp.Services;
using Xamarin.Forms;

namespace AppSampledb.ViewModels
{
    public class EditTodoViewModel
    {
        
        public TodoItem SelectedTodo { get; set; }

        public ICommand EditTodoCommand => new Command(() =>
        {
            SelectedTodo.UpdatedAt = DateTime.UtcNow;

            App._database.UpdateTodoItem(SelectedTodo);

            App.Current.MainPage.Navigation.PopModalAsync();
        });

        public ICommand DeleteTodoCommand => new Command(() =>
        {
            SelectedTodo.UpdatedAt = DateTime.UtcNow;
            App._database.DeleteTodoItem(SelectedTodo.Id);
            App.Current.MainPage.Navigation.PopModalAsync();

        });
    }
}
