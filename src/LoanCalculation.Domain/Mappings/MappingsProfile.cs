using AutoMapper;
using LoanCalculation.Domain.Dtos;
using LoanCalculation.Domain.Models;

namespace LoanCalculation.Domain.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<LoanParameterDtos, LoanConfiguration>()
                .ForMember(e => e.DurationInMonths, opts => opts.MapFrom(e => e.DurationInYears * 12));

            CreateMap<LoanTermDtos, LoanConfiguration>()
                .ForMember(e => e.AnnualInterestRate, opts => opts.MapFrom(e => e.AnnualInterestRate / 100.0M / 12.0M))
                .ForPath(e => e.PercentageAdminFee, opts => opts.MapFrom(e => e.AdministrationFee.Percentage.Value / 100M))
                .ForPath(e => e.MaxAdminFee, opts => opts.MapFrom(e => e.AdministrationFee.MinimalAmount.Value));
        }
    }
}
