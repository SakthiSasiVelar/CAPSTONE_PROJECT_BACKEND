using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Toy_Store_Management_Backend.DTOs;

namespace Toy_Store_Management_Backend.Controllers
{
    [Route("api")]
    [EnableCors("MyCors")]
    public class PaymentController : ControllerBase
    {
        [HttpPost("create-payment-intent")]
        public async Task<IActionResult> CreatePaymentIntent([FromBody] CreatePaymentIntentRequestDTO request)
        {
            long amountInPaise = request.Amount * 100;
            var options = new PaymentIntentCreateOptions
            {
                Amount = amountInPaise,
                Currency = request.Currency,
                PaymentMethodTypes = new List<string> { "card" },
            };

            var service = new PaymentIntentService();
            PaymentIntent intent = await service.CreateAsync(options);

            return Ok(new { ClientSecret = intent.ClientSecret });
        }
    }
}
