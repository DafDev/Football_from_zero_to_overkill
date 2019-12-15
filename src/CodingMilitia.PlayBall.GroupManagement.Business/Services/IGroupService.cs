using CodingMilitia.PlayBall.GroupManagement.Business.Models;
using System.Collections.Generic;

namespace CodingMilitia.PlayBall.GroupManagement.Business.Services
{
    public interface IGroupService
    {
        IReadOnlyCollection<Group> GetAll();
        Group GetById(int id);
        Group Update(Group group);
        Group Add(Group group);
    }
}
