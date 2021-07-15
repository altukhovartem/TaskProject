using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskProject.Models;
using Task = TaskProject.Models.Task;

namespace TaskProject.ViewModels
{
	public class TaskCreateViewModel
	{
		public Task Task { get; set; }
		public IEnumerable<string> TaskTypes;

	}
}
