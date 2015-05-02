namespace BugTracker.RestServices.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;

    using Data.Models;
    using Models.BindingModels;
    using Models.DataModels;

    [RoutePrefix("api/bugs")]
    public class BugsController : BasicApiController
    {

        // GET /api/bugs
        [HttpGet]
        public IHttpActionResult GetAllBugs()
        {
            var bugs = this.data.Bugs
                .OrderByDescending(b => b.DateCreated)
                .Select(BugDataModel.DataModel).ToList();

            return this.Ok(bugs);
        }

        // GET: api/Bugs/5
        [HttpGet]
        public IHttpActionResult GetBugById(int id)
        {

            var bug = this.data.Bugs
                .Where(b => b.Id == id)
                .Include(c => c.Comments)
                .FirstOrDefault();

            if (bug == null)
            {
                return this.NotFound();
            }

            var bugToReturn = new BugFullDataModel
            {
                Id = bug.Id,
                Title = bug.Title,
                Description = bug.Description,
                Status = bug.Status.ToString(),
                Author = bug.Author != null ? bug.Author.UserName : null,
                DateCreated = bug.DateCreated,
            };

            if (bug.Comments.Any())
            {
                var comments = this.data.Comments
                     .Where(c => c.BugId == id)
                     .OrderByDescending(c => c.DateCreated)
                     .Select(CommentDataModel.DataModel).ToList();

                bugToReturn.Comments = comments;
            }

            return this.Ok(bugToReturn);
        }


        // PATCH /api/bugs/{id}
        [HttpPatch]
        public IHttpActionResult EditBug(int id, BugPatchBindingModel bug)
        {
            if (bug == null)
            {
                // empty requets
                return this.BadRequest();
            }

            var bugToModify = this.data.Bugs.Find(id);

            if (bugToModify == null)
            {
                // missing bug in db
                return this.BadRequest();
            }

            bool isChanged = false;
            if (!string.IsNullOrEmpty(bug.Title))
            {
                bugToModify.Title = bug.Title;
                isChanged = true;
            }

            if (bug.Description != null)
            {
                bugToModify.Description = bug.Description;
                isChanged = true;
            }

            if (bug.Status != null)
            {
                BugStatus status;
                bool isValidEnum = Enum.TryParse(bug.Status, out status);
                if (isValidEnum)
                {
                    bugToModify.Status = status;
                    isChanged = true;
                }
                else
                {
                    return this.BadRequest();
                }
            }

            if (isChanged)
            {
                this.data.SaveChanges();
            }

            return this.Ok(new BugMessageDataModel
            {
                // {"Message":"Bug #8 patched."}
                Message = string.Format("Bug #{0} {1}.", bugToModify.Id, "patched")
            });
        }

        // POST /api/bugs
        [HttpPost]
        public IHttpActionResult PostBug(BugBindingModel bug)
        {
            if (bug == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var newBug = new Bug
            {
                Title = bug.Title,
                Description = bug.Description,
                DateCreated = DateTime.Now,
                Status = BugStatus.Open
            };

            var author = this.User.Identity.GetUserId();
            if (author != null)
            {
                newBug.AuthorId = this.User.Identity.GetUserId();
            }

            data.Bugs.Add(newBug);
            data.SaveChanges();

            if (author != null)
            {
                return CreatedAtRoute("DefaultApi", new { id = newBug.Id }, new
                {
                    Id = newBug.Id,
                    Author = this.User.Identity.GetUserName(),
                    Message = "User bug submitted"

                });

            }

            return CreatedAtRoute("DefaultApi", new { id = newBug.Id }, new
                {
                    Id = newBug.Id,
                    Message = "Anonymous bug submitted"

                });
        }

        // DELETE /api/bugs/{id}
        [HttpDelete]
        public IHttpActionResult DeleteBug(int id)
        {
            Bug bug = data.Bugs.Find(id);

            if (bug == null)
            {
                return NotFound();
            }

            if (bug.Comments.Any())
            {
                foreach (var comment in this.data.Comments.Where(c => c.BugId == bug.Id))
                {
                    this.data.Comments.Remove(comment);
                }

                this.data.SaveChanges();
            }

            this.data.Bugs.Remove(bug);
            this.data.SaveChanges();

            return Ok(new BugMessageDataModel
            {
                Message = string.Format("Bug #{0} {1}.", bug.Id, "deleted")
            });
        }

        // GET /api/bugs/filter
        [HttpGet]
        [Route("filter")]
        public IHttpActionResult ListBugsByFilter(string keyword = null, string statuses = null, string author = null)
        {
            IQueryable<Bug> query = this.data.Bugs;
            var foundedStatuses = new List<BugStatus>();
            if (keyword != null)
            {
                query = query.Where(k => k.Title.Contains(keyword));
            }

            if (author != null)
            {
                query = query.Where(k => k.Author.UserName == author);
            }

            if (statuses != null)
            {
                string[] searchStatuses = statuses.Trim().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var status in searchStatuses)
                {
                    BugStatus parsedStatus;
                    bool isValidEnum = Enum.TryParse(status, out parsedStatus);
                    if (isValidEnum)
                    {
                        foundedStatuses.Add(parsedStatus);
                    }
                }
            }

            var currentSelectionOfBugs = query
                        .Include(a => a.Author)
                        .Where(q=> foundedStatuses.Contains(q.Status))
                        .Select(bug => new BugDataModel
                        {
                            Id = bug.Id,
                            Title = bug.Title,
                            Status = bug.Status.ToString(),
                            Author = bug.Author != null ? bug.Author.UserName : null,
                            DateCreated = bug.DateCreated,
                        })
                .OrderByDescending(o => o.DateCreated)
                .ToList();

            return this.Ok(currentSelectionOfBugs);
        }
    }
}