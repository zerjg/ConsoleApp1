using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new AppDbContext();

            while(true)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("Enter a command:");
                Console.WriteLine("(a) add a member and an event");
                Console.WriteLine("(r) add a registration");
                Console.WriteLine("(m) show member info");
                Console.WriteLine("(e) show event info");
                Console.WriteLine("------------------------------");
                var c = Console.ReadLine();

                if (c == "a")
                {
                    Console.WriteLine("Give a name for a new Member:");
                    var name = Console.ReadLine();
                    var newMember = new Member { Name = name };

                    Console.WriteLine("Give a title for a new Event:");
                    var title = Console.ReadLine();
                    var newEvent = new Event { Title = title };

                    db.Add(newMember);
                    db.Add(newEvent);
                    db.SaveChanges();
                }
                else if (c == "r")
                {
                    Console.WriteLine("Write the name:");
                    var name = Console.ReadLine();

                    Console.WriteLine("Write the title:");
                    var title = Console.ReadLine();

                    var member = db.Members.Where(m => m.Name == name).FirstOrDefault();
                    var evnt = db.Events.Where(e => e.Title == title).FirstOrDefault();
                    member.Events.Add(new MemberEvent { Member = member, Event = evnt });
                    db.SaveChanges();
                }
                else if (c == "m")
                {
                    Console.WriteLine("Write the name:");
                    var name = Console.ReadLine();
                    Console.WriteLine($"\nRegistrations for {name}:");
                    var m = db.Members.Include(r => r.Events).ThenInclude(r => r.Event).Where(r => r.Name == name).FirstOrDefault();
                    foreach (var eventList in m.Events)
                    {
                        Console.WriteLine($"| {eventList.Event.Title}");
                    }
                }
                else if (c == "e")
                {
                    Console.WriteLine("Write the title:");
                    var title = Console.ReadLine();
                    Console.WriteLine($"\nRegistrations for {title}:");
                    var e = db.Events.Include(r => r.Members).ThenInclude(r => r.Member).Where(r => r.Title == title).FirstOrDefault();
                    foreach (var memberList in e.Members)
                    {
                        Console.WriteLine($"| {memberList.Member.Name}");
                    }
                }
                else break;
            }
        }
    }
}
