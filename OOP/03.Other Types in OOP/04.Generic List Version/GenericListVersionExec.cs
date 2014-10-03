// Task 4:  Create a [Version] attribute that can be applied to structures, classes, interfaces,
//          enumerations and methods and holds a version in the format major.minor (e.g. 2.11). 
//          Apply the version attribute to GenericList<T> class and display its version at runtime.

namespace VersionAttrtibute
{
    using System;
    using System.Linq;

    public class GenericListVersionExec
    {
        public static void Main()
        {
            var number = new GenericList<int>();
            var attributes = Attribute.GetCustomAttributes(typeof(GenericList<>));
            foreach (var attribute in attributes.OfType<VersionAttribute>())
            {
                var className = number.GetType().Name;
                Console.WriteLine("{0} class version: {1}", className, attribute.Version);
            }
        }
    }
}
