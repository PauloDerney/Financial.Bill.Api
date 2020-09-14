using System.ComponentModel;

namespace Financial.Bill.Domain.Enums.v1
{
    public enum ExpenseType
    {
        [Description("Alimentação")]
        Food = 1,
        [Description("Saúde")]
        Health,
        [Description("Habilidade")]
        Skill,
        [Description("Educação")]
        Education,
        [Description("Conta de Agua")]
        Water,
        [Description("Energia Eletrica")]
        Electricity,
        [Description("Internet")]
        Internet,
        [Description("Alimentação Extra")]
        ExtraFood,
        [Description("Transporte")]
        Transport,
        [Description("Gasto no Apartamento")]
        Apartment,
        [Description("Financiamento Apartamento")]
        Financing,
        [Description("Entretenimento")]
        Entertainment,
        [Description("Lazer")]
        Recreation,
        [Description("Rolê")]
        Spree,
        [Description("Viagem")]
        Travel,
        [Description("Imposto")]
        Tribute,
        [Description("Contas PJ")]
        PJ,
        [Description("Outros")]
        Others
    }
}
