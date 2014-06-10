// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="ReportGeneratorTests.cs" project="RunnersTimeManagement.ServerServices.UnitTests" date="2014-06-10 09:19">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.ServerServices.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;

    using RunnersTimeManagement.Core.Domain;
    using RunnersTimeManagement.ServerServices.ReportGenerator;

    [TestFixture]
    public class ReportGeneratorTests
    {
        private ReportGenerator _reportGenerator;

        [SetUp]
        public void TestSetup()
        {
            _reportGenerator = new ReportGenerator();
        }

        [Test]
        public void ReportGenerator_providingEmptyList_should_returnEmptyReport()
        {
            //arrange
            var emptyList = new List<TimeEntry>();

            //act
            var report = _reportGenerator.GenerateWeeklyReport(emptyList);

            //assert
            Assert.IsFalse(report.Any(r => r.AverageSpeed > 0 || r.AverageDistance > 0));
        }

        [Test]
        public void ReportGenerator_providingOneTimeEntry_shouldReturnReportWithOneEntry()
        {
            //arrange
            var list = new List<TimeEntry>()
                           {
                               new TimeEntry() { Distance = 1, TimeElapsed = 1, EntryDate = DateTime.Now }
                           };

            //act
            var report = _reportGenerator.GenerateWeeklyReport(list);

            //assert
            Assert.AreEqual(1, report.Count(r => r.AverageSpeed > 0 || r.AverageDistance > 0));
        }
        [Test]
        public void ReportGenerator_providing2ReportsInSameDay_shouldReturnReportWithOneEntry()
        {
            //arrange
            var list = new List<TimeEntry>()
                           {
                               new TimeEntry() { Distance = 1, TimeElapsed = 1, EntryDate = DateTime.Now },
                               new TimeEntry() { Distance = 2, TimeElapsed = 2, EntryDate = DateTime.Now },
                           };

            //act
            var report = _reportGenerator.GenerateWeeklyReport(list);

            //assert
            Assert.AreEqual(1, report.Count(r => r.AverageSpeed > 0 || r.AverageDistance > 0));
        }

        [Test]
        public void ReportGenerator_providing2ReportsInDifferentWeeks_shouldReturnReportWithTwoEntry()
        {
            //arrange
            DateTime now = DateTime.Now;
            DateTime otherWeekInCurrentYear = DateTime.Now.AddDays(9).Year == now.Year ? DateTime.Now.AddDays(9) : DateTime.Now.AddDays(-9);

            var list = new List<TimeEntry>()
                           {
                               new TimeEntry() { Distance = 1, TimeElapsed = 1, EntryDate =now },
                               new TimeEntry() { Distance = 2, TimeElapsed = 2, EntryDate = otherWeekInCurrentYear },
                           };

            //act
            var report = _reportGenerator.GenerateWeeklyReport(list);

            //assert
            Assert.AreEqual(2, report.Count(r => r.AverageSpeed > 0 || r.AverageDistance > 0));
        }


        [Test]
        public void ReportGenerator_providingReport_shouldReturnReportWithOneEntryAndCorrectAverageValues()
        {
            //arrange
            TimeEntry entry = new TimeEntry() { Distance = 2, TimeElapsed = 2, EntryDate = DateTime.Now };
            var list = new List<TimeEntry>();
            list.Add(entry);

            //act
            var report = _reportGenerator.GenerateWeeklyReport(list);

            //assert
            Assert.IsTrue(report.Any(r => r.AverageSpeed == entry.AverageSpeed && r.AverageDistance == entry.Distance));
        }
    }
}
