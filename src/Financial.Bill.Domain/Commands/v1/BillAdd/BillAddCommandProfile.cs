using AutoMapper;

namespace Financial.Bill.Domain.Commands.v1.BillAdd
{
    public class BillAddCommandProfile : Profile
    {
        public BillAddCommandProfile()
        {
            CreateMap<BillAddCommand, Entities.v1.Bill>()
                .ForPath(dest => dest.PaymentMode.CardId, config => config.MapFrom(src => src.CardId))
                .ForPath(dest => dest.PaymentMode.FinancialSourceId, config => config.MapFrom(src => src.FinancialSourceId))
                .ForPath(dest => dest.PaymentMode.EffectiveDate, config => config.MapFrom(src => src.EffectiveDate))
                .ForPath(dest => dest.PaymentMode.Installments, config => config.MapFrom(src => src.InstallmentsPayment))
                .ForPath(dest => dest.PaymentMode.PaymentType, config => config.MapFrom(src => src.PaymentType))
                .ForPath(dest => dest.FixedBill.BaseValue, config => config.MapFrom(src => src.BaseFixedValue))
                .ForPath(dest => dest.FixedBill.DueDay, config => config.MapFrom(src => src.DueDay))
                .ForPath(dest => dest.FixedBill.Installments, config => config.MapFrom(src => src.InstallmentsFixedBill))
                .ForPath(dest => dest.FixedBill.MonthlyConfirmation, config => config.MapFrom(src => src.MonthlyConfirmation));
        }
    }
}