﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Response
    {
        /// <summary>
        /// Msg
        /// </summary>
        public string Msg { get; set; } = string.Empty;

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success => string.IsNullOrEmpty(Msg);

        /// <summary>
        /// 时间戳
        /// </summary>
        public DateTime Timestamp { get; set; } = DateTime.Now;

        /// <summary>
        /// HandleException
        /// </summary>
        /// <param name="ex"></param>
        public void HandleException(Exception ex) => Msg = ex.InnerException?.StackTrace.ToString();
    }

    public class Response<TResult> : Response where TResult : class
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public TResult Result { get; set; }

        /// <summary>
        /// 消息，默认为null
        /// </summary>
        public string Message { get; set; }
    }
}
