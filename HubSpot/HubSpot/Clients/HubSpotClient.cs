using HubSpot.DataApi;

namespace HubSpot.Clients
{
    public class HubSpotClient
    {
        private readonly HttpClient client;
        private readonly string baseURL = "https://candidate.hubteam.com";
        private readonly string userKey = "bd09dae593a33b03e492395ab694";

        public HubSpotClient()
        {
            client = new HttpClient();
        }

        public async Task<PartnersAvailiblity?> GetPartnersAvailability()
        {
            try
            {
                var partnersAvailiblity = await client.GetFromJsonAsync<PartnersAvailiblity>($"{baseURL}/candidateTest/v3/problem/dataset?userKey={userKey}");

                return partnersAvailiblity;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<int> PostAttendeeResult(Attendees result)
        {
            try
            {
                var partnersAvailiblity = await client.PostAsJsonAsync($"{baseURL}/candidateTest/v3/problem/result?userKey={userKey}", result);

                return (int) partnersAvailiblity.StatusCode;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
    }

    public class PartnersAvailiblity
    {
        public List<Partner> Partners { get; set; } 
    }

    public class Partner
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public List<DateTime> AvailableDates { get; set; }
    }
}
