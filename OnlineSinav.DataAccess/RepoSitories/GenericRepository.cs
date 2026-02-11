using Microsoft.EntityFrameworkCore;
using OnlineSinav.Core.Interfaces;
using OnlineSinav.DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OnlineSinav.DataAccess.RepoSitories
{
	/*Eğer Repository içinde AppDbContext context = new AppDbContext(); dersen, her işlemde veritabanına sıfırdan, yepyeni bir bağlantı açmış olursun. Bu hem performansı öldürür hem de Program.cs'te yaptığımız ayarları (Connection String vb.) görmezden gelir.

Bunun yerine, Dependency Injection (Bağımlılık Enjeksiyonu) kullanacağız. Yani: "Bana yeni bir context yaratma, zaten Program.cs tarafından yaratılmış hazır context'i bana ver."

Bunu yapmak için sınıfın Constructor (Yapıcı Metot) kısmını kullanırız.*/
	public class GenericRepository<T> :IGenericRepository<T> where T : class
	{

		private readonly ApplicationDbContext _context;
		private readonly DbSet<T> _dbSet; // İşlemleri kolaylaştırmak için

		public GenericRepository(ApplicationDbContext context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
		}

		public void Insert(T entity)
		{
			_dbSet.Add(entity);
			_context.SaveChanges();
		}
		public void Update(T entity)
		{
			_dbSet.Update(entity);
			_context.SaveChanges();
		}
		public void Delete(T entity)
		{
			_dbSet.Remove(entity);
			_context.SaveChanges();
		}
		public List<T> GetList()
		{
			// Veritabanındaki tüm kayıtları listeye çevirip getirir
			return _dbSet.ToList();
		}
		public T GetById (int id)
		{
			return _context.Set<T>().Find(id);
		}
	}
}
