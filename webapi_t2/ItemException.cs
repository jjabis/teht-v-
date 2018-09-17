using System;

namespace webapi_t2
{
    public class ItemException : Exception
    {
        public ItemException() {

        }
        public ItemException(string message) : base(message) {

        }
        public ItemException(string message, Exception inner) : base(message, inner) {

        }
    }
}