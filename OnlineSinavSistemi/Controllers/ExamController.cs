using Microsoft.AspNetCore.Mvc;
using OnlineSinav.Core.Entities;
using OnlineSinav.Core.Interfaces;
using OnlineSinav.Business.Services;
using OnlineSinavSistemi.DTOs;
namespace OnlineSinavSistemi.Controllers
{
	[ApiController]
	[Route("api/[Controller]")]
	public class ExamController : ControllerBase
	{
		private readonly ExamService _examService;
		public ExamController(ExamService examService)
		{
			_examService=examService;
		}
		[HttpPost]
		public ActionResult CreateExam([FromBody]ExamCreateDto examDto)
		{
			var newExam=new Exam();
			examDto.ExamName = newExam.ExamName;
			examDto.ExamDate=newExam.ExamDate;
			examDto.ExamTime=newExam.ExamTime;
			bool result=_examService.AddExam(newExam);
			if (!result)
			{
				return BadRequest("sınav eklenirken kullanıcı taraflı hata");
			}
			return Ok("başarıyla eklendi");
		
		}
		[HttpGet]
		public IActionResult GetExam()
		{
			var exams = _examService.GetExamList();
			return Ok(exams);
		}
		[HttpPut]
		public IActionResult UpdateExam(ExamUpdateDto examUpdateDto)
		{
			var putExam = new Exam
			{
				ExamID= examUpdateDto.ExamID,
				ExamName= examUpdateDto.ExamName,
				ExamDate= examUpdateDto.ExamDate,
				ExamTime= examUpdateDto.ExamTime,
				LessonID= examUpdateDto.LessonID,
			
			};
			var result=_examService.UpdateExam(putExam);
			if (!result)
			{ return BadRequest("guncelleme basarisiz"); }
			return Ok("basariyla guncelleme yapildi");

		}


	}
}
