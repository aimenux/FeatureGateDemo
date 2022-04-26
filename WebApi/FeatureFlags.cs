namespace WebApi;

public static class FeatureFlags
{
    public const string GetInfoFeature = "GetInfo";
}

public static class FeatureFlagsExtensions
{
    public static string ToConfigurationKeyName(this string feature) => $"FeatureManagement:{feature}";
}