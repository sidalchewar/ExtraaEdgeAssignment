using ExtraaEdgeAssignment.DBContext;
using ExtraaEdgeAssignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExtraaEdgeAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        private readonly MobileDbContext _context;

        public MobileController(MobileDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Mobile> GetMobiles()
        {
            if (_context.Mobiles == null)
            {
                return null;
            }
            return _context.Mobiles.ToList();
        }

        // GET: api/MobileBrands/5
        [HttpGet("{id}")]
        public Mobile GetMobileById(int id)
        {
            if (_context.Mobiles.Find(id) == null)
            {
                return null;
            }
            return _context.Mobiles.Find(id);
        }

        [HttpPut("{id}")]
        public Mobile PutMobile(int id, Mobile mobile)
        {
            if (_context.MobileBrands.Find(id) != null)
            {
                _context.Mobiles.Update(mobile);
                _context.SaveChanges();
                return _context.Mobiles.Find(id);
            }
            return null;

        }

        [HttpPost]
        public Mobile AddMobile(Mobile mobile)
        {
            if (mobile!=null)
            {
               
                _context.Mobiles.Add(mobile);
                _context.SaveChanges();
                return mobile;
            }
            return null;
        }

        [HttpDelete("{id}")]
        public Mobile DeleteMobile(int id)
        {
            if (_context.Mobiles.Find(id) != null)
            {
                var obj = _context.Mobiles.Find(id);
                _context.Mobiles.Remove(obj);
                _context.SaveChanges();
                return obj;
            }
            return null;
        }

        [HttpPut("{id}/{price}")]
        public Mobile UpdatePrice(int id,float price)
        {
            Mobile mb = _context.Mobiles.Find(id);
            if (mb != null)
            {
                mb.Price=price;
                _context.Mobiles.Update(mb);
                _context.SaveChanges();
                return mb;
            }

            return null;
        }

    }
}
