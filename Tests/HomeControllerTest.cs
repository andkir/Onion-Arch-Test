using System.Collections.Generic;
using System.Web.Mvc;
using Core;
using Core.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;
using WebApplication2.Controllers;

namespace Tests
{
    [TestFixture]
    public class HomeControllerTest
    {
        private IUserRepository userRepositoryMock = MockRepository.GenerateMock<IUserRepository>();
        private ISportTypeRepository sportTypeRepositoryMock = MockRepository.GenerateMock<ISportTypeRepository>();
        private ISportListOutput sportListOutputMock = MockRepository.GenerateMock<ISportListOutput>();

        [Test]
        public void ListSportTypesTest()
        {
            var sportTypes = new List<SportType>
            {
                new SportType {Id = 1, Name = "football"},
                new SportType {Id = 2, Name = "volleyball"},
                new SportType {Id = 3, Name = "handball"},
            };

            sportTypeRepositoryMock.Expect(r => r.GetAll()).Return(sportTypes).Repeat.Once();
            sportListOutputMock.Expect(o => o.GetSportList(Arg<IEnumerable<SportType>>.List.ContainsAll(sportTypes)))
                .Repeat.Once().Return("data");

            var sut = new HomeController(userRepositoryMock, sportTypeRepositoryMock, sportListOutputMock, null);

            var result = sut.ListSportTypes();

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<ContentResult>());
            sportTypeRepositoryMock.VerifyAllExpectations();
            sportListOutputMock.VerifyAllExpectations();

        }
    }
}
