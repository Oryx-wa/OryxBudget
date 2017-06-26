using Data.Infrastructure;
using Data.Repositories.BudgetsRepositories;
using Entities.Budgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OryxBudgetService.BudgetsServices
{
    public class AttachmentService : BaseBudgetService<Attachment>
    {
        private readonly AttachmentRepository _attachmentRepository;

        public AttachmentService(AttachmentRepository attachmentRepository, IBudgetUnitOfWork unitOfWork)
            : base(attachmentRepository, unitOfWork)
        {
            _attachmentRepository = attachmentRepository;
        }

        public override void Update(Attachment entity)
        {
            var attachment = this.Get(entity.Id);
            base.Update(entity);
        }

        public Attachment GetAttachment(Guid id)
        {
            return _attachmentRepository.Get(id);
        }

        public IEnumerable<Attachment> GetAttachments()
        {
            return _attachmentRepository.GetAll();
        }

        public IEnumerable<Attachment> GetAttachmentsByBudgetLine(string lineId)
        {
            return _attachmentRepository.GetAll().Where(a => a.BudgetLineId.ToString() == lineId);
        }

        //public void AddAttachment(string fileName, byte[] fileBytes, string type)
        //{

        //}
    }
}
