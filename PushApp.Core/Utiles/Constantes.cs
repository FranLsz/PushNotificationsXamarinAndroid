namespace PushApp.Core.Utiles
{
    public class Constantes
    {
        // URL y key del servicio movil
        public static string MobileServiceUrl = "https://franpush.azure-mobile.net/";
        public static string MobileServiceKey = "EfJxzclqkyQUQqdanbivlLhkqXJPqX65";

        //ID del proyecto de Google API
        public const string SenderId = "534017138180";

        // Connection string y hub path de Azure
        public const string ConnectionString = "Endpoint=sb://franpushhub-ns.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=dGXPuPziKj5jyyTKL88BxCe4G0lqWxqnUsIe+/01Ijk=";
        public const string NotificationHubPath = "franpushhub";
    }
}