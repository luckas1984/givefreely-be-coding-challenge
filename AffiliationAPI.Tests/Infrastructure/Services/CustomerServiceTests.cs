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
    public class CustomerServiceTests
    {
        [Fact]
        public void CustomerService_Constructor_Throws()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new CustomerService(null));
            Assert.Equal("unitOfWork", ex.ParamName);
        }

        [Fact]
        public void Afiliation_Test()
        {
            // Arrange
            var customerDto = Mock.Of<CustomerDto>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var affiliateRepo = new Mock<IRepository<Affiliate>>();
            var affiliate = Mock.Of<Affiliate>();
            affiliateRepo.Setup(r => r.Get(customerDto.AffiliateId)).Returns(affiliate);
            unitOfWorkMock.Setup(uow => uow.Repository<Affiliate>()).Returns(affiliateRepo.Object);
            
            var customerRepo = new Mock<IRepository<Customer>>();
            var customerModel = new Customer()
            {
                Name = customerDto.Name,
                Id = 1
            };
            customerRepo.Setup(c => c.Insert(It.IsAny<Customer>())).Returns(customerModel);
            unitOfWorkMock.Setup(uow => uow.Repository<Customer>()).Returns(customerRepo.Object);

            var service = new CustomerService(unitOfWorkMock.Object);

            // Act

            var customer = service.Affiliation(customerDto);

            // Assert
            customer.
                Should()
                .NotBeNull()
                .And
                .Be(customer);
        }
    }
}
