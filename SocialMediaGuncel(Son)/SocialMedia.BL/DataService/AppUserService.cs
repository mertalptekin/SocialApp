using SocialMedia.DAL.Models.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.BL.DataService
{
    public class AppUserService:BaseRepository<AppUser>
    {
        public override void Insert(AppUser entity)
        {
            if (!_dbset.Any(x=> x.Email==entity.Email || x.UserName==entity.UserName))
            {
                entity.IsActive = false;
                _db.Set<AppUser>().Add(entity);
            }
        }
    }
}
