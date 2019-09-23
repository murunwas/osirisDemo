using System;

namespace OSIRIS.Common.Exceptions
{
    public class CustomException:Exception
    {
        public CustomException()
        {

        }

        public CustomException(string message) : base(message)
        {

        }
    }
}
