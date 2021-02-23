using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Core.Exceptions
{
    public class ConfilictException : Exception
    {
        public ConfilictException(string message) : base(message)
        {

        }
    }
}
