using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace HelloApi.Tests;

public class ApiEndpointsTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public ApiEndpointsTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task HelloEndpoint_ReturnsExpectedMessage()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/hello");
        var content = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("Hello from suresh", content);
    }

    [Fact]
    public async Task TimeEndpoint_ReturnsISO8601Format()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/time");
        var content = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotEmpty(content);
        
        // Verify it's a valid ISO 8601 datetime
        Assert.True(DateTime.TryParse(content, out var parsedTime));
        
        // Verify the format contains 'T' and 'Z' (ISO 8601 format)
        Assert.Contains("T", content);
        Assert.Contains("Z", content);
    }

    [Fact]
    public async Task TimeEndpoint_ReturnsRecentTime()
    {
        // Arrange
        var client = _factory.CreateClient();
        var beforeRequest = DateTime.UtcNow;

        // Act
        var response = await client.GetAsync("/time");
        var content = await response.Content.ReadAsStringAsync();
        var afterRequest = DateTime.UtcNow;

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        
        var returnedTime = DateTimeOffset.Parse(content).UtcDateTime;
        
        // The returned time should be between before and after the request
        Assert.True(returnedTime >= beforeRequest.AddSeconds(-1));
        Assert.True(returnedTime <= afterRequest.AddSeconds(1));
    }
}
