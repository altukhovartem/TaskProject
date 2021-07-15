using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskProject.Models;
using TaskProject.ViewModels;
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

		public IActionResult Create()
		{
			var model = new TaskCreateViewModel();
			model.Task = new Task();
			model.TaskTypes = _taskTypeRepository.GetAllTitles();

			return View(model);
		}

		[HttpPost]
		public IActionResult Create(TaskCreateViewModel viewModel)
		{
			Task task = viewModel.Task;
			if(ModelState.IsValid)
			{
				_taskRepository.Create(task);
			}
			viewModel.TaskTypes = _taskTypeRepository.GetAllTitles();
			return View(viewModel);
		}
	}
}
