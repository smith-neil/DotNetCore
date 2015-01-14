using System;

namespace DotNetCore.Core.Domain
{
    public abstract class BaseEntity : IIdentifiable<int>
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateLastModified { get; set; }
    }
}
