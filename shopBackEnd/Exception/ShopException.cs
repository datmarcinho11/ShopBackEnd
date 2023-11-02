namespace shopBackEnd.Exception
{
    using System;

    //inherit Exception class, to create Custom Exception class
    public class ShopException : Exception
    {
        //Class Constructor
        public ShopException()
        {
        }

        //class constructor with parameter as Error message
        public ShopException(string message)
            : base(message)
        {
        }

        // constructor with Exception details as parameter
        public ShopException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

}
