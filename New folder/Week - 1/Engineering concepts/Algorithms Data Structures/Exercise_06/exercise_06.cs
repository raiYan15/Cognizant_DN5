using System;

namespace LibraryManagementSystem
{
    class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(int bookId, string title, string author)
        {
            BookId = bookId;
            Title = title;
            Author = author;
        }

        public override string ToString() =>
            $"[{BookId}] \"{Title}\" by {Author}";
    }

    class LibrarySearch
    {
        
        public static int LinearSearchByTitle(Book[] books, string titleQuery)
        {
            string query = titleQuery.ToLower();
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].Title.ToLower().Contains(query))
                    return i;
            }
            return -1;
        }

        
        public static int BinarySearchByTitle(Book[] sortedBooks, string titleQuery)
        {
            string query = titleQuery.ToLower();
            int low = 0, high = sortedBooks.Length - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                string midTitle = sortedBooks[mid].Title.ToLower();
                int cmp = string.Compare(midTitle, query, StringComparison.Ordinal);
                if (cmp == 0)
                    return mid;
                else if (cmp < 0)
                    low = mid + 1;
                else
                    high = mid - 1;
            }
            return -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            Book[] library = {
                new Book(3, "The Pragmatic Programmer", "Andrew Hunt"),
                new Book(1, "Clean Code",               "Robert C. Martin"),
                new Book(5, "Design Patterns",          "Gang of Four"),
                new Book(2, "Code Complete",            "Steve McConnell"),
                new Book(4, "Refactoring",              "Martin Fowler"),
            };

            
            Book[] sortedLibrary = {
                new Book(1, "Clean Code",               "Robert C. Martin"),
                new Book(2, "Code Complete",            "Steve McConnell"),
                new Book(5, "Design Patterns",          "Gang of Four"),
                new Book(4, "Refactoring",              "Martin Fowler"),
                new Book(3, "The Pragmatic Programmer", "Andrew Hunt"),
            };

            
            Console.WriteLine(" Linear Search ");
            string searchTitle = "Refactoring";
            int linIdx = LibrarySearch.LinearSearchByTitle(library, searchTitle);
            Console.WriteLine(linIdx >= 0
                ? $"Found at index {linIdx}: {library[linIdx]}"
                : "Book not found.");

            
            Console.WriteLine("\n  Binary Search ");
            int binIdx = LibrarySearch.BinarySearchByTitle(sortedLibrary, searchTitle);
            Console.WriteLine(binIdx >= 0
                ? $"Found at index {binIdx}: {sortedLibrary[binIdx]}"
                : "Book not found.");

            
            Console.WriteLine("\n  Search for non-existent title  ");
            Console.WriteLine($"Linear: index {LibrarySearch.LinearSearchByTitle(library, "Unknown Book")}");
            Console.WriteLine($"Binary: index {LibrarySearch.BinarySearchByTitle(sortedLibrary, "Unknown Book")}");

            
        }
    }
}
