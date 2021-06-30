using System;
using System.Collections.Generic;

namespace WebMoney.Utilities.Repository {
	public interface IRepository<T> : IDisposable where T : class {
		List<T> GetList(); // получение всех объектов
		List<T> GetList(string path); // получение всех объектов
		T GetById(int Id); // получение одного объекта по id
		void Create(T item); // создание объекта
		void Update(T item); // обновление объекта
		void Delete(int Id); // удаление объекта по id
		void Save();  // сохранение изменений
	}
}