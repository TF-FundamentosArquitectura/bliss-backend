﻿namespace NRG3.Bliss.API.IAM.Interfaces.REST.Resources;

public record SignInResource(
    string Email,
    string Password
    );