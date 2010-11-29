using System.ServiceModel;

public interface ICatalogServiceClient : ICatalogService, ICommunicationObject
{
}

public class CatalogServiceClientProxy : CatalogServiceClient, ICatalogServiceClient
{
}

public interface ICatalogServiceClientFactory
{
    ICatalogServiceClient BuildCatalogServiceClient();
}

public class CatalogServiceClientFactory : ICatalogServiceClientFactory
{
    public ICatalogServiceClient BuildCatalogServiceClient()
    {
        return new CatalogServiceClientProxy();
    }
}