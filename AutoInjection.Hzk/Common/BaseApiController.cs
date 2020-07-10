using Microsoft.AspNetCore.Mvc;
using Entity;
using Microsoft.AspNetCore.Http;

namespace AutoInjection.Hzk.Common
{
	/// <summary>
	/// Description：Api控制器基类
	/// Created by: 胡知康
	/// Creation Date: 2020/5/5
	/// </summary>
	public class BaseApiController : ControllerBase
	{
		/// <summary>
		/// JWT使用
		/// </summary>
		private static readonly HttpContextAccessor _httpContextAccessor = new HttpContextAccessor();

		#region IActionResult 类型大全 
		//ContentResult 返回一串字符串
		//FileContentResult 返回文件内容
		//FilePathResult 返回路径文件的内容
		//EmptyResult 返回空值
		//JavaScriptResult 返回一段JavaScript代码
		//JsonResult 返回Json格式数据
		//RedirectToResult 重定向到其他URL
		//HttpUnauthorizedResult 返回HTTP403未授权状态码
		//RedirectToRouteResult 重定向到不同的控制器动作
		//ViewResult 接收视图引擎的响应
		//PartialViewResult 接收分部视图引擎的响应
		#endregion

		/// <summary>
		/// 成功返回数据
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		protected virtual IActionResult Success(object data)
		{
			return new JsonResult(new Response<object>()
			{
				Result = data
			});
		}

		/// <summary>
		/// 成功
		/// </summary>
		/// <param name="message">消息</param>
		/// <param name="data">数据</param>
		/// <returns></returns>
		protected virtual IActionResult Success(string message, object data)
		{
			return new JsonResult(new Response<object>()
			{
				Message = message,
				Result = data
			});
		}

		/// <summary>
		/// 错误
		/// </summary>
		/// <param name="message">消息</param>
		/// <returns></returns>
		protected virtual IActionResult Error(string message)
		{
			return new JsonResult(new Response()
			{
				Msg = message
			});
		}

		/// <summary>
		/// 错误
		/// </summary>
		/// <param name="data">数据</param>
		/// <returns></returns>
		protected virtual IActionResult Error(object data)
		{
			var response = new Response<object>()
			{
				Result = data
			};
			response.Msg = "操作失败";

			return new JsonResult(response);
		}

		/// <summary>
		/// 错误
		/// </summary>
		/// <param name="message">消息</param>
		/// <param name="data">数据</param>
		/// <returns></returns>
		protected virtual IActionResult Error(string message, object data)
		{
			var response = new Response<object>()
			{
				Message = message,
				Result = data
			};
			response.Msg = "操作失败";

			return new JsonResult(response);
		}

	}
}
