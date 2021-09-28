using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskProject.Models
{
	public class Task
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Type { get; set; }
		public DateTime CreatedTime { get; set; }
	}
}
