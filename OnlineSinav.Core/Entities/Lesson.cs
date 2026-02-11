using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.Core.Entities
{
	public class Lesson
	{
		public int LessonID { get; set; }
		public string LessonName { get; set; }
		public string LessonTeacher { get; set; }
		public List<Exam>? Exam { get; set; }//bir dersin birden çok sınavı olabilir
	}
}
