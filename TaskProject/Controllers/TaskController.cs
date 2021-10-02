using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskProject.Models;
using Task = TaskProject.Models.Task;

namespace TaskProject.Controllers
{
	public class TaskController : Controller
	{
		private readonly ITaskRepository _taskRepository;
		private readonly ITaskTypeRepository _taskTypeRepository;

		public TaskController(ITaskRepository taskRepository, ITaskTypeRepository taskTypeRepository)
		{
			this._taskRepository = taskRepository;
			this._taskTypeRepository = taskTypeRepository;
		}
		public IActionResult List()
		{
			IEnumerable<Task> tasks = _taskRepository.GetAll();
			return View(tasks);
		}

		public IActionResult Details(int id)
		{
			Task task = _taskRepository.GetById(id);
			if(task is null)
			{
				return NotFound();
			}
			return View(task);
		}

		[HttpPost]
		public IActionResult Details(Task task)
		{
			if (ModelState.IsValid)
			{
				_taskRepository.Update(task);
				ViewBag.Message = "The task updated successfully";
			}
			return View(task);
		}

		public IActionResult Create()
		{
			FindAllTasks();
			return View();
		}

		[HttpPost]
		public IActionResult Create(Task task)
		{
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
	}
}
