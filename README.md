# HubSpot

## Approach

- Getting partner availabilities from the get endpoint
- Grouping the list of partners based on Country property
- Determining start dates for all partners
- Mapping each country's partners to partners based on start date (Country -> StartDate -> Attendees)
- Picking the start date where most partners are able to come
- Mapping this object structure to request body structure.

## Note

- Based on the list of `availableDates`, the dates were in sorted order, I did rely in this fact. Assuming data coming from the service ensures `availableDates` is in sorted order
- I had to reverse the attendee order for the request body, figured this out after testing with test data provided. Unsure if this is supposed to be alphabetical order since the question didn't mention any specific requirement
