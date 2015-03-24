// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppSettingsProvider.cs" company="">
//   
// </copyright>
// <summary>
//   The app settings provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace API.Common.Helpers.AppSettingsHelpers
{
    using System;

    /// <summary>
    ///     The app settings provider.
    /// </summary>
    public abstract class AppSettingsProvider
    {
        #region Static Fields

        /// <summary>
        ///     The _current.
        /// </summary>
        private static AppSettingsProvider current;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes static members of the <see cref="AppSettingsProvider" /> class.
        /// </summary>
        static AppSettingsProvider()
        {
            current = new DefaultAppSettingsProvider();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the current.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public static AppSettingsProvider Current
        {
            get
            {
                return current;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                current = value;
            }
        }

        #endregion

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
        public abstract T GetAppSetting<T>(string key, T defaultValue);

        /// <summary>
        /// The get app setting.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public abstract string GetAppSetting(string key);

        #endregion
    }
}