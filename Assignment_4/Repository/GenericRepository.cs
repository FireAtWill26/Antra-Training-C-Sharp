using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        public List<T> entities = new List<T>();
        public void Add(T entity)
        {
            entities.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return entities;
        }

        public T GetById(int id)
        {
            return entities[id];
        }

        public void Remove(T entity)
        {
            entities.Remove(entity);
        }

        public void Save()
        {
            for (int i = 0; i < entities.Count; i++)
            {
                Console.WriteLine($"ID: {entities[i].Id}, Name: {entities[i],Name}");
            }
        }
        
    }
}
