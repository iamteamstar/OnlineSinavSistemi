using Microsoft.AspNetCore.Mvc;
using OnlineSinav.Business.Services;
using OnlineSinav.Core.Entities;

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
		public IActionResult LessonAdd([FromBody]Lesson lesson)
		{
			bool result=_lessonService.AddLesson(lesson);
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
		
	}
}
