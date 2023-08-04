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
using Affiliation.Infrastructure.Services;
using Affiliation.Domain;

namespace AffiliationAPI.Tests.Infrastructure.Services
{
    public class AffiliatesServiceTests
    {
        [Fact]
        public void AffiliatesService_Constructor_Throws()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new AffiliatesService(null));
            Assert.Equal("unitOfWork", ex.ParamName);
        }

        [Fact]
        public void Get_All_Affiliates()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var repo = new Mock<IRepository<Affiliate>>();
            var affiliatesItems = new List<Affiliate> { 
                Mock.Of<Affiliate>()
            }.AsQueryable();
            repo.Setup(r => r.All()).Returns(affiliatesItems);

            unitOfWorkMock.Setup(uow => uow.Repository<Affiliate>()).Returns(repo.Object);
            var service = new AffiliatesService(unitOfWorkMock.Object);

            // Act

            var affilites = service.GetAll();

            // Assert
            affilites.
                Should()
                .NotBeNull()
                .And
                .BeSameAs(affiliatesItems);
        }

        [Fact]
        public void Get_An_Empty_Customer_collecion_for_Specific_Affiliate()
        {
            // Arrange
            var affiliate = "Unicef";
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var repo = new Mock<IRepository<Affiliate>>();
            var affiliatesItems = new List<Affiliate> {
                Mock.Of<Affiliate>()
            }.AsQueryable();
            affiliatesItems.First().Name = affiliate;
            repo.Setup(r => r.All()).Returns(affiliatesItems);

            unitOfWorkMock.Setup(uow => uow.Repository<Affiliate>()).Returns(repo.Object);
            var service = new AffiliatesService(unitOfWorkMock.Object);

            // Act

            var customers = service.GetCustomers(affiliate);

            // Assert
            customers.
                Should()
                .BeEmpty();
        }

        [Fact]
        public void Create_new_affiliate()
        {
            // Arrange
            var affiliateName = "Unicef";
            var affiliate = Mock.Of<Affiliate>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var repo = new Mock<IRepository<Affiliate>>();
            repo.Setup(r => r.Insert(It.IsAny<Affiliate>())).Returns(affiliate);

            unitOfWorkMock.Setup(uow => uow.Repository<Affiliate>()).Returns(repo.Object);
            var service = new AffiliatesService(unitOfWorkMock.Object);

            // Act

            var customers = service.Insert(affiliateName);

            // Assert
            customers.
                Should()
                .Be(affiliate);
        }
    }
}
