using System.ComponentModel;

namespace ArqLimpaDDD.Domain.Entities;

public enum UserRolesEnum
{
    [Description("Administrador")]
    Administrator = 1,
    [Description("Analista")]
    VendasAnalyst = 2,
    [Description("Vendedor")]
    Seller = 3,
    [Description("Analista de compras")]
    PurchaseAnalyst = 4,
    [Description("Analista Financeiro")]
    FinancialAnalyst = 5,
    [Description("Gerente")]
    StoreManager = 6,
    [Description("Analista de Operacoes")]
    OperationsAnalyst = 7,
}