using RealEstate.Models;
using RealEstate.Services;
using Moq;
using RealEstate.Repository;
namespace TestRealEstateLib
{
    public class ZaminServiceTest
    {
        ZaminService _service;
        Mock<IZaminRepository> mockRepository = new Mock<IZaminRepository>();
        [SetUp]
        public void Setup() { } //will be called before each test case execution        

        [OneTimeSetUp]
        public void Initialise(){
            _service = new ZaminService(mockRepository.Object);
            mockRepository.Setup((z) => z.AddZamin(It.IsAny<Zamin>())).Returns(true);
        }

        [Test]
        public void TestAddZaminSuccess()
        {
            Zamin z = new() { Area = 1, Name = "adithya", Location = "Yeshwanthpur", Id = 1 };
            Assert.That(_service.AddZamin(z), Is.True);
        }

        [Test]
        public void TestAddZaminNull()
        {
            Assert.Throws<ArgumentNullException>(()=>_service.AddZamin(null));
        }

        [TearDown] public void TearDown() { }
        [OneTimeTearDown] public void Clenup() { }
    }
}



//using System.Security.Cryptography.X509Certificates;
//using RealEstate;
//using RealEstate.Models;
//using RealEstate.Services;
//namespace TestRealEstateLib
//{
//    [TestFixture] //attributes - reflection -- compiler -- runtime
//    public class ZameenServiceTest
//    {
//        ZameenService _service;
//        ZameenService zameenService = new ZameenService();

//        [SetUp]
//        public void Setup()    //Will be called before each test case execution.
//        {
//        }

//        [OneTimeSetUp]
//        public void Initialise()
//        {
//            _service = new ZameenService();
//        }

//        [Test]
//        public void CalculateAreaTestPositive()
//        {
//            Zameen z1 = new Zameen() { Id = 1, Name = "Mukul Goyal", Area = 3000, Location = "Bangalore" };
//            var expected = z1.Area * 11000;
//            var result = _service.CalculatePrice(z1);
//            Assert.That(result, Is.EqualTo(expected));
//        }

//        //[TestCase(p1,4000)]//[TestCase(p2,5555)]//[TestCaseSource(nameof(propertes))]// or

//        [TestCaseSource("properties")]

//        public void CalculateAreaTestNegative(Zameen z, double expected)
//        {
//            Assert.That(zameenService.CalculatePrice(z), Is.EqualTo(expected));
//        }

//        public static object[] properties = [
//            new object[]{new Zameen() { Id = 1, Name = "adithya complex", Location = "Bangalore", Area = 1 },11000d },
//            new object[]{new Zameen() { Id = 1, Name = "adithya complex", Location = "Chennai" ,Area=2},2400 }
//        ];

//        [Test]
//        public void CalculateAreaTestNull()
//        {
//            Zameen z1 = new Zameen() { Id = 1, Name = "Mukul Goyal", Location = "Bangalore" };
//            Assert.Throws<NullReferenceException>(() => { zameenService.CalculatePrice(z1); });
//        }

//        [TearDown]

//        public void TearDown(){} //After each testcase execution it executes

//        [OneTimeTearDown]
//        public void OneTimeTearDown(){ }  //Only once after each and every testcase executes
//    }
//}



