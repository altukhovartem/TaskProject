using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskProject.Models;
using TaskProject.Security;
using Task = TaskProject.Models.Task;

namespace TaskProject.Controllers
{
	[Authorize(Roles = "Manager")]
	public class TaskController : Controller
	{
		private readonly ITaskRepository _taskRepository;
		private readonly ITaskTypeRepository _taskTypeRepository;
		private readonly UserManager<AppIdentityUser> _userManager;

		public TaskController(ITaskRepository taskRepository, ITaskTypeRepository taskTypeRepository, UserManager<AppIdentityUser> userManager)
		{
			this._taskRepository = taskRepository;
			this._taskTypeRepository = taskTypeRepository;
			this._userManager = userManager;
		}
		public IActionResult List()
		{
			IEnumerable<Task> tasks = _taskRepository.GetAll().Where(x=>x.UserID == _userManager.GetUserId(User));
			return View(tasks);
		}

		public IActionResult Details(int id)
		{
			FindAllTasks();
			FindAllStatuses();
			Task task = _taskRepository.GetById(id);
			if(task is null)
			{
				return NotFound();
			}
			return View(task);
		}

		[HttpPost]
		public IActionResult Save(Task task)
		{
			FindAllTasks();
			if (ModelState.IsValid)
			{
				_taskRepository.Update(task);
				ViewBag.Message = "The task updated successfully";
			}
			return View("Details", task);
		}

		[HttpPost]
		public IActionResult Delete(Task task)
		{
			_taskRepository.Delete(task);
			return RedirectToAction("List");
		}

		public IActionResult Create()
		{
			FindAllTasks();
			return View();
		}

		[HttpPost]
		public IActionResult Create(Task task)
		{
			task.Status = Status.New.ToString();
			task.UserID = _userManager.GetUserId(User);

			if (ModelState.IsValid)
			{
				_taskRepository.Create(task);
				ViewBag.Message = "The task cretaed successfully";
			}
			FindAllTasks();
			return View(task);
		}

		private void FindAllTasks()
		{
			ViewBag.ListOfTaskTypes = _taskTypeRepository
							.GetAll()
							.Select(x => new SelectListItem() { Text = x.Name, Value = x.Name });
		}

		private void FindAllStatuses()
		{
			ViewBag.ListOfStatuses = Enum.GetNames(typeof(Status))
							.Select(x => new SelectListItem() { Text = x, Value = x });
		}
	}
}
