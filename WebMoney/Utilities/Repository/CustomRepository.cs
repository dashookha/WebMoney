using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using WebMoney.Utilities.Models;

namespace WebMoney.Utilities.Repository {
	public abstract class CustomRepository<T> : IRepository<T> where T : class, IEntity {
		private bool disposedValue;

		protected DbContext context;
		protected abstract DbSet<T> collection { get; set; }

		public CustomRepository() { }

		public CustomRepository(DbContext context, DbSet<T> collection) {
			this.context = context;
			this.collection = collection;
		}

		public void Create(T item) {
			collection.Add(item);
		}

		public void Delete(int Id) {
			var item = collection.FirstOrDefault(q => q.Id == Id);
			collection.Remove(item);
		}

		public T GetById(int Id) {
			return collection.FirstOrDefault(q => q.Id == Id);
		}

		public List<T> GetList() {
			return collection.ToList();
		}

		public List<T> GetList(string path) {
			return collection.Include(path).ToList();
		}

		public void Save() {
			context.SaveChanges();
		}

		public void Update(T item) {
			context.Set<T>().AddOrUpdate(item);
		}

		protected virtual void Dispose(bool disposing) {
			if (!disposedValue) {
				if (disposing) {
					// TODO: освободить управляемое состояние (управляемые объекты)
				}

				// TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить метод завершения
				// TODO: установить значение NULL для больших полей
				disposedValue = true;
			}
		}

		// // TODO: переопределить метод завершения, только если "Dispose(bool disposing)" содержит код для освобождения неуправляемых ресурсов
		// ~CustomRepository()
		// {
		//     // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
		//     Dispose(disposing: false);
		// }

		public void Dispose() {
			// Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}