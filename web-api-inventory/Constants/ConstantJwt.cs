namespace web_api_inventory.Helpers {
    public static class ConstantJwt {
        public static class Strings {
            public static class JwtClaimIdentifiers {
                public const string Rol = "rol",
                    Id = "id";
            }

            public static class JwtClaims {
                public const string ApiAccess = "api_access";
            }
        }
    }

}