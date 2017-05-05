using Data.Infrastructure;
using Data.Repositories;
using Entities.Operators;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OryxBudgetService.OperatorsServices
{
   public class ContactPersonService: BaseBudgetService<ContactPerson>
    {
        private readonly IBaseLogBudgetRepository<ContactPerson, ContactPersonLog, Guid> _repository;

        public ContactPersonService(IBaseLogBudgetRepository<ContactPerson, ContactPersonLog, Guid> repository, IBudgetUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
        }

        public override void Update(ContactPerson entity)
        {
            ContactPerson dbContactPersons = this.Get(entity.Id);



            base.Update(dbContactPersons);

        }

        public IEnumerable<ContactPerson> GetByContactPersonsId(string OperatorId)
        {
            return this.GetAll().Where(info => info.OperatorId == OperatorId);
        }


    }
}
