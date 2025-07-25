﻿namespace Homify.WebApi.Controllers.Companies.Models.Requests;

public sealed record class CreateCompanyRequest
{
    public string? Name { get; init; }
    public string? LogoUrl { get; init; }
    public string? Rut { get; init; }
    public string? Validator { get; init; }
}
