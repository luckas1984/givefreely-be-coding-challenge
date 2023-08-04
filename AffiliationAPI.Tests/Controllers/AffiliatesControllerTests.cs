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

namespace AffiliationAPI.Tests.Controllers
{
    public class AffiliatesControllerTests
    {
        [Fact]
        public void AffiliatesController_Constructor_Throws()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new AffiliatesController(null));
            Assert.Equal("affiliatesService", ex.ParamName);
        }

        [Fact]
        public void GetAffiliates_EmptyCollection()
        {
            // Arrange
            var affiliates = new List<Affiliate>();
            var affiliatesServicemock = new Mock<IAffiliatesService>();
            affiliatesServicemock.Setup(x => x.GetAll()).Returns(affiliates);
            var controller = new AffiliatesController(affiliatesServicemock.Object);

            // Act
            var result = controller.Get();

            // Assert
            result
                .Should()
                .BeNullOrEmpty();
        }

        [Fact]
        public void GetAffiliates_ThrowException()
        {
            // Arrange
            var affiliates = new List<Affiliate>();
            var affiliatesServicemock = new Mock<IAffiliatesService>();
            affiliatesServicemock.Setup(x => x.GetAll()).Throws(new NullReferenceException());
            var controller = new AffiliatesController(affiliatesServicemock.Object);

            // Act
            Action act = () => controller.Get();

            // Assert
            act
                .Should()
                .Throw<NullReferenceException>();
        }

        [Fact]
        public void GetAffiliates_TwoItemsCollection()
        {
            // Arrange
            var affiliates = new List<Affiliate>() {
                Mock.Of<Affiliate>(),
                Mock.Of<Affiliate>()
            };
            var affiliatesServicemock = new Mock<IAffiliatesService>();
            affiliatesServicemock.Setup(x => x.GetAll()).Returns(affiliates);
            var controller = new AffiliatesController(affiliatesServicemock.Object);

            // Act
            var result = controller.Get();

            // Assert
            result
                .Should()
                .NotBeNullOrEmpty()
                .And
                .HaveCount(2);
        }

        [Fact]
        public void AddAffiliate()
        {
            // Arrange
            var name = "John Doe";
            var affiliate = Mock.Of<Affiliate>();
            var affiliatesServicemock = new Mock<IAffiliatesService>();
            affiliatesServicemock.Setup(x => x.Insert(It.IsAny<string>())).Returns(affiliate);
            var controller = new AffiliatesController(affiliatesServicemock.Object);

            // Act
            var result = controller.Post(name);

            // Assert
            result
                .Should()
                .NotBeNull()
                .And
                .Be(affiliate);
        }

        [Fact]
        public void GetCustomerByAffiliate_SingleResult()
        {
            // Arrange
            var affiliate = "Unicef";
            var customers = new List<Customer> {
                Mock.Of<Customer>()
            };
            var affiliatesServicemock = new Mock<IAffiliatesService>();
            affiliatesServicemock.Setup(x => x.GetCustomers(affiliate)).Returns(customers);
            var controller = new AffiliatesController(affiliatesServicemock.Object);

            // Act
            var result = controller.GetByAffiliate(affiliate);

            // Assert
            result
                .Should()
                .NotBeNullOrEmpty()
                .And
                .ContainSingle();
        }

        [Fact]
        public void GetCustomerByAffiliate_Empty()
        {
            // Arrange
            var affiliate = "Red Cross";
            var customers = Enumerable.Empty<Customer>();
            var affiliatesServicemock = new Mock<IAffiliatesService>();
            affiliatesServicemock.Setup(x => x.GetCustomers(affiliate)).Returns(customers);
            var controller = new AffiliatesController(affiliatesServicemock.Object);

            // Act
            var result = controller.GetByAffiliate(affiliate);

            // Assert
            result
                .Should()
                .BeEmpty();
        }
    }
}
