using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechJobsOO;

namespace TechJobsTests
{
    [TestClass]
    public class JobTest
    {
        string nam = "Tester";
        Employer emp = new Employer("ACME");
        Location loc = new Location("Home");
        PositionType typ = new PositionType("UX");
        CoreCompetency comp = new CoreCompetency("Tasting ability");

        [TestMethod]
        public void TestSettingJobId()
        {
           Job idTest = new Job();
           Job idTest2 = new Job();
           int difference = idTest2.Id - idTest.Id;

           Assert.IsFalse(idTest.Id == idTest2.Id);
           Assert.AreEqual(1, difference);
        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Job productTester = new Job(nam, emp, loc, typ, comp);
            Assert.AreEqual(3, productTester.Id);
            Assert.AreEqual("Tester", productTester.Name);
            Assert.AreEqual(emp, productTester.EmployerName);
            Assert.AreEqual(loc, productTester.EmployerLocation);
            Assert.AreEqual(typ, productTester.JobType);
            Assert.AreEqual(comp, productTester.JobCoreCompetency);
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            Job productTester = new Job("Test1", emp, loc, typ, comp);
            Job productTester2 = new Job("Test2", emp, loc, typ, comp);
            Assert.IsFalse(productTester.Equals(productTester2));
        }

        [TestMethod]
        public void TestJobsToString()
        {
            Job productTester = new Job(nam, emp, loc, typ, comp);
            string sampleListing = $"\nID: 6\nName: Tester\nEmployer: ACME" +
                    $"\nLocation: Home\nPosition Type: UX" +
                    $"\nCore Competency: Tasting ability\n";
            Assert.AreEqual(sampleListing, productTester.ToString());
        }

        [TestMethod]
        public void TestJobsToStringEmptyField()
        {
            Job productTester = new Job(nam, emp, loc, typ, comp);
            productTester.EmployerName.Value = "";
            Assert.AreEqual("\nID: 7\nName: Tester" +
                "\nEmployer: Data not available\nLocation: Home" +
                "\nPosition Type: UX" + 
                "\nCore Competency: Tasting ability\n", productTester.ToString());
        }

        [TestMethod]
        public void TestJobsToStringEmptyJob()
        {
            Job productTester = new Job(nam, emp, loc, typ, comp);
            productTester.Name = "";
            productTester.EmployerName.Value = "";
            productTester.EmployerLocation.Value = "";
            productTester.JobType.Value = "";
            productTester.JobCoreCompetency.Value = "";
            Assert.AreEqual("OOPS! This job does not seem to exist.", productTester.ToString());
        }
    }
}
