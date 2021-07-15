using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskProject.Models
{
	public class MockTaskTypeRepository: ITaskTypeRepository
	{
		private List<TaskType> _types = new List<TaskType>
		{ 
			new TaskType{Id=1, Title = "Task"},
			new TaskType{Id=2, Title = "Bug"},
			new TaskType{Id=3, Title = "ChangeRequest"}
		};


		public IEnumerable<TaskType> GetAll()
		{
			return _types;
		}

		public IEnumerable<string> GetAllTitles()
		{
			return _types.Select(x => x.Title);
		}
	}
}
