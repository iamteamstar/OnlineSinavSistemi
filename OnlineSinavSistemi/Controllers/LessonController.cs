using Microsoft.AspNetCore.Mvc;
using OnlineSinav.Business.Services;
using OnlineSinav.Core.Entities;
using OnlineSinavSistemi.DTOs;

namespace OnlineSinavSistemi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class LessonController : ControllerBase
	{
		private readonly LessonService _lessonService;

		public LessonController(LessonService lessonService)
		{
			_lessonService = lessonService;
		}
		[HttpPost]
		public IActionResult CreateLesson([FromBody] LessonCreateDto lessonDto)
		{
			var newLesson=new Lesson();
			newLesson.LessonName = lessonDto.LessonName;
			newLesson.LessonTeacher=lessonDto.LessonTeacher;
			bool result=_lessonService.AddLesson(newLesson);
			if (!result)
			{
				return Ok("ders adı en az iki karakter olmalı");
			}
			return Ok("Ders başarıyla yüklendi");
		}
		[HttpGet]
			public IActionResult GetLesson() 
			{
			var lessons=_lessonService.GetAllLessons();
			return Ok(lessons);
			}
		[HttpPut]
		public IActionResult UpdateLesson(LessonUpdateDto lessonDto)
		{
			var putLesson=new Lesson
			{
				LessonID = lessonDto.LessonID,
				LessonName = lessonDto.LessonName,
				LessonTeacher= lessonDto.LessonTeacher

			};
			bool result=_lessonService.UpdateLesson(putLesson);
			if (!result)
			{
				return BadRequest("kullanıcı tabanlı hata");

			}
			return Ok("basariyla guncellendi");

		}
		[HttpDelete("{id}")]
		public IActionResult DeleteLesson(int id)
		{
			var result = _lessonService.DeleteLesson(id);
			if (!result)
			{
				return BadRequest("silme basarisiz");
			}
			return Ok("silme basariyla gerceklesti");
		}
	}
}
