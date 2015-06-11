namespace LinkedIn.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using LinkedIn.Models;

    public class UserViewModel
    {
        public static Expression<Func<User, UserViewModel>> ViewModel
        {
            get
            {
                return x => new UserViewModel
                {
                    UserName = x.UserName,
                    FullName = x.FullName,
                    AvatarUrl = x.AvatarUrl,
                    Summary = x.Summary,
                    Email = x.Email,
                    ContactInfo = x.ContactInfo,
                    Certifications = x.Certifications.AsQueryable().Select(CertificationViewModel.ViewModel)
                };
            }
        }

        public string Id { get; set; }

        [Display(Name = "Потребителско име")]
        public string UserName { get; set; }

        [Display(Name = "Потребителски мейл")]
        public string Email { get; set; }

        [Display(Name = "Пълно име")]
        public string FullName { get; set; }

        [Display(Name = "Аватар")]
        public string AvatarUrl { get; set; }

        [Display(Name = "Нещо за мен")]
        public string Summary { get; set; }

        public ContactInfo ContactInfo { get; set; }

        public IEnumerable<CertificationViewModel> Certifications { get; set; }

        public IEnumerable<SkillViewModel> Skills { get; set; }

    }
}