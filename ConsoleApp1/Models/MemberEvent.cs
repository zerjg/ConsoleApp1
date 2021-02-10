namespace ConsoleApp1.Models
{
    class MemberEvent
    {
        public int MemberId { get; set; }
        public int EventId { get; set; }

        public Member Member { get; set; }
        public Event Event { get; set; }
    }
}
