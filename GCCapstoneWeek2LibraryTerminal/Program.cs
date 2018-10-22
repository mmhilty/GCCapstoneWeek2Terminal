using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneTry2
{
    class Program
    {
        static void Main(string[] args)
        {

            BookRecord TolstoyKarenina = new BookRecord("Anna Karenina", "Leo Tolstoy", false);
            BookRecord HomerOdyssey = new BookRecord("Odyssey", "Homer", false);
            BookRecord EuripidesBacchae = new BookRecord("Bacchae", "Euripides", false);
            BookRecord EuclidElements = new BookRecord("Elements", "Euclid", false);
            BookRecord PlatoSophist = new BookRecord("Sophist", "Plato", false);
            BookRecord VirgilAeneid = new BookRecord("Aeneid", "Virgil", false);
            BookRecord CatullusPoems = new BookRecord("Poems", "Catullus", false);
            BookRecord CervantesDonQuixote = new BookRecord("Don Quixote", "Miguel de Cervantes", false);
            BookRecord MiltonParadise = new BookRecord("Paradise Lost", "John Milton", false);
            BookRecord DescartesRules = new BookRecord("Rules for the Direction of the Mind", "Rene Descartes", false);
            BookRecord HuygensLight = new BookRecord("Treatise on Light", "Christiaan Huygens", false);
            BookRecord PlatoPhaedrus = new BookRecord("Phaedrus", "Plato", false);
            BookRecord LincolnSpeeches = new BookRecord("Selected Speeches", "Abraham Lincoln", false);
            BookRecord GoetheFaust = new BookRecord("Faust", "Johann Wolfgang von Goethe", false);
            BookRecord PlatoRepublic = new BookRecord("Republic", "Plato", false);

            List<BookRecord> libraryList = new List<BookRecord>()
        { TolstoyKarenina, HomerOdyssey, EuripidesBacchae, EuclidElements,
            PlatoPhaedrus, PlatoRepublic, PlatoSophist, VirgilAeneid,
            CatullusPoems, CervantesDonQuixote, MiltonParadise, DescartesRules,
            HuygensLight, LincolnSpeeches, GoetheFaust };

            bool killswitch = true;
            while (killswitch)
            {
                Console.WriteLine("Welcome to the Dimmsdale Library Terminal!");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine(" 1. View book catalogue \n" +
                                   " 2. Find a book \n" +
                                   " 3. Add a book \n" +
                                   " 4. Exit \n");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1": //view book catalogue
                        viewCatalogue(libraryList);
                        break;

                    case "2": //find specific book then check it out
                        BookRecord chosenBook = searchForBook(libraryList);
                        Console.WriteLine($"Your book selection is: {chosenBook.bookTitle} || {chosenBook.bookAuthor} || Checked out: {chosenBook.bookChecked}\n");
                        if (chosenBook.bookChecked == false)
                        {
                            Console.WriteLine("Would you like to check this book out? y/n");
                            string chosenBookInput = Console.ReadLine();
                            if (chosenBookInput == "y")
                            {
                                libraryList = CheckOutMethod(chosenBook, libraryList);
                                Console.Write("Your book has been checked out! Exiting menu");
                                System.Threading.Thread.Sleep(500);
                                Console.Write(". ");
                                System.Threading.Thread.Sleep(500);
                                Console.Write(". ");
                                System.Threading.Thread.Sleep(500);
                                Console.Write(". \n");
                                System.Threading.Thread.Sleep(500);
                                break;
                            }
                            else
                            {
                                Console.Write("Exiting menu");
                                System.Threading.Thread.Sleep(500);
                                Console.Write(". ");
                                System.Threading.Thread.Sleep(500);
                                Console.Write(". ");
                                System.Threading.Thread.Sleep(500);
                                Console.Write(". \n");
                                System.Threading.Thread.Sleep(500);
                                break;
                            }
                        }

                        else
                        {
                            Console.WriteLine("This book has already been checked out. Would you like to check it back in? y/n");
                            string chosenBookInput = Console.ReadLine();
                            switch (chosenBookInput)
                            {
                                case "y":
                                    libraryList = CheckInMethod(chosenBook, libraryList);
                                    Console.Write("Your book has been checked back in! Exiting menu");
                                    System.Threading.Thread.Sleep(500);
                                    Console.Write(". ");
                                    System.Threading.Thread.Sleep(500);
                                    Console.Write(". ");
                                    System.Threading.Thread.Sleep(500);
                                    Console.Write(". \n");
                                    System.Threading.Thread.Sleep(500);
                                    break;

                                default:
                                    Console.Write("Exiting menu");
                                    System.Threading.Thread.Sleep(500);
                                    Console.Write(". ");
                                    System.Threading.Thread.Sleep(500);
                                    Console.Write(". ");
                                    System.Threading.Thread.Sleep(500);
                                    Console.Write(". \n");
                                    System.Threading.Thread.Sleep(500);
                                    break;
                            }
                            break;
                        }
                    case "3":
                        //ADDFUNCTION
                        AddABook(libraryList);
                        break;
                    case "4":
                        Console.Write("Exiting program. Please come again soon!");
                        System.Threading.Thread.Sleep(500);
                        Console.Write(". ");
                        System.Threading.Thread.Sleep(500);
                        Console.Write(". ");
                        System.Threading.Thread.Sleep(500);
                        Console.Write(". \n");
                        System.Threading.Thread.Sleep(500);
                        killswitch = false;
                        break;
                }
            }


        }

        // view function

        public static void viewCatalogue(List<BookRecord> libraryList)
        {
            Console.WriteLine($"{"Title",-30} || {"Author",-30} || {"Checked Out?",-10}");
            Console.WriteLine("=============================================================================");
            foreach (BookRecord b in libraryList.OrderBy(b => b.bookAuthor))
            {
                Console.WriteLine($"{b.bookTitle,-30} || {b.bookAuthor,-30} || {b.bookChecked,-10}");

            }

        }

        //Select book 


        //search for book 
        public static BookRecord searchForBook(List<BookRecord> libraryList)
        {
            while (true)
            {
                Console.WriteLine("What would you like to search by?\n" +
                                   "1. Title\n" +
                                   "2. Author\n");
                int userInput;
                bool validInput = int.TryParse(Console.ReadLine(), out userInput);
                if (validInput)
                {
                    if (userInput == 1) //search by title    
                    {
                        while (true)
                        {
                            Console.Write("Enter your title search term: ");
                            string searchInput = Console.ReadLine();
                            List<BookRecord> searchList = new List<BookRecord>(); // list to be filled w/ search results
                            foreach (BookRecord rec in libraryList)
                            {
                                if (rec.bookTitle.ToLower().Contains(searchInput.ToLower()))
                                {
                                    searchList.Add(rec);
                                }
                            }
                            // now have list filled with search results (or empty)

                            if (searchList.Count == 1)
                            {

                                return searchList[0];
                            }

                            else if (searchList.Count > 1)
                            {
                                for (int i = 0; i < searchList.Count; i++)
                                {
                                    Console.WriteLine($"{ i + 1}. {searchList[i].bookTitle} || {searchList[i].bookAuthor}");
                                }
                                Console.WriteLine("There are multiple results for your search. Which book did you mean?");
                                int searchInput2 = int.Parse(Console.ReadLine());
                                return searchList[searchInput2 - 1];
                            }
                            else
                            {
                                Console.WriteLine("No results found. Try again.");
                            }
                        }

                    }
                    else if (userInput == 2) //search by author
                    {
                        while (true)
                        {
                            Console.Write("Enter your author search term: ");
                            string searchInput = Console.ReadLine();
                            List<BookRecord> searchList = new List<BookRecord>(); // list to be filled w/ search results
                            foreach (BookRecord rec in libraryList)
                            {
                                if (rec.bookAuthor.ToLower().Contains(searchInput.ToLower()))
                                {
                                    searchList.Add(rec);
                                }
                            }
                            // now have list filled with search results (or empty)

                            if (searchList.Count == 1)
                            {
                                return searchList[0];
                            }

                            else if (searchList.Count > 1)
                            {
                                while (true)
                                {
                                    for (int i = 0; i < searchList.Count; i++)
                                    {
                                        Console.WriteLine($"{ i + 1}. {searchList[i].bookTitle} || {searchList[i].bookAuthor}");
                                    }
                                    Console.WriteLine("There are multiple results for your search. Which book did you mean?");
                                    int searchInput2 = int.Parse(Console.ReadLine());
                                    try
                                    {
                                        return searchList[searchInput2 - 1];
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Not valid. Try again.");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("No results found. Try again.");
                            }

                        }
                    }
                }

                else
                {
                    Console.WriteLine("Not a valid input. Try again.");
                }
            }

        }

        //checkout 
        public static List<BookRecord> CheckOutMethod(BookRecord chosenrecord, List<BookRecord> libraryList)
        {
            foreach (BookRecord rec in libraryList)
            {
                if (rec.bookTitle == chosenrecord.bookTitle)
                {
                    rec.bookChecked = true;
                }
            }
            return libraryList;

        }

        public static List<BookRecord> CheckInMethod(BookRecord chosenrecord, List<BookRecord> libraryList)
        {
            foreach (BookRecord rec in libraryList)
            {
                if (rec.bookTitle == chosenrecord.bookTitle)
                {
                    rec.bookChecked = false;
                }
            }
            return libraryList;

        }


        public static List<BookRecord> AddABook(List<BookRecord> libraryList)
        {
            Console.WriteLine("Welcome to the add a book menu!\n" +
                "What is the title of the book you'd like to add? ");
            string newBookTitle = Console.ReadLine();
            Console.WriteLine("Who is the author?");
            string newBookAuthor = Console.ReadLine();
            libraryList.Add(new BookRecord(newBookTitle, newBookAuthor, false));
            Console.WriteLine($"You've added {newBookTitle} by {newBookAuthor}! Exiting back to the main menu");
            System.Threading.Thread.Sleep(500);
            Console.Write(". ");
            System.Threading.Thread.Sleep(500);
            Console.Write(". ");
            System.Threading.Thread.Sleep(500);
            Console.Write(". \n");
            System.Threading.Thread.Sleep(500);
            return libraryList;
        }
    }

    public class BookRecord
    {
        //constructor means that you can only create an instance of the class if you put this stuff into it
        public BookRecord(string bookTitle, string bookAuthor, bool bookChecked)
        {
            this.bookTitle = bookTitle;
            this.bookAuthor = bookAuthor;
            this.bookChecked = bookChecked;

        }

        public string bookTitle { set; get; }
        public string bookAuthor { set; get; }
        public bool bookChecked { set; get; }

        // set get - shorthand to allow you to set class.variable to be equal to something as well as to retrieve it
    }

}
