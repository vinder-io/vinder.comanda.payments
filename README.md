# Vinder Comanda Payments Module

<p align="center">
  <img src="https://i.imgur.com/MmamZlQ.png" alt="vinder.logo" />
</p>

<h1 align="center">COMANDA PAYMENTS MODULE</h1>

This module is responsible for payment processing within the Comanda ecosystem. It handles both online and offline payment transactions, integrating with [AbacatePay](https://docs.abacatepay.com/pages/introduction) for PIX payments. The module operates in a **multi-tenant architecture**, processing payments on behalf of establishments using their own credentials, rather than processing in Comanda's name.

## How to run the system

To start the payment module and all required infrastructure, run the following command in the root of the repository:

```bash
docker-compose up -d
```

This will launch all necessary services, including:
- MongoDB database for payment persistence
- The Vinder Identity Provider (see: [vinder.identity.provider](https://github.com/vinder-io/vinder.identity.provider))
- Integration with AbacatePay payment gateway

After the infrastructure is up, you can start the Payments API by running it from the `Vinder.Comanda.Payments.WebApi` project using your preferred .NET tool or IDE.

### Environment Configuration

Before starting, make sure to create your own `.env` file in the project root, based on the provided `.env.example`, and fill in the real values for your environment.