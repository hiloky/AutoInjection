using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class BaseService : IBaseService
    {
        public BaseService()
        {

        }
        public Task<string> GetB()
        {
            return Task.FromResult("GetB");
        }
    }
}
