using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IService;
using AutoInjection.Hzk.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutoInjection.Hzk.Controllers
{
    /// <summary>
    /// 测试控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : BaseApiController
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        /// <summary>
        /// ceshi
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetTest()
        {
            var result = await _testService.GetTest();
            return Success(result);
        }
    }
}
