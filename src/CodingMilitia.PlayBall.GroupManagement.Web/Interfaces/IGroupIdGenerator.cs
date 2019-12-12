using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingMilitia.PlayBall.GroupManagement.Web.Interfaces
{
    public interface IGroupIdGenerator
    {
        int Next();
    }
}
