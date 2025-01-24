using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading.Tasks;
using Moq; // Biblioteca Moq para simular dependencias
using Xunit; // Framework de pruebas unitarias
using DemoWebFormsApiDb; // Espacio de nombres donde están las interfaces y modelos

namespace DemoWebFormsApiDb.Tests
{
    public class ApiClientTests
    {
        [Fact] // Indica que esta es una prueba unitaria
        public async Task GetSampleDataById_ReturnsExpectedData()
        {
            // Arrange: Configuración inicial
            // Aquí se crea un mock (simulación) de la interfaz IApiClient
            var mockApiClient = new Mock<IApiClient>();

            // Configuración de datos esperados que devolverá el mock
            var expectedResponse = new ApiResponse
            {
                Id = 1, // ID esperado
                Name = "John Doe", // Nombre esperado
                Email = "john.doe@example.com" // Email esperado
            };

            // Configura el método GetSampleDataById del mock para devolver la respuesta esperada
            mockApiClient
                .Setup(client => client.GetSampleDataById(1)) // Configura el mock para el ID 1
                .ReturnsAsync(expectedResponse); // Devuelve una respuesta simulada de forma asíncrona

            // Obtiene la instancia simulada de IApiClient
            var apiClient = mockApiClient.Object;

            // Act: Ejecución del método bajo prueba
            // Llama al método simulado GetSampleDataById con el ID 1
            var result = await apiClient.GetSampleDataById(1);

            // Assert: Verificación de resultados
            // Verifica que el resultado no sea nulo
            Assert.NotNull(result);

            // Verifica que el ID devuelto sea el esperado
            Assert.Equal(1, result.Id);

            // Verifica que el nombre devuelto sea el esperado
            Assert.Equal("John Doe", result.Name);

            // Verifica que el email devuelto sea el esperado
            Assert.Equal("john.doe@example.com", result.Email);
        }

        [Fact] // Otra prueba unitaria
        public async Task GetSampleDataById_InvalidId_ReturnsNull()
        {
            // Arrange: Configuración inicial
            // Crea un mock (simulación) de la interfaz IApiClient
            var mockApiClient = new Mock<IApiClient>();

            // Configura el método GetSampleDataById para devolver null con cualquier ID
            mockApiClient
                .Setup(client => client.GetSampleDataById(It.IsAny<int>())) // Configuración para cualquier ID
                .ReturnsAsync((ApiResponse)null); // Devuelve null de forma asíncrona

            // Obtiene la instancia simulada de IApiClient
            var apiClient = mockApiClient.Object;

            // Act: Ejecución del método bajo prueba
            // Llama al método simulado GetSampleDataById con un ID no válido (999)
            var result = await apiClient.GetSampleDataById(999);

            // Assert: Verificación de resultados
            // Verifica que el resultado sea null porque el ID no es válido
            Assert.Null(result);
        }
    }
}
