namespace Geometry.Geometry3D
{
    using System.Collections.Generic;
    using System.Text;

    public class Path3D : List<Point3D>
    {
        // Due to the fact that in the task there is no specific requirement to implement all methods 
        // required to sustein a specific Collection - just to create class limited to store points 
        // in 3D space, the most convenient way to automatically provide these features (Add, Clear, 
        // Remove, etc.), is to inherit already existing collection class (in the case List<>) and 
        // limit it to be able to store only points in 3D.
        // Takeing into account that, it is enough just to inherit the List by limiting to accept 
        // only Points3D. All other features (memebers) comes (have been implemented) in parent class.
        // The power of inheritance :)
        public override string ToString()
        {
            var output = new StringBuilder();
            for (int i = 1; i <= this.Count; i++)
            {
                output.AppendLine(string.Format("point {3} (X: {0}; Y: {1}; Z: {2})", this[i - 1].X, this[i - 1].Y, this[i - 1].Z, i));
            }

            return output.ToString();
        }
    }
}
