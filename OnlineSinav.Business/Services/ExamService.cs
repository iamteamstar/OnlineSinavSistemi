using OnlineSinav.Core.Entities;
using OnlineSinav.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.Business.Services
{
	
	public class ExamService
	{
		private IGenericRepository<Exam> _examRepository;
		public ExamService(IGenericRepository<Exam> examRepository)
		{
			_examRepository = examRepository;
		}
		public bool AddExam(Exam exam)
		{
			
			if(exam.ExamTime<=0 || exam.ExamDate<DateTime.Now || string.IsNullOrEmpty(exam.ExamName))
			{
					return false;
			}
			_examRepository.Insert(exam);
			return true;
		}
		public List<Exam> GetExamList()
		{
			return _examRepository.GetList();
		}
		public bool UpdateExam(Exam exam)
		{
			if (string.IsNullOrEmpty(exam.ExamName)||exam.ExamID<2||exam.ExamTime<15||exam.ExamDate<DateTime.Now)
			{
				return false;
			}
			_examRepository.Update(exam);
			return true;
		}
		public bool DeleteExam(int id)
		{
			var examFind=_examRepository.GetById(id);
			if (examFind == null) 
			{
				return false;
			}
			_examRepository.Delete(examFind);
			return true;
		}

	}
}
