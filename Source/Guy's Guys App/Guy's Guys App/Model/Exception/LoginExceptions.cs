using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guys_Guys_App.Model.Exception
{
    public class LoginException : System.Exception
    {
        public LoginException()
        {
        }

        public LoginException(string message) : base(message)
        {
        }

        public LoginException(string message, System.Exception inner) : base(message, inner)
        {
        }
    }

    public class UserNotFoundException : LoginException
    {
        public UserNotFoundException()
        {
        }

        public UserNotFoundException(string message, System.Exception inner) : base(message, inner)
        {
        }
    }

    public class IncorrectPasswordException : LoginException
    {
        public IncorrectPasswordException()
        {
        }

        public IncorrectPasswordException(string message)
        {
        }

        public IncorrectPasswordException(string message, System.Exception inner) : base(message, inner)
        {
        }
    }
}
