using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsApp.Services;
using WebFormsApp;
using Moq;
using Xunit;
using FluentAssertions;

namespace UnitTestProject
{
    public class ServiceValidatorTests
    {
        [Fact]
        public void IsNameValid_ShouldReturnTrue_WhenServiceValidatesName()
        {
            // Arrange: Crear un mock de IDataService
            var mockService = new Mock<IDataService>();
            mockService.Setup(service => service.ValidateName("John Doe")).Returns(true);

            var validator = new ServiceValidator(mockService.Object);

            // Act: Validar el nombre usando el mock
            bool result = validator.IsNameValid("John Doe");

            // Assert: Verificar que el resultado sea true
            result.Should().BeTrue();
        }

        [Fact]
        public void IsAgeValid_ShouldReturnFalse_WhenAgeIsBelowMinimum()
        {
            // Arrange: Configurar el mock para devolver una edad mínima de 18
            var mockService = new Mock<IDataService>();
            mockService.Setup(service => service.GetMinimumAge()).Returns(18);

            var validator = new ServiceValidator(mockService.Object);

            // Act: Validar una edad menor al mínimo
            bool result = validator.IsAgeValid(17);

            // Assert: Verificar que el resultado sea false
            result.Should().BeFalse();
        }

        [Fact]
        public void IsAgeValid_ShouldReturnTrue_WhenAgeIsAboveMinimum()
        {
            // Arrange: Configurar el mock para devolver una edad mínima de 18
            var mockService = new Mock<IDataService>();
            mockService.Setup(service => service.GetMinimumAge()).Returns(18);

            var validator = new ServiceValidator(mockService.Object);

            // Act: Validar una edad mayor o igual al mínimo
            bool result = validator.IsAgeValid(20);

            // Assert: Verificar que el resultado sea true
            result.Should().BeTrue();
        }
    }
}
