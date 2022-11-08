# DI.Interfaces.Tests

Hello, im working on an Ecommerce integration platform and im looking tho achieve the best practices.

Scoped Services (Always the same instance during the request)

1. AmazonManager : ISalesChannel 
2. ShopifyManager : ISalesChannel
3. IntegrationsManager : ISalesChannelWrapper (Created to wrap ISalesChannels and hide things like Auth and decide wich service to use)

These 3 services are configured as Scoped and will be injected in the controllers via Constructor so it will be allways the same instance during the request (cant hold sensitive data cause like Auth cause if user had multiple accounts bad things can happen)
