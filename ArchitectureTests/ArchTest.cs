using NetArchTest.Rules;
using Unik.Application.Repositories;
using Unik.Domain.Entities;

namespace ArchitectureTests
{
    public class ArchTest
    {
        /// <summary>
        /// Domæne skal ikke have dependencies til andre lag
        /// </summary>
        [Fact]
        public void DomainLayer_ShouldNotHaveDependencies()
        {
            // Arrange
            var domainLayerAssembly = typeof(MemberWithAddress).Assembly;
            // Act
            var result = Types.InAssembly(domainLayerAssembly)
                .ShouldNot().HaveDependencyOnAll(
                    ["BackendApi", "Unik.Application", "Unik.Infrastructure"])
                .GetResult();
            // Assert
            Assert.True(result.IsSuccessful);

        }
        /// <summary>
        /// Application skal ikke have dependencies til Infrastructure
        /// </summary>
        [Fact]
        public void ApplicationLayer_ShouldNotDependOnInfrastructureLayer()
        {
            // Arrange
            var applicationLayerAssembly = typeof(IMemberWithAddressRepository).Assembly;
            // Act
            var result = Types.InAssembly(applicationLayerAssembly)
                .ShouldNot().HaveDependencyOn("Unik.Infrastructure")
                .GetResult();
            // Assert
            Assert.True(result.IsSuccessful);
        }
    }
}