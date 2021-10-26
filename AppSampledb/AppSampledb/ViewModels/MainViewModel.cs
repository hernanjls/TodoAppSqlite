using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
//using TodoApp.Services;
using Xamarin.Forms;

namespace AppSampledb.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<TodoItem> _todos;
        
        private bool _isRefreshing;

        public ObservableCollection<TodoItem> Todos
        {
            get { return _todos; }
            set
            {
                _todos = value;
                OnPropertyChanged();
            }
        }

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        public ICommand RefreshCommand => new Command(() =>
        {
             GetTodoes();
        });

        public MainViewModel()
        {
            GetTodoes();
        }

        public void GetTodoes()
        {
            IsRefreshing = true;

            Todos = App._database.GetTodoItems();

            IsRefreshing = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
