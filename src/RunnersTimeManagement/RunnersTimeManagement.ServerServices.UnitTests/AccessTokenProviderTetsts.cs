namespace RunnersTimeManagement.ServerServices.UnitTests
{
    using NUnit.Framework;

    [TestFixture]
    public class AccessTokenProviderTetsts
    {
        private AccessTokenProvider.AccessTokenProvider providerSut;

        [SetUp]
        public void Setup()
        {
            providerSut = new AccessTokenProvider.AccessTokenProvider();   
        }

        [Test]
        public void AccessTokenProvider_providingTwoCredentials_shouldReturnTwoDifferentAccessTokens()
        {
            //act
            string token1 = providerSut.GenerateToken("user1", "pass1");
            string token2 = providerSut.GenerateToken("user2", "pass1");

            //assert
            Assert.AreNotEqual(token1,token2);
        }

        [Test]
        [ExpectedException]
        public void AccessTokenProvider_providingEmptyPasswordCredentials_shouldThrowException()
        {
            //act
            providerSut.GenerateToken("user", "");
        }

        [Test]
        [ExpectedException]
        public void AccessTokenProvider_providingEmptyUsernameCredentials_shouldThrowException()
        {
            //act
            providerSut.GenerateToken("", "password");
        }
    }
}