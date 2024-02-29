// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

using Duende.IdentityServer.Models;
using System.ComponentModel.DataAnnotations;

namespace DuendeIdP.Pages.IdpInitiatedSso;

public class InputModel
{
    [Required]
    public string ServiceProviderId { get; set; }
}