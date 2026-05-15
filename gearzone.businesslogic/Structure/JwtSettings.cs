namespace gearzone.businesslogic.Structure;

public static class JwtSettings
{
    public const string Issuer = "GearZoneApi";
    public const string Audience = "GearZoneClients";
    public const string SecretKey = "gearzone_curs2026_super_secret_min_32_chars!";
    public const int ExpireMinutes = 60;
}
