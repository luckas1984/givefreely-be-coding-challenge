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
    // TODO
    public class ReportsServiceTests
    {
        [Fact]
        public void ReportsService_Constructor_Throws()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new ReportsService(null));
            Assert.Equal("unitOfWork", ex.ParamName);
        }

        [Fact]
        public void Commission_Reporting_Single_Affiliate_and_Customer()
        {
            // Arrange
            var customerDto = Mock.Of<CustomerDto>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var affiliateRepo = new Mock<IRepository<Affiliate>>();
            var affiliate = Mock.Of<Affiliate>();
            var customer = Mock.Of<Customer>();
            affiliate.Customers.Add(customer);
            affiliateRepo.Setup(r => r.All()).Returns(new List<Affiliate> { affiliate }.AsQueryable());
            unitOfWorkMock.Setup(uow => uow.Repository<Affiliate>()).Returns(affiliateRepo.Object);


            var service = new ReportsService(unitOfWorkMock.Object);

            var reportResultExpected = new List<ReferredCustomerDTO>() {
                new ReferredCustomerDTO()
                {
                    Affiliate = affiliate.Name,
                    ReferredCustomers = 1
                }
            };

            // Act

            var report = service.CommissionReporting();

            // Assert
            report.
                Should()
                .NotBeNull()
                .And
                .BeEquivalentTo(reportResultExpected);
        }
    }
}
