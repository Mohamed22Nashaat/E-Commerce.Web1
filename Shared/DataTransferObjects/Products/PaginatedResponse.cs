

namespace Shared.DataTransferObjects.Products
{
    public record PaginatedResponse<TData>(int PageIndex, int PageSize, int TotalCount, IEnumerable<TData> Data)
    { 
    }
}
