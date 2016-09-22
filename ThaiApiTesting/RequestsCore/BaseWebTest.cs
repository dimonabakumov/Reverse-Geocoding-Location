using Microsoft.VisualStudio.TestTools.WebTesting;

namespace ThaiApiTesting.RequestsCore
{
    public abstract class BaseWebTest : WebTest
    {
        protected Requests requests;
        public BaseWebTest()
        {
            requests = new Requests();
        }
    }
}
