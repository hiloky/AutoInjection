using Common;
using IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TestService : BaseService, ITestService
    {
        public TestService()
        {

        }

        public Task<string> GetTest()
        {
            return Task.FromResult("Test");
        }
    }
}
