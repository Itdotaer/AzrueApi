namespace API.Common.Helpers.AppSettingsHelpers
{
    using System;
    using System.Configuration;

    using API.Common.Exceptions;

    public class DefaultAppSettingsProvider : AppSettingsProvider
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Reads app setting from config file; if not found, returns
        ///     <param name="defaultValue"></param>
        ///     .
        /// </summary>
        public override T GetAppSetting<T>(string key, T defaultValue)
        {
            string value = ConfigurationManager.AppSettings[key];
            if (value == null)
            {
                return defaultValue;
            }
            return (T)Convert.ChangeType(value, typeof(T));
        }

        /// <summary>
        ///     Reads specified appSetting, throws InvalidConfigurationException if not found.
        /// </summary>
        public override string GetAppSetting(string key)
        {
            string value = ConfigurationManager.AppSettings[key];
            if (value == null)
            {
                throw new InvalidConfigurationException("Unable to find appSetting " + key);
            }
            return value;
        }

        #endregion
    }
}