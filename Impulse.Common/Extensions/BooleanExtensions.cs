namespace Impulse.Common.Extensions
{
    public static class BooleanExtensions
    {
        public static string AsSuccess(this bool args)
        {
            if (args)
                return "success";

            return "fail";

        } // string AsSuccess(this bool args)

        public static string AsExists(this bool args)
        {
            if (args)
                return "exists";

            return "missing";

        } // string AsSuccess(this bool args)


    } // class BooleanExtensions
} // namespace Impulse.Common.Extensions