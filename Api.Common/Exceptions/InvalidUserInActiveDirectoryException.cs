// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidUserInActiveDirectoryException.cs" company="">
//   
// </copyright>
// <summary>
//   The invalid user in active directory exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace API.Common.Exceptions
{
    using System;

    /// <summary>
    /// The invalid user in active directory exception.
    /// </summary>
    public class InvalidUserInActiveDirectoryException : Exception
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidUserInActiveDirectoryException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public InvalidUserInActiveDirectoryException(string message)
            : base(message)
        {
        }

        #endregion
    }
}