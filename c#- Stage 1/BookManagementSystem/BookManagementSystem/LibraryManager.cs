using System;
using System.Collections.Generic;
using System.Text;

namespace BookManagementSystem
{
    internal class LibraryManager
    {
        List<Book> Books= new();

        public void AddBook(Book book)
        {
            foreach (Book kitab in Books)
            {
                if(kitab.BookID == book.BookID)
                {
                    throw new Exception("Book ID already exists");
                }
            }
            Books.Add(book);
            Console.WriteLine("Book details added successfully");
        }

        public void DisplayAllBooks()
        {
            if (Books.Count == 0)
            {
                Console.WriteLine("No books available");
                return;
            }

            foreach(Book kitab in Books)
            {
                kitab.DisplayDetails();
            }
        }

        public void UpdateBookById(int bookID)
        {
            Book DemandedBook = null;
            foreach(Book kitab in Books)
            {
                if(kitab.BookID == bookID)
                {
                    DemandedBook = kitab;
                }
            }
            if (DemandedBook != null)
            {
                DemandedBook = UpdateDemandedBook(DemandedBook);
                Console.WriteLine("Book details updated successfully");
            }

            throw new BookNotFoundException($"Book with ID {bookID} not found.");
        }

        public Book UpdateDemandedBook(Book DemandedBook)
        {
            Console.WriteLine("You can update the following details:");

            Console.WriteLine("Enter Title");
            string Title = Console.ReadLine();

            Console.WriteLine("Enter Author");
            string Author = Console.ReadLine();

            Console.WriteLine("Enter Location");
            string Location = Console.ReadLine();

            DemandedBook.Title = Title;
            DemandedBook.Author = Author;
            DemandedBook.Location = Location;
            DemandedBook.BorrowCount++;

            return DemandedBook;
        }

    }
}
