using Microsoft.AspNetCore.Mvc;
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

		public TaskController(ITaskRepository taskRepository)
		{
			this._taskRepository = taskRepository;
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
	}
}
