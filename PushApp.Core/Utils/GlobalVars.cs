namespace PushApp.Core.Utils
{
    public class GlobalVars
    {
        public static string UrlApi = "http://apigestiondetareas15.azurewebsites.net/api";
        public static string ServicioMovilUrl = "https://franpush.azure-mobile.net/";
        public static string ServicioMovilKey = "EfJxzclqkyQUQqdanbivlLhkqXJPqX65";

        public const string SenderID = "534017138180"; // Google API Project Number

        // Azure app specific connection string and hub path
        public const string ConnectionString = "Endpoint=sb://franpushhub-ns.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=dGXPuPziKj5jyyTKL88BxCe4G0lqWxqnUsIe+/01Ijk=";
        public const string NotificationHubPath = "franpushhub";
    }
}