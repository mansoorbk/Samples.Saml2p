// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

namespace DuendeIdP.Pages.IdpInitiatedSso;

public class ViewModel : InputModel
{
    public List<Rsk.Saml.Models.ServiceProvider> IdpInitiatedSsoEnabledProviders { get; set; }

    public ViewModel(List<Rsk.Saml.Models.ServiceProvider> serviceProviders)
    {
        IdpInitiatedSsoEnabledProviders = serviceProviders;
    }
}
