/* global using for System namespaces here */

global using System.Net;
global using System.Net.Http.Json;

global using System.Text;
global using System.Text.Json;

/* global using for Microsoft namespaces here */

global using Microsoft.AspNetCore.Mvc.Testing;
global using Microsoft.Extensions.DependencyInjection;

/* global using for Vinder namespaces here */

global using Vinder.Comanda.Payments.WebApi;

global using Vinder.Comanda.Payments.Domain.Repositories;
global using Vinder.Comanda.Payments.Domain.Entities;
global using Vinder.Comanda.Payments.Domain.Concepts;
global using Vinder.Comanda.Payments.Domain.Filtering;

global using Vinder.Comanda.Payments.Application.Payloads;

global using Vinder.Internal.Essentials.Patterns;
global using Vinder.Internal.Essentials.Utilities;

/* global usings for third-party namespaces here */

global using MongoDB.Driver;
global using DotNet.Testcontainers.Builders;
global using DotNet.Testcontainers.Containers;
global using AutoFixture;