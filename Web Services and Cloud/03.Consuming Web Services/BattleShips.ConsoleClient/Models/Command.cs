namespace BattleShips.ConsoleClient.Models
{
    using System.Collections.Generic;

    public class Command
    {
        public Command()
        {
            this.Content = new List<KeyValuePair<string, string>>();
            this.Header = new KeyValuePair<string, string>();
        }

        public string Uri { get; set; }

        public IList<KeyValuePair<string, string>> Content { get; set; }

        public KeyValuePair<string, string> Header { get; set; }
    }
}
