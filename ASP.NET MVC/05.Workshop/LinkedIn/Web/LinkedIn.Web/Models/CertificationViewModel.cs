namespace LinkedIn.Web.Models
{
    using System;
    using System.Linq.Expressions;
    using LinkedIn.Models;

    public class CertificationViewModel
    {
        public static Expression<Func<Certification, CertificationViewModel>> ViewModel
        {
            get
            {
                return x => new CertificationViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    LicenseNumber = x.LicenseNumber,
                    Url = x.Url,
                    TakenDate = x.TakenDate,
                    ExpirationDate = x.ExpirationDate
                };
            }
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string LicenseNumber { get; set; }

        public string Url { get; set; }

        public DateTime TakenDate { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
