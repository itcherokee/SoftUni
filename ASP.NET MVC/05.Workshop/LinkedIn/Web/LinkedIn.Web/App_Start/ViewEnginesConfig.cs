namespace LinkedIn.Web
{
    using System.Web.Mvc;

    public static class ViewEnginesConfig
    {
        public static void RegisterViewEngine(ViewEngineCollection engines)
        {
            engines.Clear();
            engines.Add(new RazorViewEngine());
        }
    }
}