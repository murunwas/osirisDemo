using System;

namespace OSIRIS.Common.Exceptions
{
    public class UserExistException:Exception
    {
        public UserExistException()
        {

        }

        public UserExistException(string user):base($"{user} already exist.")
        {

        }
    }
}
