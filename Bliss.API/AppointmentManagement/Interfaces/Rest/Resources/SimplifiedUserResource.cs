﻿namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;

//TODO: move this resource and related assemblers to the shared context (Astonitas)
//TODO: remove DNI
/// <summary>
/// Simplified Resource for a user
/// </summary>
/// <param name="Id">
/// The unique identifier of the user
/// </param>
/// <param name="FirstName">
/// The first name of the user
/// </param>
/// <param name="LastName">
/// The last name of the user
/// </param>
/// <param name="Dni">
/// The dni of the user
/// </param>
public record SimplifiedUserResource( int Id, string FirstName, string LastName, string Dni);