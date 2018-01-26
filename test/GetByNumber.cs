using System.Net.Http;
using System.Threading.Tasks;
using api.dto;
using Newtonsoft.Json;
using Xunit;

namespace tests
{

    public class GetByNumber : ApiControllerTestBase
    {
        private readonly HttpClient _client;

        public GetByNumber()
        {
            _client = base.GetClient();
        }

        [Theory]
        [InlineData("values")]
        public async Task ReturnsTextForTheNumber42(string controllerName)
        {
            var response = await _client.GetAsync($"/api/{controllerName}/42");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResponse>(stringResponse);

            Assert.Equal(42, result.Number);
            Assert.NotEmpty(result.Text);
        }
    }
}