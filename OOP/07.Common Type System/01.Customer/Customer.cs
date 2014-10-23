namespace CustomerManagementSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Customer : IComparable<Customer>, IComparable, ICloneable
    {
        private List<Payment> payments;
        private string firstName;
        private string middleName;
        private string lastName;
        private string id;  // EGN in Bulgaria
        private string address;
        private string mobilePhone;
        private string email;
        private CustomerType customerType;

        public Customer(
            string firstName,
            string middleName,
            string lastName,
            string id,
            CustomerType customerType,
            string address = "",
            string email = "",
            string mobilePhone = "")
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Id = id;
            this.Address = address;
            this.Email = email;
            this.MobilePhone = mobilePhone;
            this.CustomerType = customerType;
            this.payments = new List<Payment>();
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                this.CheckForValidString(value, "FirstName");
                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }

            set
            {
                this.CheckForNullString(value, "MiddleName");
                this.middleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                this.CheckForValidString(value, "LastName");
                this.lastName = value;
            }
        }

        public string Id
        {
            get
            {
                return this.id;
            }

            private set
            {
                this.CheckForValidString(value, "Id (EGN)");
                this.CheckForDigitCharsOnly(value);
                this.id = value;
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }

            set
            {
                this.CheckForNullString(value, "Address");
                this.address = value;
            }
        }

        public string MobilePhone
        {
            get
            {
                return this.mobilePhone;
            }

            set
            {
                this.CheckForNullString(value, "MobilePhone");
                this.mobilePhone = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.CheckForNullString(value, "e-Mail");
                this.email = value;
            }
        }

        public CustomerType CustomerType
        {
            get
            {
                return this.customerType;
            }

            set
            {
                if (!Enum.IsDefined(typeof(CustomerType), value))
                {
                    throw new ArgumentException("Invalid CustomerType has been provided.");
                }

                this.customerType = value;
            }
        }

        public IList<Payment> Payments
        {
            get
            {
                return this.payments.ToList().AsReadOnly();
            }
        }

        public string FullName
        {
            get
            {
                var output = new StringBuilder();
                output.AppendFormat(
                    "{0} {1} {2}",
                    this.FirstName,
                    this.MiddleName.Length == 0 ? "\b" : this.MiddleName,
                    this.LastName);
                return output.ToString();
            }
        }

        public static bool operator ==(Customer customerOne, Customer customerTwo)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(customerOne, customerTwo))
            {
                return true;
            }

            // If one or both (already covered above) is null, return false.
            if (((object)customerOne == null) || ((object)customerTwo == null))
            {
                return false;
            }

            // Return true if the fields match:
            return customerOne.CompareTo(customerTwo) == 0;
        }

        public static bool operator !=(Customer customerOne, Customer customerTwo)
        {
            return !(customerOne == customerTwo);
        }

        public void AddListOfPayments(IList<Payment> listOfPayments)
        {
            this.payments.AddRange(listOfPayments);
        }

        public void AddPayment(IPayment payment)
        {
            if (payment is Payment)
            {
                this.payments.Add(payment as Payment);
            }
            else
            {
                throw new ArgumentException("Invalid paramenter type has been provided.");
            }
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            var customer = obj as Customer;
            if (customer != null)
            {
                return this.CompareTo(customer);
            }

            throw new ArgumentException("Object is not of a Customer type.");
        }

        public int CompareTo(Customer other)
        {
            this.CheckForDigitCharsOnly(this.Id);
            this.CheckForDigitCharsOnly(other.Id);

            var nameCompareResult = string.Compare(this.FullName, other.FullName, StringComparison.Ordinal);

            if (nameCompareResult < 0)
            {
                return -1;
            }

            if (nameCompareResult > 0)
            {
                return 1;
            }

            var idComapareResult = int.Parse(this.Id).CompareTo(int.Parse(other.Id));
            if (idComapareResult < 0)
            {
                return -1;
            }

            if (nameCompareResult > 0)
            {
                return 1;
            }

            return 0;
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Customer Clone()
        {
            var newCustomer = (Customer)this.MemberwiseClone();
            newCustomer.payments = new List<Payment>();
            newCustomer.AddListOfPayments(
                this.Payments.Select(payment => new Payment(payment.ProductName, payment.ProductPrice)).ToList());

            return newCustomer;
        }

        public override int GetHashCode()
        {
            return this.LastName.GetHashCode() ^ this.FirstName.GetHashCode() ^ this.Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var customer = obj as Customer;
            if (customer == null)
            {
                return false;
            }

            return this.CompareTo(customer) == 0;
        }

        // This is not override of the base class (Object) Equals(), but instead is supouse to speed up comaparison
        // following Microsoft guidelines in MSDN.
        public bool Equals(Customer customer)
        {
            if (customer == null)
            {
                return false;
            }

            return this.CompareTo(customer) == 0;
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(string.Format("Name: {0} (Id: {1}) - {2} customer", this.FullName, this.Id, this.CustomerType));
            output.AppendLine(string.Format("Address: {0}", this.Address == string.Empty ? "<none>" : this.Address));
            output.AppendLine(string.Format("Mobile Phone: {0}", this.MobilePhone == string.Empty ? "<none>" : this.MobilePhone));
            output.AppendLine(string.Format("e-Mail: {0}", this.Email == string.Empty ? "<none>" : this.Email));
            output.Append("Payments: ");
            if (this.Payments.Count > 0)
            {
                output.AppendLine();
                foreach (var payment in this.Payments)
                {
                    output.AppendLine(string.Format("- Product: {0,-10} - Price: {1:C2}", payment.ProductName, payment.ProductPrice));
                }
            }
            else
            {
                output.AppendLine("<none>");
            }

            return output.ToString();
        }

        private void CheckForValidString(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    string.Format("Customer's {0} cannot be null, empty or white space.", propertyName));
            }
        }

        private void CheckForNullString(string value, string propertyName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(
                    "value", string.Format("Customer's {0} cannot be null.", propertyName));
            }
        }

        private void CheckForDigitCharsOnly(string value)
        {
            if (!value.All(character => character >= '0' && character <= '9'))
            {
                throw new ArgumentOutOfRangeException(
                    "value", "Only digit characters are allowed as input.");
            }
        }
    }
}
