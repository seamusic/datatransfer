﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Daan.DataTransfer.Utility
{
    /// <summary>
    /// 配置文件appSettings节点的帮助方法
    /// 使用方法：
    /// AppSettingsHelper.GetInt32("PageSize", 30);
    /// AppSettingsHelper.LoadAppSetting("PageSize", 30);
    /// </summary>
    public static class AppSettingsHelper
    {
        private static readonly NameValueCollection appSettings;

        static AppSettingsHelper()
        {
            appSettings = System.Configuration.ConfigurationManager.AppSettings; ;
        }

        #region GetString

        /// <summary>
        /// 获取配置文件中appSettings节点下指定索引键的字符串类型的的值
        /// </summary>
        /// <param name="key">索引键</param>
        /// <returns>字符串</returns>
        public static string GetString(string key)
        {
            return getValue(key, true, null);
        }

        /// <summary>
        /// 获取配置文件中appSettings节点下指定索引键的字符串类型的的值
        /// </summary>
        /// <param name="key">索引键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>字符串</returns>
        public static string GetString(string key, string defaultValue)
        {
            return getValue(key, false, defaultValue);
        }

        #endregion

        #region GetStringArray

        /// <summary>
        /// 获取配置文件中appSettings节点下指定索引键的string[]类型的的值
        /// </summary>
        /// <param name="key">索引键</param>
        /// <param name="separator">分隔符</param>
        /// <returns>字符串数组</returns>
        public static string[] GetStringArray(string key, string separator)
        {
            return getStringArray(key, separator, true, null);
        }

        /// <summary>
        /// 获取配置文件中appSettings节点下指定索引键的string[]类型的的值
        /// </summary>
        /// <param name="key">索引键</param>
        /// <param name="separator">分隔符</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>字符串数组</returns>
        public static string[] GetStringArray(string key, string separator, string[] defaultValue)
        {
            return getStringArray(key, separator, false, defaultValue);
        }

        /// <summary>
        /// 获取配置文件中appSettings节点下指定索引键的string[]类型的的值
        /// </summary>
        /// <param name="key">索引键</param>
        /// <param name="separator">分隔符</param>
        /// <param name="valueRequired">指定配置文件中是否必须需要配置有该名称的元素，传入False则方法返回默认值，反之抛出异常</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>字符串数组</returns>
        private static string[] getStringArray(string key, string separator, bool valueRequired, string[] defaultValue)
        {
            string value = getValue(key, valueRequired, null);

            if (!string.IsNullOrEmpty(value))
                return value.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            else if (!valueRequired)
                return defaultValue;

            throw new ApplicationException("在配置文件的appSettings节点集合中找不到key为" + key + "的子节点，且没有指定默认值");
        }

        #endregion

        #region GetBoolean

        /// <summary>
        /// 获取配置文件中appSettings节点下指定索引键的布尔类型的的值
        /// </summary>
        /// <param name="key">索引键</param>
        /// <returns>布尔值</returns>
        public static bool GetBoolean(string key)
        {
            return getBoolean(key, null);
        }

        /// <summary>
        /// 获取配置文件中appSettings节点下指定索引键的布尔类型的的值
        /// </summary>
        /// <param name="key">索引键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>布尔值</returns>
        public static bool GetBoolean(string key, bool defaultValue)
        {
            return getBoolean(key, defaultValue);
        }

        /// <summary>
        /// 获取配置文件中appSettings节点下指定索引键的布尔类型的的值
        /// </summary>
        /// <param name="key">索引键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>布尔值</returns>
        private static bool getBoolean(string key, bool? defaultValue)
        {
            return getValue<bool>(key, (string v, out bool pv) => bool.TryParse(v, out pv), defaultValue);
        }

        #endregion

        #region GetTimeSpan

        /// <summary>
        /// 获取配置文件中appSettings节点下指定索引键的时间间隔类型的的值
        /// </summary>
        /// <param name="key">索引键</param>
        /// <returns>时间间隔</returns>
        public static TimeSpan GetTimeSpan(string key)
        {
            return TimeSpan.Parse(getValue(key, true, null));
        }

        /// <summary>
        /// 获取配置文件中appSettings节点下指定索引键的时间间隔类型的的值
        /// </summary>
        /// <param name="key">索引键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>时间间隔</returns>
        public static TimeSpan GetTimeSpan(string key, TimeSpan defaultValue)
        {
            string val = getValue(key, false, null);

            if (val == null)
                return defaultValue;

            return TimeSpan.Parse(val);
        }

        #endregion

        #region GetInt32

        /// <summary>
        /// 获取配置文件中appSettings节点下指定索引键的Int类型的的值
        /// </summary>
        /// <param name="key">索引键</param>
        /// <returns>Int</returns>
        public static int GetInt32(string key)
        {
            return getInt32(key, null);
        }

        /// <summary>
        /// 获取配置文件中appSettings节点下指定索引键的Int类型的的值
        /// </summary>
        /// <param name="key">索引键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>Int</returns>
        public static int GetInt32(string key, int defaultValue)
        {
            return getInt32(key, defaultValue);
        }

        /// <summary>
        /// 获取配置文件中appSettings节点下指定索引键的Int类型的的值
        /// </summary>
        /// <param name="key">索引键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>Int</returns>
        private static int getInt32(string key, int? defaultValue)
        {
            return getValue<int>(key, (string v, out int pv) => int.TryParse(v, out pv), defaultValue);
        }

        #endregion

        #region Private Methods
        delegate bool ParseFunc<T, S>(T T1, out S S1);
        /// <summary>
        /// 获取配置文件appSettings集合中指定索引的值
        /// </summary>
        /// <typeparam name="T">返回值类型参数</typeparam>
        /// <param name="key">索引键</param>
        /// <param name="parseValue">将指定索引键的值转化为返回类型的值的委托方法</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        private static T getValue<T>(string key, ParseFunc<string, T> parseValue, T? defaultValue) where T : struct
        {
            string value = appSettings[key];

            if (value != null)
            {
                T parsedValue = default(T);

                if (parseValue(value, out parsedValue))
                    return parsedValue;
                else
                    throw new ApplicationException(string.Format("Settings '{0}' was not a valid {1}", key, typeof(T).FullName));

            }

            if (!defaultValue.HasValue)
                throw new ApplicationException("在配置文件的appSettings节点集合中找不到key为" + key + "的子节点，且没有指定默认值");
            else
                return defaultValue.Value;
        }

        /// <summary>
        /// 获取配置文件appSettings集合中指定索引的值
        /// </summary>
        /// <param name="key">索引</param>
        /// <param name="valueRequired">指定配置文件中是否必须需要配置有该名称的元素，传入False则方法返回默认值，反之抛出异常</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>字符串</returns>
        private static string getValue(string key, bool valueRequired, string defaultValue)
        {
            string value = appSettings[key];

            if (value != null)
                return value;
            else if (!valueRequired)
                return defaultValue;

            throw new ApplicationException("在配置文件的appSettings节点集合中找不到key为" + key + "的子节点");
        }
        #endregion

        /// <summary>
        /// 获取Appsetting
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T LoadAppSetting<T>(string name, T defaultValue)
        {
            var reader = new AppSettingsReader();

            try
            {
                return (T)reader.GetValue(name, typeof(T));
            }
            catch (Exception ex)
            {
                return defaultValue;
            }
        }
    }
}
