// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="TimeServiceTests.cs" project="RunnersTimeManagement.ServerServices.UnitTests" date="2014-06-08 11:49">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.ServerServices.UnitTests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    using RunnersTimeManagement.Core.Domain;
    using RunnersTimeManagement.ServerServices.Services;

    [TestFixture]
    [Ignore]
    public class TimeServiceAndTokenTests
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

    [TestFixture]
    public class TimeServiceAndTimeEntryFilterTests
    {
        private TimeService _timeServiceSut;

        [SetUp]
        public void Setup()
        {
            var provider = TestsDatabaseProvider.ReturnInitializedDatabase();
            _timeServiceSut = new TimeService(provider);
        }


        [Test]
        public void TimeService_providingTokenAndEmpty_shouldReturnAll4Entires()
        {
            //act
            var operationStatus = _timeServiceSut.GetTimeEntryList(TestsConst.UserToken, new TimeEntryFilter());

            //assert
            Assert.IsTrue((bool)operationStatus);
            Assert.AreEqual(4,((List<TimeEntry>)operationStatus.Data).Count);
        }

        [Test]
        public void TimeService_providingTokenAndOnlyStartDate_shouldReturnInvalidOperationStatus()
        {
            //act
            var operationStatus = _timeServiceSut.GetTimeEntryList(TestsConst.UserToken, new TimeEntryFilter(){StartDate = DateTime.Now});

            //assert
            Assert.IsFalse((bool)operationStatus);
        }

        [Test]
        public void TimeService_providingTokenAndOnlyEndDate_shouldReturnInvalidOperationStatus()
        {
            //act
            var operationStatus = _timeServiceSut.GetTimeEntryList(TestsConst.UserToken, new TimeEntryFilter() { EndDate = DateTime.Now });

            //assert
            Assert.IsFalse((bool)operationStatus);
        }

        [Test]
        public void TimeService_providingTokenAndStartDateLowerThenEndDate_shouldReturnInvalidOperationStatus()
        {
            //act
            var operationStatus = _timeServiceSut.GetTimeEntryList(TestsConst.UserToken, new TimeEntryFilter()
                                                                                             {
                                                                                                 StartDate = DateTime.Now.AddDays(4),
                                                                                                 EndDate = DateTime.Now
                                                                                             });

            //assert
            Assert.IsFalse((bool)operationStatus);
        }

        [Test]
        public void TimeService_providingStartAndEndDate8And2DaysInPast_shouldReturn2Record()
        {
            //act
            var operationStatus = _timeServiceSut.GetTimeEntryList(TestsConst.UserToken, new TimeEntryFilter()
            {
                StartDate = DateTime.Now.AddDays(-8),
                EndDate = DateTime.Now.AddDays(-2)
            });

            //assert
            Assert.IsTrue((bool)operationStatus);
            Assert.AreEqual(2, ((List<TimeEntry>)operationStatus.Data).Count);
        }

        [Test]
        public void TimeService_providingStartDate2DaysInPastAndEndDate3DaysInFuture_shouldReturn2Record()
        {
            //act
            var operationStatus = _timeServiceSut.GetTimeEntryList(TestsConst.UserToken, new TimeEntryFilter()
            {
                StartDate = DateTime.Now.AddDays(-2),
                EndDate = DateTime.Now.AddDays(3)
            });

            //assert
            Assert.IsTrue((bool)operationStatus);
            Assert.AreEqual(2, ((List<TimeEntry>)operationStatus.Data).Count);
        }

    }

}