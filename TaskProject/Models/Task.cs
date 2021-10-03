using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskProject.Models
{
	public class Task
	{
		[Key]
		[Display(Name = "Item ID")]
		public int Id { get; set; }
		[Display(Name = "Item Title")]
		public string Title { get; set; }
		[Display(Name = "Item Type")]
		public string Type { get; set; }

		public string Status { get; set; }

		[Display(Name = "Created DateTime")]
		public DateTime CreatedTime { get; set; }
	}
}
