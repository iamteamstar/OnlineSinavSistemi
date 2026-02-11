using OnlineSinav.Core.Entities;

namespace OnlineSinavSistemi.DTOs
{
	public class ExamUpdateDto
	{
		public int ExamID { get; set; }
		public string ExamName { get; set; }
		public DateTime ExamDate { get; set; }
		public int ExamTime { get; set; }
		public int LessonID { get; set; }

	}
}
