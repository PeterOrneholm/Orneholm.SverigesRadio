using Orneholm.SverigesRadio.Api.Models.Request;

namespace Orneholm.SverigesRadio.Api.Test.SverigesRadioApiClient
{
    public abstract class TestsBase
    {
        protected readonly ListPagination FirstThreeItemsPagination = ListPagination.WithPageAndSize(1, 3);
        protected readonly Api.SverigesRadioApiClient ApiClient;

        protected TestsBase()
        {
            ApiClient = Api.SverigesRadioApiClient.CreateClient();
        }
    }
}
