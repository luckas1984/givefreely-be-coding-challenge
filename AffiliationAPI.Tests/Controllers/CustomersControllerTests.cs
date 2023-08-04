using AffiliationAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Moq.Language;
using Affiliation.Domain.Services;
using Affiliation.Domain.Models;
using FluentAssertions;
using Affiliation.Domain.Dtos;

namespace AffiliationAPI.Tests.Controllers
{
    public class CustomersControllerTests
    {
        [Fact]
        public void CustomersControllerTests_Constructor_Throws()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new CustomersController(null));
            Assert.Equal("customerService", ex.ParamName);
        }

        [Fact]
        public void Affiliate()
        {
            // Arrange
            var affiliates = new List<Affiliate>();
            var customerdto = Mock.Of<CustomerDto>();
            var customer = new Customer() { 
                Name = customerdto.Name,
                Id = 1
            };
            var customerServicemock = new Mock<ICustomerService>();
            customerServicemock.Setup(x => x.Affiliation(customerdto)).Returns(customer);
            var controller = new CustomersController(customerServicemock.Object);

            // Act
            var result = controller.Post(customerdto);

            // Assert
            result
                .Should()
                .Be(customer);
        }

        [Fact]
        public void GetAffiliates_ThrowException()
        {
            // Arrange
            var affiliates = new List<Affiliate>();
            var customerdto = Mock.Of<CustomerDto>();
            var customer = new Customer()
            {
                Name = customerdto.Name,
                Id = 1
            };
            var customerServicemock = new Mock<ICustomerService>();
            customerServicemock.Setup(x => x.Affiliation(customerdto)).Throws(new Exception());
            var controller = new CustomersController(customerServicemock.Object);

            // Act
            Action act = () => controller.Post(customerdto);

            // Assert
            act
                .Should()
                .Throw<Exception>();
        }
    }
}
