public static class IsUpperChar
{
    public static string FirstCharToUpper(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }
        {

            return char.ToUpper(input[0]) + input.Substring(1);
        }
    }
}