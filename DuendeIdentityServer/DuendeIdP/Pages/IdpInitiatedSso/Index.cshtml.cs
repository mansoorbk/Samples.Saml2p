using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rsk.Saml.Services;
using System;

namespace DuendeIdP.Pages.IdpInitiatedSso;

[SecurityHeaders]
[Authorize]
public class Index : PageModel
{
    private readonly ISamlInteractionService samlInteractionService;

    public ViewModel View { get; set; }

    [BindProperty]
    public InputModel Input { get; set; }

    public Index(ISamlInteractionService samlInteractionService)
    {
        this.samlInteractionService = samlInteractionService ?? throw new ArgumentNullException(nameof(samlInteractionService));
    }
    public async Task<IActionResult> OnGet()
    {
        List<Rsk.Saml.Models.ServiceProvider> serviceProviders = (await samlInteractionService.GetIdpInitiatedSsoCompatibleServiceProviders()).ToList();
        View = new ViewModel(serviceProviders);

        return Page();
    }


    public async Task OnPost()
    {
        var ssoResponse = await samlInteractionService.CreateIdpInitiatedSsoResponse(Input.ServiceProviderId);

        await samlInteractionService.ExecuteIdpInitiatedSso(HttpContext, ssoResponse);

    }
}