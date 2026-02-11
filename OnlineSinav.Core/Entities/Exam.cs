using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineSinav.Core.Entities
{
	public class Exam
	{
		public int ExamID { get; set; }
		public string ExamName { get; set; }
		public DateTime ExamDate { get; set; }
		public int ExamTime { get; set; }
		public int LessonID { get; set; }
		[JsonIgnore]
		public Lesson? Lesson { get; set; }
		




	}
}
