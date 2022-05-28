using HubSpot.ApplicationService;
using Microsoft.AspNetCore.Mvc;

namespace HubSpot.Controllers
{
    [ApiController]
    [Route("/HubSpot")]
    public class HubSpotController : Controller
    {
        private HubSpotService hubSpotService;
        public HubSpotController()
        {
            hubSpotService = new HubSpotService();
        }

        // Used this for quick debugging
        [HttpGet]
        public async Task<IActionResult> GetPartnersAvailability()
        {
            var partnersAvailability = await hubSpotService.PartnersAvailability();

            if (partnersAvailability == null)
            {
                return NoContent();
            }
            return Ok(partnersAvailability);
        }

        [HttpGet("/HubSpot/SendResult")]
        public async Task<IActionResult> SendAttendeeResult()
        {
            var partnersAvailability = await hubSpotService.SendResult();
            return Ok(partnersAvailability);
        }

        // Used a endpoint to quickly validate the test data provided 
        [HttpGet("/test")]
        public IActionResult GetTestPartnersAvailability()
        {
            var partnersAvailability = hubSpotService.Test();

            if (partnersAvailability == null)
            {
                return NoContent();
            }
            return Ok(partnersAvailability);
        }
    }
}
