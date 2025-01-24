using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Moq; // Biblioteca Moq para simular dependencias
using Xunit; // Framework xUnit para pruebas

namespace DemoWebFormsApiDb.Tests
{
    public class DatabaseRepositoryTests
    {
        [Fact] // Indica que esta es una prueba unitaria
        public void GetAllUsers_ReturnsDataTable()
        {
            // Arrange: Configuración inicial
            // Aquí se crea un mock (simulación) de la interfaz IDataRepository
            var mockRepository = new Mock<IDataRepository>();

            // Se define una tabla ficticia para simular la respuesta de la base de datos
            var mockTable = new DataTable();
            mockTable.Columns.Add("Id", typeof(int)); // Agrega una columna "Id" de tipo entero
            mockTable.Columns.Add("Name", typeof(string)); // Agrega una columna "Name" de tipo cadena
            mockTable.Rows.Add(1, "John Doe"); // Agrega una fila con datos ficticios

            // Configura el método GetAllUsers del mock para que devuelva la tabla ficticia
            mockRepository.Setup(repo => repo.GetAllUsers()).Returns(mockTable);

            // Se obtiene la instancia simulada de IDataRepository
            var repository = mockRepository.Object;

            // Act: Ejecución del método bajo prueba
            // Llama al método simulado GetAllUsers
            DataTable result = repository.GetAllUsers();

            // Assert: Verificación de resultados
            // Verifica que el resultado no sea nulo
            Assert.NotNull(result);

            // Verifica que la tabla devuelta tenga exactamente una fila
            Assert.Equal(1, result.Rows.Count);

            // Verifica que el valor de la columna "Name" en la primera fila sea "John Doe"
            Assert.Equal("John Doe", result.Rows[0]["Name"]);
        }
    }
}
