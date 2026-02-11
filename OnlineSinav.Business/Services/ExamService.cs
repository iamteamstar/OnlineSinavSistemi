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

	}
}
