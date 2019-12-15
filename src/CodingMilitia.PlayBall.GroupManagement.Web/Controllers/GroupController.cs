using CodingMilitia.PlayBall.GroupManagement.Business.Models;
using CodingMilitia.PlayBall.GroupManagement.Business.Services;
using CodingMilitia.PlayBall.GroupManagement.Web.Mappings;
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
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }
        [HttpGet]
        [Route("")] //this is the default route
        public IActionResult Index()
        {
            return View(_groupService.GetAll().ToViewModel());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Details(int id)
        {
            Group group = _groupService.GetById(id);
            if(group == null)
            {
                return NotFound();
            }
            return View(group.ToViewModel());
        }

        [HttpPost]
        [Route("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, GroupViewModel model)
        {

            Group group = _groupService.Update(model.ToServiceModel());
            if (group == null)
            {
                return NotFound();
            }
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
        [ValidateAntiForgeryToken]
        public IActionResult Create(GroupViewModel model)
        {
            _groupService.Add(model.ToServiceModel());
            return RedirectToAction("Index");
        }
    }
}