// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppSettingsHelper.cs" company="">
//   
// </copyright>
// <summary>
//   The app settings helpers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace API.Common.Helpers.AppSettingsHelpers
{
    /// <summary>
    ///     The app settings helpers.
    /// </summary>
    public class AppSettingsHelper
    {
        #region Public Methods and Operators

        /// <summary>
        /// The get app setting.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="defaultValue">
        /// The default value.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public static T GetAppSetting<T>(string key, T defaultValue)
        {
            return AppSettingsProvider.Current.GetAppSetting(key, defaultValue);
        }

        /// <summary>
        /// The get app setting.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetAppSetting(string key)
        {
            return AppSettingsProvider.Current.GetAppSetting(key);
        }

        #endregion
    }
}