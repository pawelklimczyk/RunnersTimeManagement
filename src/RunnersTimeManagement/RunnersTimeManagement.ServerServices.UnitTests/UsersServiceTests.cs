// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="UsersServiceTests.cs" project="RunnersTimeManagement.ServerServices.UnitTests" date="2014-06-04 16:34">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.ServerServices.UnitTests
{
    using NUnit.Framework;

    using RunnersTimeManagement.ServerServices.AccessTokenProvider;
    using RunnersTimeManagement.ServerServices.Services;

    [TestFixture]
    public class UsersService_CreatingAccount_Tests
    {
        private UsersService _usersServiceSut;

        [SetUp]
        public void TestSetup()
        {
            var provider = new TestsDatabaseProvider();
            provider.InitDatabase();
            this._usersServiceSut = new UsersService(provider);
        }

        [Test]
        public void UsersService_providingUsernameAndPassword_shouldCreateAccount()
        {
            //arrange
            string username = "pawel";
            string password = "pass00";

            //act
            var result = this._usersServiceSut.CreateUser(username, password);

            //assert
            Assert.AreEqual(0, result.Status);
            Assert.AreEqual("User was created sucessfully", result.StatusDescription);
            //fixme: add UserExist method in UsersService
            Assert.AreEqual(-1, this._usersServiceSut.CreateUser(username, password).Status);
        }

        [Test]
        public void UsersService_providingDuplicateUsernameAndPassword_shouldNotCreateAccount()
        {
            //arrange
            string username = "initialUser";
            string password = "pass00";

            //act
            var result = this._usersServiceSut.CreateUser(username, password);

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
            var result = this._usersServiceSut.CreateUser(username, password);

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
            var result = this._usersServiceSut.CreateUser(username, password);

            //assert
            Assert.AreEqual(-1, result.Status);
            Assert.AreEqual("Please provide username", result.StatusDescription);
        }
    }

    [TestFixture]
    public class UsersService_Login_Tests
    {
        private UsersService _usersServiceSut;

        [SetUp]
        public void TestSetup()
        {
            var provider = new TestsDatabaseProvider();
            provider.InitDatabase();
            this._usersServiceSut = new UsersService(provider);
        }

        [Test]
        public void UserServiceLogin_ProvidingValidCredentials_shouldLogin()
        {
            //arrange
            string username = "initialUser";
            string password = "initialPassword";

            //act
            var result = this._usersServiceSut.LoginUser(username, password);

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
            var result = this._usersServiceSut.LoginUser(username, password);

            //assert
            Assert.IsNotNull(result.Data);
        }

        [Test]
        public void UserServiceLogin_ProvidingInvalidCredentials_shouldNOTLogin([Values("nonExistingUser", "", "userWithNoPassowrd")]string username, [Values("notExistingPassword", "passwordWithNoUser", "")]string password)
        {
            //act
            var result = this._usersServiceSut.LoginUser(username, password);

            //assert
            Assert.AreEqual(-1, result.Status);
            Assert.AreEqual("Provide valid username and password", result.StatusDescription);
        }
    }

    [TestFixture]
    public class UsersService_AccessToken_Tests
    {
        private UsersService _usersServiceSut;

        private fakeAccessTokenProvider tokenProviderStub;

        [SetUp]
        public void TestSetup()
        {
            tokenProviderStub = new fakeAccessTokenProvider();
            var provider = new TestsDatabaseProvider();
            provider.InitDatabase();
            this._usersServiceSut = new UsersService(provider, tokenProviderStub);
        }

        [Test]
        public void UsersService_providingValidCredentials_shouldReturnAccessToken()
        {
            //arrange
            string token = "123123123123";
            tokenProviderStub.TokenToReturn = token;
            string username = "initialUser";
            string password = "initialPassword";

            //act
            var result = this._usersServiceSut.LoginUser(username, password);

            //assert
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(token, result.Data.ToString());
        }

        [Test]
        public void UsersService_providingValidAccessToken_userShouldBeAuthorized()
        {
            //arrange
            string tokenInTestData = "token";
            //act
            var operationStatus = this._usersServiceSut.Authorize(tokenInTestData);

            //assert
            Assert.IsTrue((bool)operationStatus.Data);
        }

        [Test]
        public void UsersService_providingInvalidAccessToken_userShouldNOTBeAuthorized()
        {
            //arrange
            string dummyToken = "token00001111";
            //act
            var operationStatus = this._usersServiceSut.Authorize(dummyToken);

            //assert
            Assert.IsFalse((bool)operationStatus.Data);
        }

        class fakeAccessTokenProvider : IAccessTokenProvider
        {
            public string TokenToReturn;

            public string GenerateToken(string username, string password)
            {
                return TokenToReturn;
            }
        }

    }
}
