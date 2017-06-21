using Data.Infrastructure;
using Entities.Budgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Repositories;
using CsvHelper;
using OryxBudgetService.CsvMapping;
using Data.Repositories.BudgetsRepositories;
using OryxBudgetService.Utilties;
using Data.Repositories.OperatorsRepositories;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using OryxBudgetService.Utilities.SignalRHubs;
using OryxSecurity.Services;
using Entities.Budgets.WorkPrograms;

namespace OryxBudgetService.BudgetsServices
{
    public class BudgetService : BaseBudgetService<Budget>
    {
        private readonly BudgetRepository _repository;
        private readonly BudgetLineRepository _lineRepository;
        private readonly BudgetCodeService _budgetCodeService;
        private readonly LineCommentRepository _lineCommentRepository;
        private readonly OperatorRepository _operatorRepository;
        private readonly IConnectionManager _connectionManager;
        private readonly AttachmentRepository _attachmentRepository;
        protected IUserResolverService _userResolverService;
        private readonly BudgetLineStatusHistoryRepository _lineStatus;
        private readonly ActualsRepository _actualRepository;

        public BudgetService(BudgetRepository repository, BudgetCodeService budgetCodeService,
            BudgetLineRepository lineRepository, IBudgetUnitOfWork unitOfWork, LineCommentRepository lineCommentRepository,
            OperatorRepository operatorRepository, AttachmentRepository attachmentRepository, BudgetLineStatusHistoryRepository lineStatus,
            IConnectionManager signalRConnectionManager, IUserResolverService userResolverService, 
            ActualsRepository actualRepository) : base(repository, unitOfWork)
        {
            _repository = repository;
            _lineRepository = lineRepository;
            _budgetCodeService = budgetCodeService;
            _lineCommentRepository = lineCommentRepository;
            _operatorRepository = operatorRepository;
            _attachmentRepository = attachmentRepository;
            _userResolverService = userResolverService;
            _lineStatus = lineStatus;
            _actualRepository = actualRepository;
        }

        public override void Update(Budget entity)
        {
            Budget dbBudget = this.Get(entity.Id);
            base.Update(dbBudget);

        }

        public IEnumerable<Budget> GetByPeriodId(string periodId)
        {
            return this.GetAll().Where(info => info.PeriodId == periodId);
        }

        public IEnumerable<Budget> GetByOperatorId(string operatorId)
        {
            return this.GetAll().Where(info => info.OperatorId == operatorId);
        }

        public IEnumerable<OperatorBudget> GetOperatorBudget(string id)
        {
            return _repository.GetOperatorBudget(id);


        }

        public void InitializeBudgetForAllOperators(string periodId, string description)
        {
            var operators = _operatorRepository.GetAll()
                .Where(o => o.Status.Equals("A")).ToList();

            foreach (var op in operators)
            {
                var budget = new Budget
                {
                    CreateDate = DateTime.Now,
                    Description = op.Name + "_" + description,
                    OperatorId = op.Id.ToString(),
                    PeriodId = periodId,
                    Status = "A",
                    OpBudgetFC = 0,
                    UpdateDate = DateTime.Now,
                    UserSign = "e317f2dc-deb1-4463-8b67-7f435211d652",
                    OpBudgetLC = 0,
                    OpBudgetUSD = 0,
                    OpActualFC = 0,
                    OpActualLC = 0,
                    OpActualUSD = 0
                };

                base.Add(budget);
                base.SaveChanges();
            }
        }

        public void UploadBudget(string fileName, Guid id, string userId)
        {
            var file = System.IO.File.OpenRead(fileName);
            System.IO.TextReader dataFile = new System.IO.StreamReader(file);

            var csv = new CsvReader(dataFile);
            csv.Configuration.RegisterClassMap<BudgetLineMapping>();

            var records = csv.GetRecords<BudgetLine>().ToList();

            var budget = this.Get(id);
            decimal totalUSD = budget.OpBudgetUSD;
            decimal totalLC = budget.OpBudgetLC;
            decimal total = budget.OpBudgetFC;

            foreach (var item in records)
            {
                var code = _budgetCodeService.GetByBudgetCodeByCode(item.Code);
                if (!code.Postable.Trim().Equals("Y"))
                {
                    continue;
                }
                item.Code = item.Code.Trim();
                item.Description = (item.Description.Trim().Length > 99) ? item.Description.Trim().Substring(0, 99) : item.Description.Trim();
                item.UserSign = userId;
                item.UpdateDate = System.DateTime.Now;
                item.CreateDate = System.DateTime.Now;
                item.OpBudgetFC = item.OpBudgetLCInUSD + item.OpBudgetUSD;
                budget.BudgetLines.Add(item);
                totalLC += item.OpBudgetLC;
                totalUSD += item.OpBudgetUSD;
                total += item.OpBudgetFC;

            };

            budget.OpBudgetLC = totalLC;
            budget.OpBudgetUSD = totalUSD;
            budget.OpBudgetFC = total;

            base.Update(budget, userId);
            this.SaveChanges();
            dataFile.Dispose();
            file.Dispose();
            GC.Collect();

            System.IO.File.Delete(fileName);
            //var hubContext = _connectionManager.GetHubContext<NotificationHub>();
            //hubContext.Clients.All.

        }

        public void UploadActual(string fileName, Guid id)
        {
            var file = System.IO.File.OpenRead(fileName);
            System.IO.TextReader dataFile = new System.IO.StreamReader(file);

            var csv = new CsvReader(dataFile);
            csv.Configuration.RegisterClassMap<BudgetActualMapping>();

            var records = csv.GetRecords<Actual>().ToList();

            var budget = this.Get(id);
            decimal totalUSD = budget.OpActualUSD;
            decimal totalLC = budget.OpActualLC;
            decimal total = budget.OpActualFC;

            foreach (var item in records)
            {
                var code = _budgetCodeService.GetByBudgetCodeByCode(item.Code);
                if (!code.Postable.Trim().Equals("Y"))
                {
                    continue;
                }
                item.Code = item.Code.Trim();
                item.Description = (item.Description.Trim().Length > 99) ? item.Description.Trim().Substring(0, 99) : item.Description.Trim();
                item.UserSign = "e317f2dc-deb1-4463-8b67-7f435211d652";
                item.UpdateDate = System.DateTime.Now;
                item.CreateDate = System.DateTime.Now;

                budget.Actuals.Add(item);
                totalLC += item.OpActualLC;
                totalUSD += item.OpActualUSD;
                total += item.OpActualLCInUSD + item.OpActualUSD;

            };

            budget.OpActualLC = totalLC;
            budget.OpActualUSD = totalUSD;
            budget.OpActualFC = total;

            base.Update(budget);
            this.SaveChanges();
            dataFile.Dispose();
            file.Dispose();
            GC.Collect();

            System.IO.File.Delete(fileName);

        }

        public IEnumerable<Budget> GetAllIncluding()
        {
            return _repository.AllIncluding(c => c.BudgetLines, c => c.Actuals).ToList();
        }

        public Budget GetAllIncluding(Guid id, bool noTracking = false)
        {
            if (noTracking)
            {
                return _repository.AllIncludingNoTracking(c => c.BudgetLines).Where(c => c.Id == id).FirstOrDefault();
            }
            else
            {
                return _repository.AllIncluding(c => c.BudgetLines).Where(c => c.Id == id).FirstOrDefault();
            }

        }

        public IEnumerable<BudgetCodeView> GetBudgetDetails(string id, string department)
        {


            if (department == "All")
            {
                return _repository.GetBudgetLines(id); 
            }
            else
            {
                Enum.TryParse(department, out WorkProgramTypeEnum  type);

                return _repository.GetBudgetLines(id).Where(b => b.Type == type || b.Type == WorkProgramTypeEnum.Header);
            }

        }

        public IEnumerable<LineComment> GetLineComment(string id, string code)
        {
            return _lineCommentRepository.GetAll().Where(c => c.BudgetId.ToString() == id && c.Code == code);
        }

        public void AddLineComments(IEnumerable<LineComment> lineComments)
        {
            var roleList = _userResolverService.GetRoles();
            string userType = "";
            string userName = _userResolverService.GetUserName();
            BudgetStatus bdStatus = BudgetStatus.SubCom;
            foreach (var item in roleList)
            {
                if (item.ToLower() == "napims")
                {
                    userType = item.ToLower();
                }

                if (item.ToLower() == "operator")
                {
                    userType = item.ToLower();
                }
                if (item.EndsWith("Com"))
                {
                    Enum.TryParse(item, out BudgetStatus bdStatusOut );
                    bdStatus = bdStatusOut;
                }              
                
            }
            foreach (var item in lineComments)
            {
                item.UserType = userType;
                item.CommentType = bdStatus;
                item.UserName = userName;
                if (item.Id == Guid.Empty)                {
                    
                    this._lineCommentRepository.Add(item);
                }
                else
                {                    
                    this._lineCommentRepository.Update(item);
                }

            }
        }

        public void updateStatus(string status, string Code, string BudgetId)
        {
            var roleList = _userResolverService.GetRoles();
            string userType = "";
            string userName = _userResolverService.GetUserName();
            BudgetStatus bdStatus = BudgetStatus.SubCom;
            foreach (var item in roleList)
            {
                if (item.ToLower() == "napims")
                {
                    userType = item.ToLower();
                }

                if (item.ToLower() == "operator")
                {
                    userType = item.ToLower();
                }
                if (item.EndsWith("Com"))
                {
                    Enum.TryParse(item, out BudgetStatus bdStatusOut);
                    bdStatus = bdStatusOut;
                }

            }

            Enum.TryParse(status, out CommentStatus cStatus);
            BudgetLineStatusHistory statusHistory = new BudgetLineStatusHistory();
            statusHistory.ItemCodeStatus = cStatus;
            statusHistory.ItemStatus = bdStatus;
            statusHistory.Code = Code;
            statusHistory.BudgetId = BudgetId;
            _lineStatus.Add(statusHistory);
        }

        public IEnumerable<BudgetLineStatusHistory> GetLineStatus(string BudgetId, string Code)
        {
            return _lineStatus.GetAll()
                .Where(l => l.Code == Code && l.BudgetId.ToString() == BudgetId)
                .OrderByDescending(l=> l.CreateDate);
        }

        public void UpdateAttachment(Attachment entity)
        {
            var attachment = this.Get(entity.Id);
            _attachmentRepository.Update(entity);
        }

        public void AddAttachment(Attachment entity)
        {
            _attachmentRepository.Add(entity);
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

        public void UpdateOperatorActuals(DateTime startDate, DateTime endDate, BudgetLine lineEntity, Attachment attachment)
        {
            // Update Actuals
            var budgetLine = _repository.Get(lineEntity.Id);

            //if (budgetLine != null)
            //{
            //    budgetLine.OpActualLC = lineEntity.OpActualLC;
            //    budgetLine.OpActualUSD = lineEntity.OpActualUSD;
            //    budgetLine.OpActualFC = lineEntity.OpActualFC;
            //}

            var actual = new Actual
            {
                PeriodStart = startDate,
                PeriodEnd = endDate,
                Code = lineEntity.Code,
                Description = lineEntity.Description,
                OpActualLC = lineEntity.OpActualFC,
                OpActualUSD = lineEntity.OpActualUSD,
                OpActualLCInUSD = lineEntity.OpActualFC,
                BudgetId = lineEntity.BudgetId,
                BudgetLineId = lineEntity.Id
            };

            _actualRepository.Add(actual);
            //Insert Attachments here
            AddAttachment(attachment);
            
            base.SaveChanges();
        }
    }


}
