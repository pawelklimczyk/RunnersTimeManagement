// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="LoginServiceTests.cs" project="RunnersTimeManagement.ClientServices.UnitTests" date="2014-06-04 10:54">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.ClientServices.UnitTests
{
    using NSubstitute;

    using NUnit.Framework;

    [TestFixture]
    public class LoginServiceTests
    {
        private LoginService _loginService;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void LogingService_UsingValidCachedUser_ShouldLoginUser()
        {
            //arrange
            string dummyString;
            var fileServiceStub = Substitute.For<IFileService>();
            fileServiceStub.TryReadTextFile(Arg.Any<string>(), out dummyString).Returns(x =>
                {
                    x[1] = validUserJson();
                    return true;
                });
            _loginService = new LoginService(fileServiceStub);

            //act
            bool result = _loginService.TryRunWithCachecCredentials();

            //assert
            Assert.IsTrue(result);
        }

        [Test]
        public void LogingService_UsingEmptyCachedUser_ShouldLoginUser()
        {
            //arrange
            string dummyString;
            var fileServiceStub = Substitute.For<IFileService>();
            fileServiceStub.TryReadTextFile(Arg.Any<string>(), out dummyString).Returns(x =>
                {
                    x[1] = string.Empty;
                    return true;
                });

            _loginService = new LoginService(fileServiceStub);

            //act
            bool result = _loginService.TryRunWithCachecCredentials();

            //assert
            Assert.IsFalse(result);
        }

        private string validUserJson()
        {
            string username = "pawel";
            string password = "001010";
            long id = 1;
            return string.Format("{{\"id\":\"{0}\",\"username\":\"{1}\",\"password\":\"{2}\"}}", id, username, password);
        }
    }
}
