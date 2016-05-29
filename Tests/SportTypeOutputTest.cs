using System.Collections.Generic;
using BusinessLogic;
using Core;
using Core.Interfaces;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class SportTypeOutputTest
    {
        private ISportListOutput sut;

        [SetUp]
        public void Setup()
        {
            sut = new SportListOutputCsv();
        }

        [Test]
        public void ToCsv()
        {
            var stypes = new List<SportType>
            {
                new SportType {Name = "111"},
                new SportType {Name = "222"},
                new SportType {Name = "333"},
            };

            var output = sut.GetSportList(stypes);

            Assert.That(output, Is.EqualTo("111;222;333"));
        }
    }
}
