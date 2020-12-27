namespace CBU2SINIFPROJE.BLL.ExtensionMethods
{
    public static class BasicTypeExtensionMethods
    {
        public static bool IsEmpty(this string str)
        {
            return string.IsNullOrWhiteSpace(str) || string.IsNullOrEmpty(str);
        }

        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        public static T Cast<T>(this object obj)
        {
            return ((T)obj);
        }

        public static int ToInt(this string str)
        {
            return int.Parse(str);
        }

        public static int ToInt(this object obj)
        {
            return ToInt(obj.ToString());
        }
    }
}
