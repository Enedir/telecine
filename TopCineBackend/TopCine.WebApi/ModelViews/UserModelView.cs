using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopCine.Domain.Features.Users;

namespace TopCine.WebApi.ModelViews
{
    public class UserModelView
    {
        public long Id { set; get; }

        public String Name { set; get; }

        public String Email { set; get; }

        public AccessLevelEnum AccessLevel { set; get; }
    }
}
