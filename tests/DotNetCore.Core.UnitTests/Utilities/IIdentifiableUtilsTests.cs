using System;
using DotNetCore.Core.Utilities;
using NUnit.Framework;

namespace DotNetCore.Core.UnitTests.Utilities
{
    [TestFixture]
    public class IIdentifiableUtilsTests
    {
        [Test]
        public void IsNew_Throws_IfNull()
        {
            IIdentifiable<int> nullThing = null;

            Assert.Throws<ArgumentNullException>(() => nullThing.IsNew());
        }

        [Test]
        public void IsNew_ReturnsTrue_IfNew()
        {
            var newThing = new FakeIdentifiable();

            var result = newThing.IsNew();

            Assert.IsTrue(result);
        }

        [Test]
        public void IsNew_ReturnsFalse_IfNotNew()
        {
            var oldThing = new FakeIdentifiable {Id = 42};

            var result = oldThing.IsNew();

            Assert.IsFalse(result);
        }

        private class FakeIdentifiable : IIdentifiable<int>
        {
            public int Id { get; set; }
        }
    }
}
