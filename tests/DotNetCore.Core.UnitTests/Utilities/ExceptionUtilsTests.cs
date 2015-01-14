using System;
using DotNetCore.Core.Utilities;
using NUnit.Framework;

namespace DotNetCore.Core.UnitTests.Utilities
{
    [TestFixture]
    public class ExceptionUtilsTests
    {
        [TestCase(null, null)]
        [TestCase("paramName", "message")]
        public void ThrowIfNull_ThrowsNull(string paramName, string message)
        {
            string nullThing = null;

            Assert.Throws<ArgumentNullException>(() => nullThing.ThrowIfNull(paramName, message));
        }

        [TestCase(null, null)]
        [TestCase("paramName", "message")]
        public void ThrowIfNull_DoesNotThrow(string paramName, string message)
        {
            string notNullThing = "im not null";

            Assert.DoesNotThrow(() => notNullThing.ThrowIfNull(paramName, message));
        }
    }
}
