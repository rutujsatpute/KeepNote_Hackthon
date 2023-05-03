using System;
using System.Reflection;

namespace KeepNote_Hackathon
{
    class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        class Management
        {
            List<Note> notes;

            public Management()
            {

                notes = new List<Note>()
 {

                new Note {Id = 1,Title = "MOM", Description= "Traget complition should be done in 2 months"}

 };
            }
            public void AddCustomer(Note note)
            {
                notes.Add(note);
            }
            public int GenerateNoteId(string title)
            {
                Random rand = new Random();
                int randomNumber = rand.Next(1, 9999);
                return randomNumber;
            }
            public Note GetNote(int id)
            {
                foreach (Note n in notes)
                {
                    if (n.Id == id)
                        return n;
                }
                return null;
            }
            public Note GetNoteby(int id)
            {
                foreach (Note note in notes)
                {
                    if (note.Id == id)
                        return note;
                }
                return null;
            }

            public List<Note> GetNotes()
            {
                return notes;
            }

            public bool UpdateDetails(int id)
            {
                foreach (Note n in notes)
                {
                    if (n.Id == id)
                    {
                        try
                        {
                            Console.WriteLine("Enter the Title");
                            n.Title = Console.ReadLine();
                            Console.WriteLine("Enter Description");
                            n.Description = Console.ReadLine();
                            return true;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Only String are Allowed");
                        }

                    }
                }
                return false;
            }

            public bool DeleteNote(int id)
            {
                foreach (Note n in notes)
                {
                    if (n.Id == id)
                    {
                        notes.Remove(n);
                        return true;
                    }
                }
                return false;
            }

        }
        internal class Program
        {
            static void Main(string[] args)
            {
                Management obj = new Management();
                string ans = "";
                do
                {
                    try
                    {
                        Console.WriteLine("Welcome to Keep Notes App");
                        Console.WriteLine("1. Add Note");
                        Console.WriteLine("2. Get Note Detail By Id");
                        Console.WriteLine("3. Get All Notes Details");
                        Console.WriteLine("4. Delete Note By Id");
                        Console.WriteLine("5. Update Note Details");
                        int choice = Convert.ToInt16(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                {
                                    Console.WriteLine("Enter the Title");
                                    string title = Console.ReadLine();
                                    Console.WriteLine("Enter the Description");
                                    string description = Console.ReadLine();
                                    int nid = obj.GenerateNoteId(title);
                                    Console.WriteLine($"Your Note ID is {nid}");
                                    DateTime date = DateTime.Now;
                                    obj.AddCustomer(new Note() { Id = nid, Title = title, Description = description, Date = date });
                                    break;
                                }
                            case 2:
                                {
                                    Console.WriteLine("Enter Note Id");
                                    int id = Convert.ToInt16(Console.ReadLine());
                                    Note? n = obj.GetNote(id);
                                    if (n == null)
                                    {
                                        Console.WriteLine("Note with specified id does not exists");
                                    }
                                    else
                                    {
                                        Console.WriteLine("id \t\t title \t\t description \t\t\t date");
                                        Console.WriteLine($"{n.Id} \t\t {n.Title} \t\t {n.Description} \t\t {n.Date}");
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    Console.WriteLine($"id           title           description           date");
                                    int count = 0;
                                    foreach (var n in obj.GetNotes())
                                    {
                                        Console.WriteLine($"{n.Id}\t\t {n.Title}\t\t{n.Description}\t\t{n.Date}");
                                     
                                    }
                                    Console.WriteLine($"Total Notes: {count}");
                                    break;
                                }
                            case 4:
                                {
                                    Console.WriteLine("Enter Note ID");
                                    int id = Convert.ToInt16(Console.ReadLine());
                                    if (obj.UpdateDetails(id))
                                    {
                                        Console.WriteLine("Note Detail Updated Successfully!!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Note with specified id does not exist");
                                    }
                                    break;
                                }
                            case 5:
                                {
                                    Console.WriteLine("Enter Note Id");
                                    int id = Convert.ToInt16(Console.ReadLine());
                                    if (obj.DeleteNote(id))
                                    {
                                        Console.WriteLine("Note Details Deleted Successfully");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Note with specified id does not exist");
                                    }
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Invalid choice!!!!");
                                    break;
                                }
                        }
                        Console.WriteLine("Do you wish to continue? [y/n] ");
                        ans = Console.ReadLine();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Only Numbers are Allowed");
                    }
                } while (ans.ToLower() == "y");
            }
        }
    }
}