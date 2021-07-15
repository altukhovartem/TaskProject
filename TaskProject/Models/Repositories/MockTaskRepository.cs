using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskProject.Models
{
	public class MockTaskRepository: ITaskRepository
	{
		private readonly List<Task> _tasks;
		private readonly ITaskTypeRepository _taskTypeRepository;

		public MockTaskRepository()
		{
			_taskTypeRepository = new MockTaskTypeRepository();
			_tasks = new List<Task>
			{
				new Task { Id = 1, Title = "Task1", CreatedTime = new DateTime(2001, 1, 1), Type = _taskTypeRepository.GetAll().ToList()[0] },
				new Task { Id = 2, Title = "Task2", CreatedTime = new DateTime(2002, 2, 2), Type = _taskTypeRepository.GetAll().ToList()[1] },
				new Task { Id = 3, Title = "Task3", CreatedTime = new DateTime(2003, 3, 3), Type = _taskTypeRepository.GetAll().ToList()[2] },
				new Task { Id = 4, Title = "Task4", CreatedTime = new DateTime(2004, 4, 4), Type = _taskTypeRepository.GetAll().ToList()[0] },
			};
		}

		public void Create(Task task)
		{
			task.Id = _tasks.Max(x => x.Id)+1;
			_tasks.Add(task);
		}

		public IEnumerable<Task> GetAll()
		{
			return _tasks;
		}

		public Task GetById(int Id)
		{
			return	_tasks.Where(t => t.Id == Id).SingleOrDefault();
		}
	}
}
