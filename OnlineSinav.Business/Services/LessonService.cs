using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineSinav.Core.Entities;
using OnlineSinav.Core.Interfaces;

namespace OnlineSinav.Business.Services
{
	public class LessonService
	{
		private readonly IGenericRepository<Lesson> _lessonRepository;
		//CONSTRUCTOR:Dışarıdan gelen "Repository" yapıştırıcısını içeri alıyoruz
		public LessonService(IGenericRepository<Lesson> lessonRepository)
		{
			_lessonRepository = lessonRepository;
		}
		public bool AddLesson(Lesson lesson)
		{
			if(string.IsNullOrEmpty(lesson.LessonName) ||lesson.LessonName.Length<2)
			{
				return false;
			}
			_lessonRepository.Insert(lesson);
			return true;
		}
		public List<Lesson> GetAllLessons()
		{
			return _lessonRepository.GetList();
		}
	}
}
