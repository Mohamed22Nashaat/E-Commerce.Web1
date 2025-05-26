

namespace Domain.Exceptions
{
    public sealed class BasketNotFoundException(string key)
        : NotFoundException($"Basket with id: {key} doesn't exist in the database.")
    {
    }
}
