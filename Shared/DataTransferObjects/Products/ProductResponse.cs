

namespace Shared.DataTransferObjects.Products
{
    // C# 9 
    public record ProductResponse
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string PictureUrl { get; set; } = default!;
        public decimal Price { get; set; }
        public string BrandName { get; set; } 
        public string TypeName { get; set; } 
    }


    //record => reference type
    // Equals Based on value
    // {public int myProperty { get; init; } }
}
