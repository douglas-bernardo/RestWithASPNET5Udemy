using System.Collections.Generic;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private IPersonRepository _repository;

        public PersonBusinessImplementation(IPersonRepository repository)
        {
            _repository = repository;
        }

        List<Person> IPersonBusiness.FindAll()
        {
            return _repository.FindAll();
        }

        Person IPersonBusiness.Create(Person person)
        {
            return _repository.Create(person);
        }

        Person IPersonBusiness.FindById(long id)
        {
            return _repository.FindById(id);
        }

        Person IPersonBusiness.Update(Person person)
        {
            return _repository.Update(person);
        }

        void IPersonBusiness.Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}