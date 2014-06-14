// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="TimeEntryFilterTests.cs" project="RunnersTimeManagement.Core.UnitTests" date="2014-06-14 19:48">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.Core.UnitTests
{
    using System;

    using NUnit.Framework;

    using RunnersTimeManagement.Core.Domain;

    [TestFixture]
    public class TimeEntryFilterTests
    {
        private TimeEntryFilter sut;

        private DateTime date;

        [SetUp]
        public void Setup()
        {
            sut = new TimeEntryFilter();
            date = new DateTime(2014, 10, 10, 10, 10, 10);
        }

        [Test]
        public void TimeEntryFilter_providedEmptyStartAndEndDate_shouldBeValid()
        {
            //act
            var result = sut.Validate();

            //assert
            Assert.IsTrue((bool)result);
        }

        [Test]
        public void TimeEntryFilter_providedStartLowerAndEndBiggerDate_shouldBeValid()
        {
            //arrange
            sut.StartDate = date;
            sut.EndDate = date.AddDays(1);

            //act
            var result = sut.Validate();

            //assert
            Assert.IsTrue((bool)result);
        }

        [Test]
        public void TimeEntryFilter_providedStartEqualEndDate_shouldBeValid()
        {
            //arrange
            sut.StartDate = date;
            sut.EndDate = date;

            //act
            var result = sut.Validate();

            //assert
            Assert.IsTrue((bool)result);
        }

        [Test]
        public void TimeEntryFilter_providedOnlyStartDate_shouldBeNOTValid()
        {
            //arrange
            sut.StartDate = date;
            
            //act
            var result = sut.Validate();

            //assert
            Assert.IsFalse((bool)result);
        }

        [Test]
        public void TimeEntryFilter_providedOnlyEndDate_shouldBeNOTValid()
        {
            //arrange
            sut.EndDate = date;

            //act
            var result = sut.Validate();

            //assert
            Assert.IsFalse((bool)result);
        }

        [Test]
        public void TimeEntryFilter_providedStartDateBiggerThenEndDate_shouldBeNOTValid()
        {
            //arrange
            sut.StartDate = date.AddDays(1);
            sut.EndDate = date;

            //act
            var result = sut.Validate();

            //assert
            Assert.IsFalse((bool)result);
        }
    }
}
