namespace CBU2SINIFPROJE.BLL.ExtensionMethods
{
    public static class BasicTypeExtensionMethods
    {
        public static bool IsEmpty(this string str) => string.IsNullOrWhiteSpace(str) || string.IsNullOrEmpty(str);
        public static bool IsNull(this object obj) => obj == null;
        public static T Cast<T>(this object obj) => ((T)obj);
    }
}
