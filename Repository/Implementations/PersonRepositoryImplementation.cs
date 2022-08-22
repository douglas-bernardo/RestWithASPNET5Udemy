using System.Collections.Generic;
using System.Linq;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        private MySQLContext _context;

        public PersonRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }

        List<Person> IPersonRepository.FindAll()
        {
            return _context.Persons.ToList();
        }

        Person IPersonRepository.Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
                return person;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        Person IPersonRepository.FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        Person IPersonRepository.Update(Person person)
        {
            if (!Exists(person.Id)) return new Person();

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
            return person;
        }

        void IPersonRepository.Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }

        }

        public bool Exists(long id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}