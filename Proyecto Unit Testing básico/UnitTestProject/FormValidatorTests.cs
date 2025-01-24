using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture.Xunit2; // Framework de pruebas
using Xunit; // Framework de pruebas
using WebFormsApp; // Proyecto Web Forms

namespace UnitTestProject
{
    public class FormValidatorTests
    {
        [Fact]
        public void IsValidName_ShouldReturnTrue_WhenNameIsNotEmpty()
        {
            // Arrange
            var validator = new FormValidator();
            string name = "John Doe";

            // Act
            bool result = validator.IsValidName(name);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsValidAge_ShouldReturnFalse_WhenAgeIsLessThan18()
        {
            // Arrange
            var validator = new FormValidator();
            int age = 17;

            // Act
            bool result = validator.IsValidAge(age);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsValidName_ShouldFail_WhenNameIsEmpty()
        {
            // Arrange
            var validator = new FormValidator();
            string name = "";

            // Act
            bool result = validator.IsValidName(name);

            // Assert
            Assert.True(result); // Debería fallar porque un nombre vacío no es válido
        }

        [Fact]
        public void IsValidName_ShouldFail_WhenNameIsWhitespace()
        {
            // Arrange
            var validator = new FormValidator();
            string name = "   ";

            // Act
            bool result = validator.IsValidName(name);

            // Assert
            Assert.True(result); // Debería fallar porque un nombre con espacios no es válido
        }

        [Fact]
        public void IsValidAge_ShouldFail_WhenAgeIsNegative()
        {
            // Arrange
            var validator = new FormValidator();
            int age = -5;

            // Act
            bool result = validator.IsValidAge(age);

            // Assert
            Assert.True(result); // Debería fallar porque una edad negativa no es válida
        }

        [Theory, AutoData]
        public void IsValidPerson_ShouldReturnTrue_ForValidData(string name, int age)
        {
            // Arrange
            var validator = new FormValidator();

            // Act
            bool result = validator.IsValidPerson(name, age);

            Console.WriteLine($"Generated Name: {name}");
            Console.WriteLine($"Generated Age: {age}");
            // Assert
            Assert.True(result);
        }

        [Theory, AutoData]
        public void IsValidPerson_ShouldReturnFalse_WhenNameIsEmpty(string name, int age)
        {
            // Arrange
            var validator = new FormValidator();

            // Act
            bool result = validator.IsValidPerson("", age);

            Console.WriteLine($"Generated Name: {name}");
            Console.WriteLine($"Generated Age: {age}");
            // Assert
            Assert.False(result);
        }

        [Theory, AutoData]
        public void IsValidPerson_ShouldReturnFalse_WhenAgeIsInvalid(string name, int age)
        {

            // Arrange
            var validator = new FormValidator();

            // Act
            bool result = validator.IsValidPerson(name, -5); // Edad negativa
            Console.WriteLine($"Generated Name: {name}");
            Console.WriteLine($"Generated Age: {age}");
            // Assert
            Assert.False(result);
            
        }
    }
}

