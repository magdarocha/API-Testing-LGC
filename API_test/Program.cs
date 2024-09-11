// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System.Net;
using System.Text.Json;
using FluentAssertions;
using RestSharp;
using NUnit.Framework;

using static DataApiEntities;

[TestFixture]
public class ChallengeApiTests
{
    String baseUrl = "https://jsonplaceholder.typicode.com/";

    [Test]
    public void TestGETRequest()
    {
        Console.WriteLine("Test GET Request");

        String getUrl = baseUrl + "/posts/1";

        RestClient client = new RestClient(getUrl);
        RestRequest restRequest = new RestRequest(getUrl, Method.Get);
        RestResponse restResponse = client.Execute(restRequest);
        
        // Verify the response status code is 200
        restResponse.Should().NotBeNull();
        restResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        // Verify the response body contains the expected post data
        var bodyContent = JsonSerializer.Deserialize<DataApiEntities>(restResponse.Content);
        bodyContent.Id.Should().Be(1);
        bodyContent.Title.Should().NotBeEmpty();
        bodyContent.Body.Should().NotBeEmpty();
        bodyContent.UserId.Should().Be(1);
    }

    static void Main(string[] args)
    {
        ChallengeApiTests test = new ChallengeApiTests();

        // Run test 1
        test.TestGETRequest();
    }
}
