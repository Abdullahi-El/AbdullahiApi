using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace EncryptionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncryptionController : ControllerBase
    {
        private readonly EncryptionService _encryptionService;

        // Inject the EncryptionService via constructor
        public EncryptionController(EncryptionService encryptionService)
        {
            _encryptionService = encryptionService;
        }

        // Endpoint for Caesar cipher encryption
        [HttpPost("caesar/encrypt")]
        public IActionResult CaesarEncrypt([FromBody] EncryptionRequest request)
        {
            if (string.IsNullOrEmpty(request.Text))
                return BadRequest("Text is required.");

            int shift = request.Shift ?? 3; // Default shift of 3
            var encryptedText = _encryptionService.CaesarCipher(request.Text, shift);
            return Ok(new { encryptedText });
        }

        // Endpoint for Caesar cipher decryption
        [HttpPost("caesar/decrypt")]
        public IActionResult CaesarDecrypt([FromBody] EncryptionRequest request)
        {
            if (string.IsNullOrEmpty(request.Text))
                return BadRequest("Text is required.");

            int shift = request.Shift ?? 3; // Default shift of 3
            var decryptedText = _encryptionService.CaesarCipher(request.Text, -shift); // Negative shift for decryption
            return Ok(new { decryptedText });
        }

        // Endpoint for Rövarspråket encryption
        [HttpPost("rovarspraket/encrypt")]
        public IActionResult RovarspraketEncrypt([FromBody] RovarspraketRequest request)
        {
            if (string.IsNullOrEmpty(request.Text))
                return BadRequest("Text is required.");

            var encryptedText = _encryptionService.RovarspraketEncrypt(request.Text);
            return Ok(new { encryptedText });
        }

        // Endpoint for Rövarspråket decryption
        [HttpPost("rovarspraket/decrypt")]
        public IActionResult RovarspraketDecrypt([FromBody] RovarspraketRequest request)
        {
            if (string.IsNullOrEmpty(request.Text))
                return BadRequest("Text is required.");

            var decryptedText = _encryptionService.RovarspraketDecrypt(request.Text);
            return Ok(new { decryptedText });
        }
    }

    // Helper class to handle the request body for Caesar cipher
    public class EncryptionRequest
    {
        public string Text { get; set; } = string.Empty; // Initialize with an empty string
        public int? Shift { get; set; }
    }

    // Helper class to handle the request body for Rövarspråket
    public class RovarspraketRequest
    {
        public string Text { get; set; } = string.Empty; // Initialize with an empty string
    }
}