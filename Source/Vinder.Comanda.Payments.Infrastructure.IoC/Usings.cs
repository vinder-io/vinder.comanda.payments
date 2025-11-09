global using System.Diagnostics.CodeAnalysis;

global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;

global using Vinder.Comanda.Payments.Domain.Repositories;
global using Vinder.Comanda.Payments.Domain.Concepts;

global using Vinder.Comanda.Payments.CrossCutting.Configurations;
global using Vinder.Comanda.Payments.CrossCutting.Exceptions;

global using Vinder.Comanda.Payments.Application.Handlers.Payment;
global using Vinder.Comanda.Payments.Application.Gateways;
global using Vinder.Comanda.Payments.Application.Payloads.Payment;
global using Vinder.Comanda.Payments.Application.Validators;

global using Vinder.Comanda.Payments.Infrastructure.Gateways;
global using Vinder.Comanda.Payments.Infrastructure.Repositories;

global using Vinder.Internal.Essentials.Contracts;
global using Vinder.Internal.Infrastructure.Persistence.Repositories;

global using Vinder.Dispatcher.Extensions;

global using MongoDB.Driver;
global using FluentValidation;
