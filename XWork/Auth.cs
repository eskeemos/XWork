namespace XWork
{
    public class Auth
    {
        public string JwtKey { get; set; }
        public int ExpireDays { get; set; }
        public string Issuer { get; set; }
    }
}
