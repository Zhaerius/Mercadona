using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Common.Exceptions
{
    public class AuthException : Exception
    {
        public AuthException() : base("Connexion impossible, username ou mdp invalide")
        {
        }
    }
}
