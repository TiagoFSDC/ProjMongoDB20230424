namespace ProjMongoDB20230424.Config
{
    public class ProjMDSettings : IProjMDSettings
    {
        public string ClientCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get ; set; }
    }
}
