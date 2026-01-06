global using System.Diagnostics.CodeAnalysis;
global using System.Net.Http.Headers;

global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Authorization;

global using Vinder.Comanda.Payments.WebApi.Constants;
global using Vinder.Comanda.Payments.WebApi.Interceptors;
global using Vinder.Comanda.Payments.WebApi.Extensions;
global using Vinder.Comanda.Payments.Domain.Errors;

global using Vinder.Comanda.Payments.Application.Payloads.Traceability;
global using Vinder.Comanda.Payments.Application.Payloads.Payment;
global using Vinder.Comanda.Payments.Application.Payloads.Events.Billing;

global using Vinder.Comanda.Payments.Infrastructure.IoC.Extensions;
global using Vinder.Comanda.Payments.CrossCutting.Configurations;

global using Vinder.Comanda.Internal.Contracts.Clients;
global using Vinder.Comanda.Internal.Contracts.Clients.Interfaces;

global using Vinder.Dispatcher.Contracts;
global using Vinder.IdentityProvider.Sdk.Extensions;

global using Scalar.AspNetCore;
global using FluentValidation.AspNetCore;