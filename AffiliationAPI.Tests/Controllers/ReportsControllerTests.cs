using AffiliationAPI.Controllers;
using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using Affiliation.Domain.Services;
using FluentAssertions;
using Affiliation.Domain.Dtos;

namespace AffiliationAPI.Tests.Controllers
{
    public class ReportsControllerTests
    {
        [Fact]
        public void ReportsControllerTests_Constructor_Throws()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new ReportsController(null));
            Assert.Equal("reportService", ex.ParamName);
        }

        [Fact]
        public void CommissionReportTest()
        {
            // Arrange
            var reportsServicemock = new Mock<IReportsService>();
            var reportMock = new List<ReferredCustomerDTO>()
            { 
                Mock.Of<ReferredCustomerDTO>()
            };
            reportsServicemock.Setup(x => x.CommissionReporting()).Returns(reportMock);
            var controller = new ReportsController(reportsServicemock.Object);

            // Act
            var result = controller.Get();

            // Assert
            result
                .Should()
                .NotBeNullOrEmpty()
                .And
                .BeSameAs(reportMock);
        }

        [Fact]
        public void CommissionReport_ThrowException()
        {
            // Arrange
            var reportsServicemock = new Mock<IReportsService>();
            var reportMock = Mock.Of<IEnumerable<ReferredCustomerDTO>>();
            reportsServicemock.Setup(x => x.CommissionReporting()).Throws(new Exception());
            var controller = new ReportsController(reportsServicemock.Object);

            // Act
            Action act = () => controller.Get();

            // Assert
            act
                .Should()
                .Throw<Exception>();
        }
    }
}
