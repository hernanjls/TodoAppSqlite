using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SQLite;
using Xamarin.Forms;

namespace AppSampledb
{
    public class TodoDB
    {
        private SQLiteConnection _sqlconnection;

        public TodoDB()
        {
            //Getting conection and Creating table
            _sqlconnection = DependencyService.Get<ISQLite>().GetConnection();

            //_sqlconnection.DropTable<TodoItem>();
            _sqlconnection.CreateTable<TodoItem>();
           
        }

        

        //Get all items
        public  ObservableCollection<TodoItem> GetTodoItems(string estatus ="Todos")
        {


            var list = (from t in _sqlconnection.Table<TodoItem>()  orderby t.Id descending select t).ToList();

            if (estatus == "completado")
            {
                list = list.Where(x => x.IsDone == true).OrderByDescending(x => x.Id).ToList();
            }
            else if (estatus == "no_completado")
            {
                list = list.Where(x => x.IsDone == false).OrderByDescending(x => x.Id).ToList();
            }

            var collection = new ObservableCollection<TodoItem>(list);

            return collection;


        }

       

        //Get specific item
        public TodoItem GetTodoItem(int id)
        {
            return _sqlconnection.Table<TodoItem>().FirstOrDefault(t => t.Id == id);
        }

        //Delete specific item
        public void DeleteTodoItem(int id)
        {
            _sqlconnection.Delete<TodoItem>(id);
        }

        //Add new item to DB
        public void AddTodoItem(TodoItem licencia)
        {
            _sqlconnection.Insert(licencia);

        }

        public void UpdateTodoItem(TodoItem item)
        {

            var reg = GetTodoItem(item.Id);
            reg.UpdatedAt = DateTime.Now;
            reg.IsDone = item.IsDone;
            reg.Title = item.Title;

            _sqlconnection.Update(reg);

        }



    }
}
