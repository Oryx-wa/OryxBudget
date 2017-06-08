using Data.Infrastructure;
using Data.Repositories.OperatorsRepositories;
using Entities.Napims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OryxBudgetService.OperatorsServices
{
    public class NapimsContactService : BaseBudgetService<NapimsContact>
    {
        private readonly NapimsContactRepository _napimsRepository;

        public NapimsContactService(NapimsContactRepository napimsRepository, IBudgetUnitOfWork unitOfWork) 
            : base(napimsRepository, unitOfWork)
        {
            _napimsRepository = napimsRepository;
        }

        public override void Update(NapimsContact entity)
        {
            var contact = this.Get(entity.Id);
            base.Update(contact);
        }

        public IEnumerable<NapimsContact> GetByCommittee(int committee)
        {
            return this.GetAll().Where(info => (int)info.Committee == committee);
        }
    }
}
