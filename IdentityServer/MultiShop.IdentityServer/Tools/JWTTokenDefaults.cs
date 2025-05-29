namespace MultiShop.IdentityServer.Tools
{
    public class JWTTokenDefaults
    {
        public const string ValidAudience = "http://localhost";
        public const string ValidIssuer = "http://localhost";
        public const string Key = "MultiShop..0102030405Asp.Netcore8.0.15+-***";
        public const int ExpireMinutes = 60; // Token'un geçerlilik süresi (dakika cinsinden)
        
    }
}
