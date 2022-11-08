using DI.Interfaces.Tests.Integrations.Interfaces;
using DI.Interfaces.Tests.Integrations.Models;
using DI.Interfaces.Tests.Models;
using DI.Interfaces.Tests.ViewModels;

namespace DI.Interfaces.Tests.Integrations.Managers
{

    /// <summary>
    /// Scoped Service (Always the same during the request)
    /// Cant Hold sensitive data like Auth because if i had multiple Amazon Accounts cant be mixed
    /// </summary>
    public class AmazonManager : IIntegrationManager<AmazonAuth, AmazonProduct>
    {
        public AmazonProduct CreatePublication(AmazonAuth auth, Publication product)
        {
            AmazonProduct response = Amazon_RequestThatReturnConcretePublication(auth, product);
            return response;
        }

        public AmazonProduct CreatePublicationAndDoSomethingElseForAllSalesChannels(AmazonAuth auth, Publication publication)
        {
            var createdAmazonPublication = CreatePublication(auth, publication);
            createdAmazonPublication.CustomAmazonProperty = "";
            var updatedAmazonPublication = Other_Amazon_MethodThatRequiresCustomProperty(auth, createdAmazonPublication);
            return updatedAmazonPublication;
        }

        public AmazonAuth GetAuth(SalesChannel salesChanel)
        {
            return new AmazonAuth() { Password = salesChanel.Id.ToString(), UserName = salesChanel.Name }; // <<<<< Dont panic!!! Just for the Example
        }

        public Task<AmazonProduct> GetPublication(AmazonAuth auth, string identifier)
        {
            throw new NotImplementedException();
        }

        public Task<PublicationRequest> ToPublicationRequest(AmazonProduct publication)
        {
            throw new NotImplementedException();
        }


        private AmazonProduct Amazon_RequestThatReturnConcretePublication(AmazonAuth auth, Publication publication)
        {
            return new AmazonProduct();
        }

        private AmazonProduct Other_Amazon_MethodThatRequiresCustomProperty(AmazonAuth auth, AmazonProduct createdAmazonPublication)
        {
            createdAmazonPublication.CustomAmazonProperty = "xxxxx";
            return createdAmazonPublication;
        }
    }
}
