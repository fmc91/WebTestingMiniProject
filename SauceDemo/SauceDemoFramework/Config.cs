using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace SauceDemoFramework
{
    public class Config
    {
        private static Config _config;

        public string HomePageUrl { get; }

        public string InventoryPageUrl { get; }

        public string CartPageUrl { get; }

        public string CheckoutStepOneUrl { get; }

        public string CheckoutStepTwoUrl { get; }

        private Config()
        {
            JObject config = JObject.Parse(File.ReadAllText("config.json"));

            HomePageUrl = config["home-page-url"].ToString();
            InventoryPageUrl = config["inventory-page-url"].ToString();
            CartPageUrl = config["cart-page-url"].ToString();
            CheckoutStepOneUrl = config["checkout-step-one-url"].ToString();
            CheckoutStepTwoUrl = config["checkout-step-two-url"].ToString();
        }

        public static Config GetConfig()
        {
            if (_config == null)
                _config = new Config();
                
            return _config;
        }
    }
}
