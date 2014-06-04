// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="JsonHelpersTests.cs" project="RunnersTimeManagement.ClientServices.UnitTests" date="2014-06-04 09:09">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.ClientServices.UnitTests
{
    using System.Globalization;

    using NUnit.Framework;

    using RunnersTimeManagement.Core.Domain;

    [TestFixture]
    public class JsonHelpersTests
    {
        [Test]
        public void JsonString_PassingValidString_ReturnsUserObject()
        {
            //arrange
            string username = "pawel";
            string password = "001010";
            long id = 1;
            string json = string.Format("{{\"id\":\"{0}\",\"username\":\"{1}\",\"password\":\"{2}\"}}", id, username, password);

            //act
            var user = JsonHelpers.ConvertFromJson<User>(json);

            //assert
            Assert.AreEqual(id, user.Id);
            Assert.AreEqual(username, user.UserName);
            Assert.AreEqual(password, user.Password);
        }

        [Test]
        public void JsonString_PassingInvalidString_ReturnsNull()
        {
            //act
            var user = JsonHelpers.ConvertFromJson<User>("asddd");

            //assert
            Assert.AreEqual(null, user);
        }

        [Test]
        public void UserObject_PassingObject_ReturnsJsonUserString()
        {
            //arrange
            User user = new User() { Id = 100, UserName = "Pawel", Password = "9999" };

            //act
            string json = JsonHelpers.ConvertToJson(user);
            
            //assert
            StringAssert.Contains(user.Id.ToString(CultureInfo.InvariantCulture), json);
            StringAssert.Contains(user.UserName, json);
            StringAssert.Contains(user.Password, json);
        }
    }
}
