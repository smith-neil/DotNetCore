using System.Collections.Generic;

namespace DotNetCore.Core.Security.Models
{
    public class AuthResult
    {
        public IEnumerable<string> Errors { get; private set; }

        public bool Succeeded { get; private set; }

        public AuthResult(IEnumerable<string> errors, bool succeeded)
        {
            Succeeded = succeeded;
            Errors = errors;
        }
    }
}
