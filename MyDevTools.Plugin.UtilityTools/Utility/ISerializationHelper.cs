using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDevTools.Plugin.UtilityTools.Utility
{
    /// <summary>
    /// 序列化帮组类接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISerializationHelper<T> 
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        String Serialization(T t);
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        T Deserialization(String message);
    }
}
