namespace EuclidianSpace
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public static class Storage
    {
        private static string fileName = "coordinates.txt";
        private static string path = Environment.CurrentDirectory + Path.DirectorySeparatorChar + fileName;

        /// <summary>
        /// Saves the 3D-points located in the list of points in 3Dspace to a text file.
        /// </summary>
        /// <param name="points">Reference to a list of 3D-coordinates.</param>
        public static void Save(IEnumerable<Point3D> points, string file = null)
        {
            string currentPath = path;
            if (!string.IsNullOrWhiteSpace(file))
            {
                currentPath = file;
            }

            using (var writer = new StreamWriter(currentPath, false, Encoding.UTF8))
            {
                foreach (var coordinate in points)
                {
                    writer.WriteLine(coordinate.X + "\t" + coordinate.Y + "\t" + coordinate.Z);
                }
            }
        }

        /// <summary>
        /// Loads the 3D-points located in the text file to a list of points in 3Dspace. 
        /// </summary>
        /// <returns>Returns an <param name="Path"/> list of Point3D objects, representing points in space.</returns>
        public static Path3D Load(string file = null)
        {
            string currentPath = path;
            if (!string.IsNullOrWhiteSpace(file))
            {
                currentPath = file;
            }

            // instantiates the List to be returned
            var listCoordinates = new Path3D();
            using (var reader = new StreamReader(currentPath, Encoding.UTF8))
            {
                while (reader.Peek() > -1)
                {
                    // declate object to hold coordinates {x,y,z}
                    var point = new Point3D();
                    try
                    {
                        var line = reader.ReadLine();
                        if (line == null)
                        {
                            continue;
                        }

                        string[] lineWithCoordinates = line.Trim().Split((char)9);

                        // convert each component of 3D-coordinate to daouble and add it to the List of 3-D coordinates
                        point.X = double.Parse(lineWithCoordinates[0]);
                        point.Y = double.Parse(lineWithCoordinates[1]);
                        point.Z = double.Parse(lineWithCoordinates[2]);
                        listCoordinates.Add(point);
                    }
                    catch
                    {
                        // handling exception if some of the coordinates are not numbers
                        throw new ArgumentOutOfRangeException("Coordinates", "There are values which are not valid coordinates in the text file!.");
                    }
                }
            }

            return listCoordinates;
        }
    }
}