namespace HTML
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ElementBuilder
    {
        private readonly string[] selfClosingTags =
        {
            "area", "base", "br", "col", 
            "command", "embed", "hr", 
            "img", "input", "keygen", 
            "link", "meta", "param",
            "source", "track", "wbr"
        };

        private readonly Dictionary<string, string> attributes;
        private string tagName;
        private string text;

        /// <summary>
        /// Initialize an instance of <see cref="ElementBuilder"/> class.
        /// </summary>
        /// <param name="tagName">Type of the created HTML element.</param>
        public ElementBuilder(string tagName)
        {
            this.TagName = tagName;
            this.Content = string.Empty;
            this.attributes = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets or sets tag name.
        /// </summary>
        private string TagName
        {
            get
            {
                return this.tagName;
            }

            set
            {
                this.CheckValidity("Tag Name", value);
                this.tagName = value;
            }
        }

        /// <summary>
        /// Gets or sets content of the tag.
        /// </summary>
        private string Content
        {
            get
            {
                return this.text;
            }

            set
            {
                this.text = string.IsNullOrEmpty(value) ? string.Empty : value;
            }
        }

        /// <summary>
        /// Gets the Attributes added to HTML element as sequence.
        /// </summary>
        private string Attributes
        {
            get
            {
                if (this.attributes.Count > 0)
                {
                    var sequence = new string[this.attributes.Count];
                    int index = 0;
                    foreach (var pair in this.attributes)
                    {
                        sequence[index++] = string.Format("{0}=\"{1}\"", pair.Key, pair.Value);
                    }

                    return string.Join(" ", sequence);
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// Creates sequence of specified HTML element, specified number of times.
        /// </summary>
        /// <param name="element">HTML element represented as <see cref="ElementBuilder"/> object.</param>
        /// <param name="multiplier">Number of times to be repeated in sequence.</param>
        /// <returns>Sequence of repeated HTML element as a String.string.</returns>
        public static string operator *(ElementBuilder element, int multiplier)
        {
            var output = new StringBuilder();
            for (int i = 0; i < multiplier; i++)
            {
                output.Append(element);
            }

            return output.ToString();
        }

        /// <summary>
        /// Adds an attribute and it's value to HTML element.
        /// </summary>
        /// <param name="attribute">Attribute name.</param>
        /// <param name="value">Attribute value.</param>
        public void AddAttribute(string attribute, string value)
        {
            this.CheckValidity("Attribute Name", attribute);
            try
            {
                this.attributes.Add(attribute, value);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("The specified attirbute has been already added to this HTML element!");
            }
        }

        /// <summary>
        /// Inserts content inside tag.
        /// </summary>
        /// <param name="content">HTML element content text.</param>
        public void AddContent(string content)
        {
            this.Content = content;
        }

        /// <summary>
        /// Converts current instance of <see cref="ElementBuilder"/> into
        /// string representation taking into consideration self closing tags as well.
        /// </summary>
        /// <returns>HTML string representation of current instantiated tag.</returns>
        public override string ToString()
        {
            var output = new StringBuilder();
            if (this.selfClosingTags.Contains(this.TagName.ToLower()))
            {
                output.AppendFormat("<{0} {1} />", this.TagName, this.Attributes);
            }
            else
            {
                output.AppendFormat("<{0} {1}>{2}</{0}>", this.TagName, this.Attributes, this.Content);
            }

            return output.ToString();
        }

        // Checks does entered value is valid.
        private void CheckValidity(string property, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(property, property + " cannot be null, empty or space!");
            }
        }
    }
}
