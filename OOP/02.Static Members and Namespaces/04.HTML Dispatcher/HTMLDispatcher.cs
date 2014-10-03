namespace HTML
{
    public static class HTMLDispatcher
    {
        public static string CreateImage(string source, string alternative, string title)
        {
            var img = new ElementBuilder("img");
            img.AddAttribute("src", source);
            img.AddAttribute("alt", alternative);
            img.AddAttribute("title", title);
            return img.ToString();
        }

        public static string CreateURL(string url, string title, string text)
        {
            var anchor = new ElementBuilder("a");
            anchor.AddAttribute("href", url);
            anchor.AddAttribute("title", title);
            anchor.AddContent(text);
            return anchor.ToString();
        }

        public static string CreateInput(string type, string name, string value)
        {
            var input = new ElementBuilder("input");
            input.AddAttribute("type", type);
            input.AddAttribute("name", name);
            input.AddAttribute("value", value);
            return input.ToString();
        }
    }
}
