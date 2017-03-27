using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Guys_Guys_App.Utility;
using Moq;
using System.Linq;
using Guys_Guys_App.Model.Exception;
using System.Diagnostics;

namespace Guys_Guys_App.Utility.Tests
{
    [TestClass()]
    public class ServiceRegistryTest
    {

        [TestMethod()]
        public void RegisterTest_Success()
        {
            // Arrange
            ServiceRegistry testRegistry = new ServiceRegistry();
            Mock<Service> mockService = new Mock<Service>();

            // Act
            testRegistry.Register(mockService.Object);

            // Assert
            Assert.AreEqual(1, testRegistry.GetServices().Count());

            // Act
            testRegistry.Register(mockService.Object);

            // Assert
            Assert.AreEqual(1, testRegistry.GetServices().Count());

            // Arrange
            Mock<Service> mockServiceTwo = new Mock<Service>();

            // Act
            testRegistry.Register(mockServiceTwo.Object);

            // Assert
            Assert.AreEqual(2, testRegistry.GetServices().Count());
        }

        [TestMethod()]
        public void RegisterTest_Fail()
        {
            // Arrange
            ServiceRegistry testRegistry = new ServiceRegistry();
            Mock<Service> mockService = new Mock<Service>();
            mockService.Setup(x => x.start(It.IsAny<ServiceRegistry>())).Throws(new Exception("Start error"));

            try
            {
                // Act
                testRegistry.Register(mockService.Object);

                // Assert - Exception expected
                Assert.Fail();
            }
            catch (ServiceRegistrationException)
            {
                // Assert
                Assert.AreEqual(0, testRegistry.GetServices().Count());
            }

            // Arrange
            Mock<Service> mockServiceTwo = new Mock<Service>();
            mockService.Setup(x => x.start(It.IsAny<ServiceRegistry>())).Throws(new Exception("Start error"));
            mockService.Setup(x => x.stop(It.IsAny<ServiceRegistry>())).Throws(new Exception("Stop error"));

            try
            {
                // Act
                testRegistry.Register(mockService.Object);

                // Assert - Exception expected
                Assert.Fail();
            }
            catch (ServiceRegistrationException e)
            {
                // Assert
                Assert.AreEqual(e.InnerException.GetType(), typeof(ServiceDeregistrationException));
                Assert.AreEqual(0, testRegistry.GetServices().Count());
            }
        }

        [TestMethod()]
        public void GetServicesTest()
        {
            // Arrange
            ServiceRegistry testRegistry = new ServiceRegistry();

            // Act
            var services = testRegistry.GetServices();

            // Assert
            Assert.AreEqual(0, services.Count());

            // Arrange
            Mock<Service> mockService = new Mock<Service>();
            testRegistry.Register(mockService.Object);

            // Act
            services = testRegistry.GetServices();

            // Assert
            Assert.AreEqual(1, services.Count());
            Assert.AreEqual(true, services.Contains(mockService.Object));
        }

        [TestMethod()]
        public void GetServiceTest()
        {
            // Arrange
            ServiceRegistry testRegistry = new ServiceRegistry();
            Mock<Service> mockService = new Mock<Service>();
            testRegistry.Register(mockService.Object);

            // Act
            var result = testRegistry.GetService<Service>();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, mockService.Object);
        }

        [TestMethod()]
        public void ClearTest()
        {
            // Arrange
            ServiceRegistry testRegistry = new ServiceRegistry();
            Mock<Service> mockService = new Mock<Service>();
            testRegistry.Register(mockService.Object);

            // Act
            testRegistry.Clear();

            // Assert
            Assert.AreEqual(0, testRegistry.GetServices().Count());
        }


    }
}