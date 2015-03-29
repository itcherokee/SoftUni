namespace CatalogOfMusicalAlbums
{
    using System;
    using System.Collections.Generic;
    using System.Xml;


    class CatalogClient
    {
        static void Main()
        {
            // Problem 2.	DOM Parser: Extract Album Names
            //              Write a program that extracts all album names from catalog.xml. Use the DOM parser.
            XmlDocument doc = new XmlDocument();
            doc.Load(@"../../catalog.xml");

            XmlNode rootNode = doc.DocumentElement;

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                Console.WriteLine("Album name: {0}", node["name"].ChildNodes[0].Value);
            }

            // Problem 3.	DOM Parser: Extract All Artists Alphabetically
            //              Write a program that extracts all artists in alphabetical order from catalog.xml. 
            //              Use the DOM parser. Keep the artists in a SortedSet<string> to avoid duplicates 
            //              and to keep the artist in alphabetical order.

            var sortedArtists = new SortedSet<string>();
            foreach (XmlNode artist in rootNode.ChildNodes)
            {
                sortedArtists.Add(artist["artist"].ChildNodes[0].Value);
            }

            Console.WriteLine("\nSorted artists: {0}", string.Join(", ", sortedArtists));
        }
    }
}
