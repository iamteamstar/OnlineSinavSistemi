using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OnlineSinav.Core.Interfaces
{
	/*Eğer Repository içinde AppDbContext context = new AppDbContext(); dersen, her işlemde veritabanına sıfırdan, yepyeni bir bağlantı açmış olursun. Bu hem performansı öldürür hem de Program.cs'te yaptığımız ayarları (Connection String vb.) görmezden gelir.

Bunun yerine, Dependency Injection (Bağımlılık Enjeksiyonu) kullanacağız. Yani: "Bana yeni bir context yaratma, zaten Program.cs tarafından yaratılmış hazır context'i bana ver."

Bunu yapmak için sınıfın Constructor (Yapıcı Metot) kısmını kullanırız.*/
	public interface IGenericRepository<T> where T: class
	{
		void Insert(T entity);
		void Update(T entity);
		void Delete(T entity);
	    List<T> GetList();
	}
}
