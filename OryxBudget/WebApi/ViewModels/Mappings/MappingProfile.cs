using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Budgets;
using OryxWebApi.ViewModels.BudgetsViewModels;
using OryxWebApi.ViewModels.OperatorsViewModels;
using Entities.Operators;

namespace OryxWebapi.ViewModels.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          

            CreateMap<BudgetViewModel, Budget>();
            CreateMap<Budget, BudgetViewModel>();


            CreateMap<BudgetLineViewModel, BudgetLine>();
            CreateMap<BudgetLine, BudgetLineViewModel>();

            CreateMap<LineCommentViewModel, LineComment>();
            CreateMap<LineComment, LineCommentViewModel>();

            CreateMap<PeriodViewModel, Period>();
            CreateMap<Period, PeriodViewModel>();

            CreateMap<CategoryViewModel, Category>();
            CreateMap<Category, CategoryViewModel>();

            //Operators
            CreateMap<OperatorViewModel, Operator>();
            CreateMap<Operator, OperatorViewModel>();

            CreateMap<OperatorTypeViewModel, OperatorType>();
            CreateMap<OperatorType, OperatorTypeViewModel>();


            CreateMap<BudgetViewModel, Budget>().ReverseMap();
            CreateMap<Budget, BudgetViewModel>().ReverseMap();

            CreateMap<BudgetLineViewModel, BudgetLine>().ReverseMap();
            CreateMap<BudgetLine, BudgetLineViewModel>().ReverseMap();

            CreateMap<PeriodViewModel, Period>().ReverseMap();
            CreateMap<Period, PeriodViewModel>().ReverseMap();

            CreateMap<LineCommentViewModel, LineComment>().ReverseMap();
            CreateMap<LineComment, LineCommentViewModel>().ReverseMap();

            CreateMap<CategoryViewModel, Category>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();


            CreateMap<BudgetRunViewModel, BudgetRun>().ReverseMap();
            CreateMap<BudgetRun, BudgetRunViewModel>().ReverseMap();


            CreateMap<ActualViewModel, Actual>().ReverseMap();
            CreateMap<Actual, ActualViewModel>().ReverseMap();

            //Operator
            CreateMap<OperatorViewModel, Operator>().ReverseMap();
            CreateMap<Operator, OperatorViewModel>().ReverseMap();

            CreateMap<OperatorTypeViewModel, OperatorType>().ReverseMap();
            CreateMap<OperatorType, OperatorTypeViewModel>().ReverseMap();

        }
    }
}
