namespace PC
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Represents computer assemby information with pricing of parts.
    /// </summary>
    public class Computer
    {
        /// <summary>
        /// Computer model name.
        /// </summary>
        private string name;

        /// <summary>
        /// All parts required for assembly of a computer with price per part.
        /// </summary>
        private List<Component> components;

        /// <summary>
        /// Initialize a new instance of the <see cref="Computer"/>, holding
        /// all elements required a system to be assembled, the name and price.
        /// </summary>
        /// <param name="name">Name of the system.</param>
        /// <param name="components">A list with all components of the computer.</param>
        public Computer(string name, IList<Component> components)
        {
            this.Name = name;
            if (components == null)
            {
                this.components = new List<Component>();
            }
            else
            {
                this.Components = components;
            }
        }

        /// <summary>
        /// Computer model name.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Utils.ValidateStringInput(value, "Computer-Name");
                this.name = value;
            }
        }

        /// <summary>
        /// All parts required for assembly of a computer with price per part.
        /// </summary>
        public IList<Component> Components
        {
            get
            {
                return this.components.AsReadOnly();
            }

            private set
            {
                if (value != null)
                {
                    this.components = value.ToList<Component>();
                }
                else
                {
                    throw new ArgumentNullException("Null or invalid collection of componenets has been provided!");
                }
            }
        }

        /// <summary>
        /// Price of assembled computer.
        /// </summary>
        public decimal Price
        {
            get
            {
                if (this.Components == null)
                {
                    throw new ArgumentNullException("Components list has not been initialized properly!");
                }

                return this.Components.Count > 0 ? this.Components.Sum(part => part.Price) : 0.0m;
            }
        }

        /// <summary>
        /// Adds a new component to the list of componenets.
        /// </summary>
        /// <param name="component">New instance of class Component,
        /// containing the information for the new part.</param>
        /// <returns>True - if operation is successful and False if component was not added.</returns>
        public bool AddComponent(Component component)
        {
            var componentType = component as Component;
            if (component == null || componentType == null)
            {
                return false;
            }

            this.components.Add(component);
            return true;
        }

        /// <summary>
        /// Converts the value of this instance to a string representation.
        /// </summary>
        /// <returns>Returns System.String.</returns>
        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(string.Format("Computer: {0}", this.Name));
            var bg = new CultureInfo("bg-BG");
            if (this.Components.Any())
            {
                foreach (var part in this.Components)
                {
                    output.AppendLine(string.Format("\t{0} - {1}", part.Name, part.Price.ToString("C2", bg)));
                }
            }

            output.AppendLine(string.Format("Total price: {0}", this.Price.ToString("C2", bg)));
            return output.ToString();
        }
    }
}
