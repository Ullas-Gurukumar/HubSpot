using HubSpot.Clients;
using HubSpot.DataApi;
using HubSpot.Test;


namespace HubSpot.ApplicationService
{
    public class HubSpotService
    {
        private HubSpotClient hubSpotClient;
        public HubSpotService()
        {
            hubSpotClient = new HubSpotClient();
        }

        public async Task<Attendees> PartnersAvailability()
        {
            var partnersAvailability = await hubSpotClient.GetPartnersAvailability();

            return FindInvitationDetails(partnersAvailability);
        }

        public Attendees Test()
        {
            return FindInvitationDetails(TestData.GetTestData());
        }

        public async Task<int> SendResult()
        {
            var result = await PartnersAvailability();

            return await hubSpotClient.PostAttendeeResult(result);
        }

        private Attendees FindInvitationDetails(PartnersAvailiblity availiblity)
        {
            var partnersByCountry = availiblity.Partners.GroupBy(partner => partner.Country)
                .Select(group => new PartnerGrouping { Country = group.Key, Partners = ToPartnerResources(group.ToList()) });

            return new Attendees
            {
                Countries = partnersByCountry.Select(partnersGroup => ToAttendeesByCountry(partnersGroup)).ToList(),
            };
        }

        private AttendeesByCountry ToAttendeesByCountry(PartnerGrouping groupedPartner)
        {
            var result = new AttendeesByCountry
            {
                AttendeeCount = 0,
                Attendees = new List<string>(),
                name = groupedPartner.Country,
                StartDate = null,
            };

            var map = new Dictionary<DateTime, List<PartnerResource>>();
            
            // keeping track of the earliest start date and highest attendees to update result
            DateTime earliestStart = DateTime.MaxValue;
            var highestAttendees = 0;

            groupedPartner.Partners.ForEach(partner =>
            {
                partner.StartDates.ForEach(startDate => 
                {
                    if (map.TryGetValue(startDate, out var partners))
                    {
                        partners.Add(partner);
                        if (partners.Count > highestAttendees || (partners.Count == highestAttendees && DateTime.Compare(earliestStart,startDate) > 0))
                        {
                            highestAttendees = partners.Count;
                            earliestStart = startDate;
                        }
                    } else
                    {
                        map.Add(startDate, new List<PartnerResource> { partner});

                        if (highestAttendees == 0 || (highestAttendees == 1 && DateTime.Compare(earliestStart, startDate) > 0))
                        {
                            highestAttendees = 1;
                            earliestStart = startDate;
                        }
                    }
                });
            });
            
            if (highestAttendees != 0)
            {
                result.AttendeeCount = highestAttendees;
                result.StartDate = earliestStart.ToString("yyyy-MM-dd");
                map.TryGetValue(earliestStart, out var partners);
                var partnerEmails = partners.Select(partners => partners.Email);
                result.Attendees = partnerEmails.ToList();
            }

            // The attendee list order had no requirement in terms of order.
            // Added this after realizing order mattered based on test data and test result provided.
            result.Attendees.Reverse();

            return result;
        }

        private List<PartnerResource> ToPartnerResources(List<Partner> partners)
        {
            return partners.Select(partner => new PartnerResource
            {
                FirstName = partner.FirstName,
                LastName = partner.LastName,
                Email = partner.Email,
                Country = partner.Country,
                AvailableDates = partner.AvailableDates,
                StartDates = GetPartnerStartDates(partner.AvailableDates),
            }).ToList();
        }
        private List<DateTime> GetPartnerStartDates(List<DateTime> avalibility)
        {
            List<DateTime> startDates = new List<DateTime>();

            // Only iterating to count - 1 since I'm figuring out start dates for 2 day event
            for (int i = 0; i < avalibility.Count - 1; i++)
            {
                var date = avalibility[i];
                var nextDay = date.AddDays(1);
                // Relying on the fact that dates were in sorted order.
                if (DateTime.Compare(nextDay, avalibility[i + 1]) == 0)
                {
                    startDates.Add(date);
                }
            }
            return startDates;
        }
    }

    public class PartnerGrouping
    {
        public string Country { get; set; }
        public List<PartnerResource> Partners { get; set; }
    }

    public class PartnerResource
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public List<DateTime> AvailableDates { get; set; }
        public List<DateTime> StartDates { get; set; }
    }
}
