using CodingMilitia.PlayBall.GroupManagement.Web.Interfaces;

namespace CodingMilitia.PlayBall.GroupManagement.Web.Models
{
    public class GroupIdGenerator : IGroupIdGenerator
    {
        private int _currentId = 1;

        public int Next()
        {
            return ++_currentId;
        }
    }
}
