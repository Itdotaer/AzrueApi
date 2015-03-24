// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BlobPortalConfig.cs" company="">
//   
// </copyright>
// <summary>
//   The instant answer portal config.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace API.Common.Configs
{
    using API.Common.Helpers.AppSettingsHelpers;

    /// <summary>
    /// The blob portal config.
    /// </summary>
    public static class BlobPortalConfig
    {
        public static string BlobSiteUrl
        {
            get { return AppSettingsHelper.GetAppSetting("BlobSiteUrl", "http://eco-azurewebsite.chinacloudsites.cn/"); }
        }

        public static string SmtpHost
        {
            get { return AppSettingsHelper.GetAppSetting("SmtpHost", "SMTPHOST"); }
        }

        public static string MailFrom
        {
            get { return AppSettingsHelper.GetAppSetting("MailFrom", "v-hary@microsoft.com"); }
        }

        public static string AzureStorageConnectionString
        {
            get { return AppSettingsHelper.GetAppSetting("AzureStorageConnectionString", ""); }
        }

        public static string AzureStorageAccount
        {
            get { return AppSettingsHelper.GetAppSetting("AzureStorageAccount", "azureblobs"); }
        }
    }
}