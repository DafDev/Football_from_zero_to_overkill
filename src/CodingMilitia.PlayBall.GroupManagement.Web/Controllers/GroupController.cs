using CodingMilitia.PlayBall.GroupManagement.Web.Interfaces;
using CodingMilitia.PlayBall.GroupManagement.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CodingMilitia.PlayBall.GroupManagement.Web.Controllers
{
    //localhos:50010/group
    [Route("group")]
    public class GroupController : Controller
    {
        private static List<GroupViewModel> groups = new List<GroupViewModel> { new GroupViewModel { Id = 1, Name = "Sample Group" } };
        private readonly IGroupIdGenerator _groupIdGenerator;

        public GroupController(IGroupIdGenerator groupIdGenerator)
        {
            _groupIdGenerator = groupIdGenerator;
        }
        [HttpGet]
        [Route("")] //this is the default route
        public IActionResult Index()
        {
            return View(groups);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Details(int id)
        {
            GroupViewModel group = groups.SingleOrDefault(g => g.Id == id);
            if (group == null)
            {
                return NotFound();
            }
            return View(group);
        }

        [HttpPost]
        [Route("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, GroupViewModel model)
        {

            GroupViewModel group = groups.SingleOrDefault(g => g.Id == id);
            if (group == null)
            {
                return NotFound();
            }

            group.Name = model.Name;
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(GroupViewModel model)
        {
            model.Id = _groupIdGenerator.Next();
            groups.Add(model);
            return RedirectToAction("Index");
        }
    }
}