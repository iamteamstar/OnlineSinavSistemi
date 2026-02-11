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
		public bool UpdateLesson(Lesson lesson)
		{
			if(string.IsNullOrEmpty(lesson.LessonName)||lesson.LessonID<0||lesson.LessonName.Length<2||string.IsNullOrEmpty(lesson.LessonTeacher))
				{
				return false;
					}
			_lessonRepository.Update(lesson);
			return true;
		}
		public bool DeleteLesson(int id)
		{
			var lessonfind = _lessonRepository.GetById(id);
			if(lessonfind==null)
			{
				return false;
			}
			_lessonRepository.Delete(lessonfind);
			return true;

		}
	}
}
