using System.Linq;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using Domain;
using Guestbook.Attributes;
using Guestbook.Models;

namespace Guestbook.Controllers
{
    public class MsgsController : ODataController
    {
        private readonly GuestbookContext _db = new GuestbookContext();

        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.InlineCount | AllowedQueryOptions.Top | AllowedQueryOptions.Skip | AllowedQueryOptions.OrderBy)]
        public IQueryable<Msg> GetMsgs()
        {

            return _db.Msgs.Select(n => new Msg
            {
                Id = n.Id,
                UserName = n.UserName,
                Email = n.Email,
                HomePage = n.HomePage,
                Date = n.Date,
                Text = n.Text
            });
        }

        [ValidateHttpAntiForgeryToken]
        public IHttpActionResult Post(Msg msg)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var msgE = new Domain.Models.Msg
            {
                UserName = msg.UserName,
                Email = msg.Email,
                HomePage = msg.HomePage,
                Text = msg.Text,
                Date = msg.Date,
                Ip = ((System.Web.HttpContextWrapper)Request.Properties["MS_HttpContext"]).Request.UserHostAddress,
                Browser = Request.Headers.UserAgent.ToString()
            };

            _db.Msgs.Add(msgE);
            _db.SaveChanges();

            msg.Id = msgE.Id;
            return Created(msg);
        }
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
