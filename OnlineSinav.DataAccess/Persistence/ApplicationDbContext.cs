using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineSinav.Core.Entities;

namespace OnlineSinav.DataAccess.Persistence
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
		{

		}
	public DbSet<Exam> Exams { get; set; }
	public DbSet<Lesson> Lessons { get; set; }
	}
}
