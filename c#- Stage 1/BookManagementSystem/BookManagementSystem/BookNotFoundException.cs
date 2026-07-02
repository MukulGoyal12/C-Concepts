using System;
using System.Collections.Generic;
using System.Text;

namespace BookManagementSystem
{
    internal class BookNotFoundException:Exception
    {

        public BookNotFoundException(string message) : base(message) { }
    }
}
