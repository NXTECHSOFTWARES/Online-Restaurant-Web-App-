using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewProject
{
    public class PaypalConfiguration
    {
        public readonly static string clientId;
        public readonly static string clientSecret;


        static PaypalConfiguration()
        {
            var config = getconfig();
            clientId = "AbNh02Yci48a4eho1wdKgX6cnBBlFT0aZhsFjuwmchOuB55FFXyJjpXDcxVNktIY_Esfh_iCtWkXsDDX";
            clientSecret = "EBWczRX-2B7KnE2lJqNwvDtg2pOQqwG-RW-R4szKyQUg0jvUCRYQPeVYFZHmuMqoHHjKuhPeiXuZf87f";
        }

        private static Dictionary<string, string> getconfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }

        private static string GetAccessToken()
        {
            string accessToken = new OAuthTokenCredential(clientId, clientSecret, getconfig()).GetAccessToken();
            return accessToken;
        }
        public static APIContext GetAPIContext()
        {
            APIContext apicontext = new APIContext(GetAccessToken());
            apicontext.Config = getconfig();
            return apicontext;
        }
    }
}