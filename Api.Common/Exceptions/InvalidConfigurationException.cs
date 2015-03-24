// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidConfigurationException.cs" company="">
//   
// </copyright>
// <summary>
//   The invalid configuration exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace API.Common.Exceptions
{
    using System;

    /// <summary>
    /// The invalid configuration exception.
    /// </summary>
    [Serializable]
    public class InvalidConfigurationException : Exception
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidConfigurationException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public InvalidConfigurationException(string message)
            : base(message)
        {
        }

        #endregion
    }
}