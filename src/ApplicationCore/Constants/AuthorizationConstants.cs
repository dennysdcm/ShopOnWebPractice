namespace ShopOnWeb.ApplicationCore.Constants
{
    public class AuthorizationConstants
    {
        public const string AUTH_KEY = "AuthKeyOfDoomThatMustBeAMinimumNumberOfBytes";

        // TODO: Don't use in production
        public const string DEFAULT_PASSWORD = "Pass@word1";

        // TODO: CHange this to an environment variable
        public const string JWT_SECRET_KEY = "SecretKeyOfDoomThatMustBeAMinimumNumberOfBytes";
    }
}
