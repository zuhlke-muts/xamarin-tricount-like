using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using XamarinTricountLike.Models;

namespace XamarinTricountLike.Database
{
    class EventRepository
    {
        public EventRepository()
        {
            this.Database = App.DatabaseConnection;
        }

        public SQLiteConnection Database { get; set; }

        static object locker = new object();

        public IEnumerable<Event> GetAllEvents()
        {
            lock (locker)
            {
                return Database.Query<Event>("SELECT * FROM [Event]");
            }
        }

        public Event GetEvent(int id)
        {
            lock (locker)
            {
                return Database.Table<Event>().FirstOrDefault(x => x.ID == id);
            }
        }

        public int SaveEvent(Event item)
        {
            lock (locker)
            {
                if (item.ID != 0)
                {
                    Database.Update(item);
                    return item.ID;
                }
                else
                {
                    return Database.Insert(item);
                }
            }
        }

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return Database.Delete<Event>(id);
            }
        }
    }
}
