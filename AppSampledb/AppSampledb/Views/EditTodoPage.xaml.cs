using AppSampledb.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSampledb.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditTodoPage : ContentPage
	{
		public EditTodoPage (TodoItem todo)
		{
            var editTodoViewModel = new EditTodoViewModel();

		    editTodoViewModel.SelectedTodo = todo;

		    BindingContext = editTodoViewModel;

			InitializeComponent ();
		}
	}
}