namespace HubSpot.DataApi
{
    public class Attendees
    {
        public List<AttendeesByCountry> Countries { get; set; }
    }

    public class AttendeesByCountry
    {
        public int AttendeeCount { get; set; }
        public List<string> Attendees { get; set; }
        public string name { get; set; }
        // In prod, I would use DateTime object and use AutoMapper to convert it to  post body object that serializes to "YYYY-MM-DD"
        public string? StartDate { get; set; }
    }
}
