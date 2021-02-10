using System.Collections.Generic;

namespace ConsoleApp1.Models
{
    class Event
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public ICollection<MemberEvent> Members { get; set; }
    }
}
