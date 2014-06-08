// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="TimeServiceTests.cs" project="RunnersTimeManagement.ServerServices.UnitTests" date="2014-06-08 11:49">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.ServerServices.UnitTests
{
    using NUnit.Framework;

    [TestFixture]
    [Ignore]
    public class TimeServiceTests
    {
        private TimeService _timeServiceSut;

        [Test]
        public void TimeService_providingValidToken_shouldReturnTimeEntriesListInOperationStatusObject()
        {
            //arrange

            //act

            //assert
            Assert.Fail();
        }

        [Test]
        public void TimeService_provifingInvalidToken_shouldReturnOperationStatusFailedMessage()
        {
            //arrange

            //act

            //assert
            Assert.Fail();
        }

        [Test]
        public void TimeService_givenTimeEntryAndValidToken_shouldAddNewTimeEntry()
        {
            //arrange

            //act

            //assert
            Assert.Fail();
        }

        [Test]
        public void TimeService_givenTimeEntryAndInvalidValidToken_shouldNOTAddNewTimeEntry()
        {
            //arrange

            //act

            //assert
            Assert.Fail();
        }

    }
}