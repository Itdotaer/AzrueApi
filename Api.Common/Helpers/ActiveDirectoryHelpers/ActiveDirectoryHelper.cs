// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActiveDirectoryHelper.cs" company="">
//   
// </copyright>
// <summary>
//   The active directory helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace API.Common.Helpers.ActiveDirectoryHelpers
{
    using System.Security.Principal;

    using API.Common.Exceptions;
    using System.DirectoryServices;

    /// <summary>
    ///     The active directory helper.
    /// </summary>
    public class ActiveDirectoryHelper
    {
        #region Public Methods and Operators

        /// <summary>
        /// The get email by alias.
        /// </summary>
        /// <param name="alias">
        /// The alias.
        /// </param>
        /// <param name="separator">
        /// The separator.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetEmailByAlias(string alias, char separator = '\\')
        {
            return GetEmailByDomainAndAlias(alias.Split(separator)[0], alias.Split(separator)[1]);
        }

        /// <summary>
        /// The get email by domain and alias.
        /// </summary>
        /// <param name="domainName">
        /// The domain name.
        /// </param>
        /// <param name="alias">
        /// The alias.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="InvalidUserInActiveDirectoryException">
        /// </exception>
        public static string GetEmailByDomainAndAlias(string domainName, string alias)
        {
            var entry = new DirectoryEntry("LDAP://" + domainName);
            var adSearcher = new DirectorySearcher(entry);

            adSearcher.SearchScope = SearchScope.Subtree;
            adSearcher.Filter = "(&(objectClass=user)(samaccountname=" + alias + "))";
            SearchResult userObject = adSearcher.FindOne();
            if (userObject != null)
            {
                string email = userObject.Properties["mail"][0].ToString();
                return email;
            }

            throw new InvalidUserInActiveDirectoryException("Can't find the user in Active Directory!");
        }

        /// <summary>
        /// The get email of current user.
        /// </summary>
        /// <param name="principal">
        /// The principal.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetEmailOfCurrentUser(IPrincipal principal)
        {
            IIdentity id = principal.Identity;
            var winId = id as WindowsIdentity;
            string userInQuestion = winId.Name.Split('\\')[1];
            string myDomain = winId.Name.Split('\\')[0]; // this is the domain that the user is in

            // the account that this program runs in should be authenticated in there                    
            var entry = new DirectoryEntry("LDAP://" + myDomain);
            var adSearcher = new DirectorySearcher(entry);

            adSearcher.SearchScope = SearchScope.Subtree;
            adSearcher.Filter = "(&(objectClass=user)(samaccountname=" + userInQuestion + "))";
            SearchResult userObject = adSearcher.FindOne();
            if (userObject != null)
            {
                string email = userObject.Properties["mail"][0].ToString();
                return email;
            }

            return string.Empty;
        }

        #endregion
    }
}