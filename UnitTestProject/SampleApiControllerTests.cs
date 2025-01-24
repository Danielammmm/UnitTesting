using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

public class SampleApiControllerTests
{
    private readonly HttpClient _client;

    public SampleApiControllerTests()
    {
        _client = new HttpClient
        {
            BaseAddress = new System.Uri("http://localhost:5000/") // Cambia al puerto correcto
        };
    }

    [Fact]
    public async Task GetSampleData_ShouldReturnListOfValues()
    {
        // Act
        var response = await _client.GetAsync("api/sample/data");
        var data = await response.Content.ReadAsAsync<string[]>();

        // Assert
        response.IsSuccessStatusCode.Should().BeTrue();
        data.Should().Contain(new[] { "Value1", "Value2", "Value3" });
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public async Task GetSampleDataById_ShouldReturnValueForGivenId(int id)
    {
        // Act
        var response = await _client.GetAsync($"api/sample/data/{id}");
        var data = await response.Content.ReadAsStringAsync();

        // Assert
        response.IsSuccessStatusCode.Should().BeTrue();
        data.Should().Be($"Value{id}");
    }
}