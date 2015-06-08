using SQLite;

namespace XamarinTricountLike.Models
{
    public class Event
    {
        public Event()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
