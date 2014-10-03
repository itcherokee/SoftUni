namespace VersionAttrtibute
{
    using System;
    using System.Text;

    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface |
        AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = false)]
    public class VersionAttribute : Attribute
    {
        private int major;
        private int minor;

        public VersionAttribute(int major, int minor)
        {
            this.major = major;
            this.minor = minor;
        }

        public string Version
        {
            get
            {
                var output = new StringBuilder();
                output.AppendFormat("{0}.{1}", this.major, this.minor);
                return output.ToString();
            }
        }
    }
}
