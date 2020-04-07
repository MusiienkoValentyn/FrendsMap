using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Exceptions
{
    public class LoginException:Exception
    {
        public LoginException(string message):base(message)
        {

        }
    }
}
