using BlogSystem.Data;

namespace BlogSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using BlogSystem.Models;
    using Models;

    public class UsersController : ApiController
    {
        protected IBlogSystemData data;

        protected UsersController()
            : this(new BlogSystemData(new BlogSystemDbContext()))
        {
        }

        protected UsersController(IBlogSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var users = this.data
                .Users
                .All()
                .Select(UserOutputData.FromUser);

            return Ok(users);
        }

        [HttpPost]
        public IHttpActionResult Create(UserOutputData user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newUser = new User
            {
                FullName = user.FullName,
                Gender = user.Gender,
                RegistrationDate = user.RegistrationDate,
                Username = user.Username,
                Birthday = user.Birthday,
                ContactInfo = new UserContactInfo
                {
                    Facebook = user.Facebook,
                    PhoneNumber = user.PhoneNumber,
                    Skype = user.Skype,
                    Tweeter = user.Tweeter
                }
            };


            this.data.Users.Add(newUser);
            this.data.SaveChanges();

            return Ok(newUser.Id);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, UserOutputData user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = this.data.Users.All().FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return BadRequest("Such user does not exists!");
            }

            existingUser.FullName = user.FullName ?? existingUser.FullName;
            existingUser.Gender = user.Gender.Equals(existingUser.Gender) ? existingUser.Gender : user.Gender;
            existingUser.RegistrationDate = user.RegistrationDate.Equals(existingUser.RegistrationDate)
                ? existingUser.RegistrationDate
                : user.RegistrationDate;
            existingUser.Username = user.Username ?? existingUser.Username;
            existingUser.Birthday = user.Birthday.Equals(existingUser.Birthday) ? existingUser.Birthday : user.Birthday;
            existingUser.ContactInfo.Facebook = user.Facebook ?? existingUser.ContactInfo.Facebook;
            existingUser.ContactInfo.PhoneNumber = user.PhoneNumber ?? existingUser.ContactInfo.PhoneNumber;
            existingUser.ContactInfo.Skype = user.Skype ?? existingUser.ContactInfo.Skype;
            existingUser.ContactInfo.Tweeter = user.Tweeter ?? existingUser.ContactInfo.Tweeter;

            this.data.Users.Update(existingUser);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Remove(int id)
        {
            var exisitingUser = this.data.Users.All().FirstOrDefault(u => u.Id == id);
            if (exisitingUser == null)
            {
                return BadRequest("Such User does not exists!");
            }

            this.data.Users.Delete(exisitingUser);
            this.data.SaveChanges();

            return Ok();
        }
    }
}
