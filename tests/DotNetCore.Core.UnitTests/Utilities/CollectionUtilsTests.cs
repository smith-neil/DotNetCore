using System;
using System.Collections.ObjectModel;
using DotNetCore.Core.Utilities;
using NUnit.Framework;

namespace DotNetCore.Core.UnitTests.Utilities
{
    [TestFixture]
    public class CollectionUtilsTests
    {
        private Collection<int> _list = new Collection<int>();
        private Action<int> _action = m => m += 1;

        [SetUp]
        public void Init()
        {
            _list = new Collection<int>();
        }

        [Test]
        public void ForEach_NullSource_Throws()
        {
            _list = null;

            Assert.Throws<ArgumentNullException>(() => _list.ForEach(_action));
        }

        [Test]
        public void ForEach_NotNullSource_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => _list.ForEach(_action));
        }

        [Test]
        public void ForEach_ExecutesActionOnEveryItem()
        {
            var result = new Collection<int>();
            _list = new Collection<int> { 1, 2, 3 };
            _action = m => result.Add(m);
            
            _list.ForEach(_action);

            CollectionAssert.AreEqual(result, _list);
        }
    }
}
