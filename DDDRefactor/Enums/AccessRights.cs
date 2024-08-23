
namespace DDDRefactor.Enums
{
    [Flags]
    public enum AccessRights
    {
        None = 0,
        Requests = 1,
        Registry = 2,
        Finances = 4,
        Production = 8,
        Orders = 16,
        Administration = 32,
        FullAccess = Requests | Registry | Finances | Production | Orders | Administration
    }
}