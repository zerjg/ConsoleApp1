using System.Collections.Generic;

namespace ConsoleApp1.Models
{
    class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public ICollection<MemberEvent> Events { get; set; }
    }
}
