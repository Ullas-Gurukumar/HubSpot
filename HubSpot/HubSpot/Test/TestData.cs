using HubSpot.Clients;

namespace HubSpot.Test
{
    public static class TestData
    {
        // Didn't setup First and Last Name since it's not needed for the post request
        public static PartnersAvailiblity GetTestData()
        {
            return new PartnersAvailiblity
            {
                Partners = new List<Partner> 
                {
                    new Partner
                    {
                        Email = "ddaignault@hubspotpartners.com",
                        Country = "United States",
                        AvailableDates = new List<DateTime> { DateTime.Parse("2017-05-03"), DateTime.Parse("2017-05-06") },
                    },
                    new Partner
                    {
                        Email = "cbrenna@hubspotpartners.com",
                        Country = "Ireland",
                        AvailableDates = new List<DateTime> { DateTime.Parse("2017-04-27"), DateTime.Parse("2017-04-29"), DateTime.Parse("2017-04-30")  },
                    },
                    new Partner
                    {
                        Email = "jgustison@hubspotpartners.com",
                        Country = "Spain",
                        AvailableDates = new List<DateTime> { DateTime.Parse("2017-04-29"), DateTime.Parse("2017-04-30"), DateTime.Parse("2017-05-01") },
                    },
                    new Partner
                    {
                        Email = "tmozie@hubspotpartners.com",
                        Country = "Spain",
                        AvailableDates = new List<DateTime> { DateTime.Parse("2017-04-28"), DateTime.Parse("2017-04-29"), DateTime.Parse("2017-05-01"), DateTime.Parse("2017-05-04") },
                    },
                    new Partner
                    {
                        Email = "taffelt@hubspotpartners.com",
                        Country = "Spain",
                        AvailableDates = new List<DateTime> { DateTime.Parse("2017-04-28"), DateTime.Parse("2017-04-29"), DateTime.Parse("2017-05-02"), DateTime.Parse("2017-05-04") },
                    },
                    new Partner
                    {
                        Email = "ryarwood@hubspotpartners.com",
                        Country = "Spain",
                        AvailableDates = new List<DateTime> { DateTime.Parse("2017-04-29"), DateTime.Parse("2017-04-30"), DateTime.Parse("2017-05-02"), DateTime.Parse("2017-05-03") },
                    },
                    new Partner
                    {
                        Email = "sfilipponi@hubspotpartners.com",
                        Country = "Spain",
                        AvailableDates = new List<DateTime> { DateTime.Parse("2017-04-30"), DateTime.Parse("2017-05-01") },
                    },
                    new Partner
                    {
                        Email = "omajica@hubspotpartners.com",
                        Country = "Spain",
                        AvailableDates = new List<DateTime> { DateTime.Parse("2017-04-28"), DateTime.Parse("2017-04-29"), DateTime.Parse("2017-05-01"), DateTime.Parse("2017-05-03") },
                    },
                    new Partner
                    {
                        Email = "wzartman@hubspotpartners.com",
                        Country = "Spain",
                        AvailableDates = new List<DateTime> { DateTime.Parse("2017-04-29"), DateTime.Parse("2017-04-30"), DateTime.Parse("2017-05-02"), DateTime.Parse("2017-05-03") },
                    },
                    new Partner
                    {
                        Email = "eauther@hubspotpartners.com",
                        Country = "United States",
                        AvailableDates = new List<DateTime> { DateTime.Parse("2017-05-04"), DateTime.Parse("2017-05-09") },
                    },
                },
            };
        }
    }
}
