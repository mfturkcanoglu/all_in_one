namespace Infrastructure.Option;

public class TokenOption
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int TokenExpiration { get; set; }
    public string SecurityKey { get; set; }
}