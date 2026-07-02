using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Channels;
using static System.Console;
using static System.Net.WebRequestMethods;

namespace BookManagementSystem
{
    internal class Book
    {
        internal int BookID { get; set; }
        internal string Title { get; set; }
        internal string Author { get; set; }
        internal string Status { get; set; }
        internal string Location { get; set; }
        internal int BorrowCount { get; set; }

        public Book(int bookID, string title, string author, string location)
        {
            BookID = bookID;
            Title= title;
            Author = author;
            Status = "New";
            Location = location;
            this.BorrowCount = 0;
        }

        public void DisplayDetails()
        {
            WriteLine($"BookID = {BookID};\r\n Title= {Title};\r\n Author = {Author};\r\n  Status = {Status};\r\n Location = {Location};\r\n BorrowCount = {BorrowCount};"); 
        }

        public void IncreaseBorrowCount()
        {
            if (BorrowCount < 5)
            {
                Status = "New";
            }
            else if (BorrowCount <= 20)
            {
                Status = "Used";
            }
            else{
                Status = "Damaged";
            }
        }

    }
}
