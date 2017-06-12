using System.Collections;
using System.Web;

namespace PDL.Synthetical.Common
{
    /// <summary>
    /// 缓存操作类
    /// </summary>
    public class CacheHelper
    {
        /// <summary>
        /// 获取当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <returns></returns>
        public static object GetCache(string CacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            return objCache[CacheKey];
        }

        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <param name="objObject"></param>
        public static void SetCache(string CacheKey, object objObject)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject);
        }

        public static object RemoveCache(string CacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            return objCache.Remove(CacheKey);
        }

        /// <summary>
        /// 移除指定条件的key值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <returns></returns>
        public static void RemoveCacheByWhere(string CacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            IDictionaryEnumerator CacheEnum = objCache.GetEnumerator();
            while (CacheEnum.MoveNext())
            {
                if (CacheEnum.Key.ToString().Contains(CacheKey))
                {
                    objCache.Remove(CacheEnum.Key.ToString());
                }
            }
        }
    }
}
