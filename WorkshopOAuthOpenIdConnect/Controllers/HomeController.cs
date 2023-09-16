using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Diagnostics;
using WorkshopOAuthOpenIdConnect.Models;

namespace WorkshopOAuthOpenIdConnect.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Authentication-related actions
        public IActionResult Login()
        {
                // Retrieve parameters from the form or wherever they are stored
            var clientId = "zia-client";
            var scope = "openid email phone address profile";
            var responseType = "code";
            var redirectUri = "https://localhost:44353";
            var prompt = "login";
            var state = "your-state-value";
            var codeChallengeMethod = "plain";
            var codeChallenge = "your-code-challenge";

            // Construct the authorization URL
            var parameters = new Dictionary<string, string?>
    {
        { "client_id", clientId },
        { "scope", scope },
        { "response_type", responseType },
        { "redirect_uri", redirectUri },
        { "prompt", prompt },
        { "state", state },
        { "code_challenge_method", codeChallengeMethod },
        { "code_challenge", codeChallenge }
    };

            var authorizationUri = QueryHelpers.AddQueryString("http://localhost:8080/realms/master/protocol/openid-connect/auth", parameters);

            // Redirect to the authorization endpoint URL
            return Redirect(authorizationUri);
        }
    }

    }

 