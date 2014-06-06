// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="UsersServiceTests.cs" project="RunnersTimeManagement.ServerServices.UnitTests" date="2014-06-04 16:34">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.ServerServices.UnitTests
{
    using NUnit.Framework;

    using RunnersTimeManagement.ServerServices.Services;

    [TestFixture]
    public class UsersService_CreatingAccount_Tests
    {
        private UsersService _usersService;

        [SetUp]
        public void TestSetup()
        {
            var provider = new TestsDatabaseProvider();
            provider.InitDatabase();
            _usersService = new UsersService(provider);
        }

        [Test]
        public void UsersService_providingUsernameAndPassword_shouldCreateAccount()
        {
            //arrange
            string username = "pawel";
            string password = "pass00";

            //act
            var result = _usersService.CreateUser(username, password);

            //assert
            Assert.AreEqual(0, result.Status);
            Assert.AreEqual("User was created sucessfully", result.StatusDescription);
            //fixme: add UserExist method in UsersService
            Assert.AreEqual(-1, _usersService.CreateUser(username,password).Status);
        }

        [Test]
        public void UsersService_providingDuplicateUsernameAndPassword_shouldNotCreateAccount()
        {
            //arrange
            string username = "initialUser";
            string password = "pass00";

            //act
            var result = _usersService.CreateUser(username, password);

            //assert
            Assert.AreEqual(-1, result.Status);
            Assert.AreEqual("User already exists", result.StatusDescription);
        }

        [Test]
        public void UsersService_providingOnlyUsername_shouldNotCreateAccount()
        {
            //arrange
            string username = "testUserWithNoPassword";
            string password = "";

            //act
            var result = _usersService.CreateUser(username, password);

            //assert
            Assert.AreEqual(-1, result.Status);
            Assert.AreEqual("Please provide password", result.StatusDescription);
        }

        [Test]
        public void UsersService_providingOnlyPassword_shouldNotCreateAccount()
        {
            //arrange
            string username = "";
            string password = "passwordWithnoUser";

            //act
            var result = _usersService.CreateUser(username, password);

            //assert
            Assert.AreEqual(-1, result.Status);
            Assert.AreEqual("Please provide username", result.StatusDescription);
        }
    }

    [TestFixture]
    [Ignore]
    public class UsersService_Login_Tests
    {
        private UsersService _usersService;

        [SetUp]
        public void TestSetup()
        {
            var provider = new TestsDatabaseProvider();
            provider.InitDatabase();
            _usersService = new UsersService(provider);
        }

        [Test]
        public void UserServiceLogin_ProvidingValidCredentials_shouldLogin()
        {
            //arrange
            string username = "initialUser";
            string password = "initialPassword";

            //act
            var result = _usersService.LoginUser(username, password);

            //assert
            Assert.AreEqual(0, result.Status);
            Assert.AreEqual("User logged in", result.StatusDescription);
        }

        [Test]
        public void UserServiceLogin_ProvidingValidCredentials_shouldReturnAccessToken()
        {
            //arrange
            string username = "initialUser";
            string password = "initialPassword";

            //act
            var result = _usersService.LoginUser(username, password);

            //assert
            Assert.IsNotNull(result.Data);
        }

        [Test]
        public void UserServiceLogin_ProvidingInvalidCredentials_shouldNOTLogin([Values("nonExistingUser", "", "userWithNoPassowrd")]string username, [Values("notExistingPassword","passwordWithNoUser", "")]string password)
        {
            //act
            var result = _usersService.LoginUser(username, password);

            //assert
            Assert.AreEqual(-1, result.Status);
            Assert.AreEqual("Provide valid username and password", result.StatusDescription);
        }
    }
}
