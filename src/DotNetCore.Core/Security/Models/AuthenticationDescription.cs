using System;
using System.Collections.Generic;
using System.Globalization;

namespace DotNetCore.Core.Security.Models
{
    public class AuthenticationDescription
    {
        private const string CaptionPropertyKey = "Caption";
        private const string AuthenticationTypePropertyKey = "AuthenticationType";

        public AuthenticationDescription()
        {
            Properties = new Dictionary<string, object>(StringComparer.Ordinal);
        }

        public AuthenticationDescription(IDictionary<string, object> properties)
        {
            if (properties == null)
            {
                throw new ArgumentNullException("properties");
            }
            Properties = properties;
        }

        public IDictionary<string, object> Properties { get; private set; }

        public string AuthenticationType
        {
            get { return GetString(AuthenticationTypePropertyKey); }
            set { Properties[AuthenticationTypePropertyKey] = value; }
        }

        public string Caption
        {
            get { return GetString(CaptionPropertyKey); }
            set { Properties[CaptionPropertyKey] = value; }
        }

        private string GetString(string name)
        {
            object value;
            if (Properties.TryGetValue(name, out value))
            {
                return Convert.ToString(value, CultureInfo.InvariantCulture);
            }
            return null;
        }
    }
}
