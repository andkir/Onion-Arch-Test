using Core;
using Infrastructure.Json;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class SportComplexJsonRepositoryTest
    {
        [Test, Ignore("dfg")]
        public void AddFirstItem()
        {
            var sut = new SportComplexJsonRepository();

            sut.Add(new SportComplex
            {
                Id = 1, Name="Football", SportType = new SportType[0], User = null, UserId = 0
            });

            var item = sut.GetById(1);
            Assert.NotNull(item);
            Assert.That(item.Id, Is.EqualTo(1));
            Assert.That(item.Name, Is.EqualTo("Football"));
        }

        [Test]
        public void AddOneMoreItem()
        {
            var sut = new SportComplexJsonRepository();

            sut.Add(new SportComplex
            {
                Id = 1, Name="Football", SportType = new SportType[0], User = null, UserId = 0
            });

            sut.Add(new SportComplex
            {
                Id = 2, Name="Basketball", SportType = new SportType[0], User = null, UserId = 0
            });

            var item = sut.GetById(2);
            Assert.NotNull(item);
            Assert.That(item.Id, Is.EqualTo(2));
            Assert.That(item.Name, Is.EqualTo("Basketball"));
        }
    }
}
