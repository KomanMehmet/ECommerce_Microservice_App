namespace MultiShop.Catalog.Services.StatisticServices
{
    public interface IStatisticService
    {
        /// <summary>
        /// Gets the total number of products in the catalog.
        /// </summary>
        /// <returns>The total number of products.</returns>
        /// <remarks>
        /// Returns the count of all products available in the catalog.
        ///
        /// Example usage:
        /// long totalProducts = await statisticService.GetTotalProductsAsync();
        /// Console.WriteLine($"Total products: {totalProducts}");
        /// </remarks>
        Task<long> GetTotalProductsAsync();

        /// <summary>
        /// Gets the total number of categories in the catalog.
        /// </summary>
        /// <returns>The total number of categories.</returns>
        /// <remarks>
        /// Returns the count of all distinct product categories.
        ///
        /// Example usage:
        /// long totalCategories = await statisticService.GetTotalCategoriesAsync();
        /// Console.WriteLine($"Total categories: {totalCategories}");
        /// </remarks>
        Task<long> GetTotalCategoriesAsync();

        /// <summary>
        /// Gets the total number of brands in the catalog.
        /// </summary>
        /// <returns>The total number of brands.</returns>
        /// <remarks>
        /// Returns the count of all brands represented in the catalog.
        ///
        /// Example usage:
        /// long totalBrands = await statisticService.GetTotalBrandsAsync();
        /// Console.WriteLine($"Total brands: {totalBrands}");
        /// </remarks>
        Task<long> GetTotalBrandsAsync();

        /// <summary>
        /// Gets the average price of all products in the catalog.
        /// </summary>
        /// <returns>The average product price.</returns>
        /// <remarks>
        /// Calculates the average price by summing all product prices and dividing by the total number of products.
        /// Returns 0 if no products exist.
        ///
        /// Example usage:
        /// decimal averagePrice = await statisticService.GetProductAvgPriceAsync();
        /// Console.WriteLine($"Average price: {averagePrice:C}");
        /// </remarks>
        Task<decimal> GetProductAvgPriceAsync();

        /// <summary>
        /// Gets the name(s) of the product(s) with the highest price.
        /// </summary>
        /// <returns>The name or names of the most expensive product(s).</returns>
        /// <remarks>
        /// This method queries the products collection to find the product(s) with the maximum price and returns their name(s).
        /// If multiple products share the same maximum price, all their names may be returned, separated by commas or line breaks.
        ///
        /// Example usage:
        /// string maxPriceProductName = await statisticService.GetMaxPriceProductsName();
        /// Console.WriteLine($"Most expensive product(s): {maxPriceProductName}");
        /// </remarks>
        Task<string> GetMaxPriceProductsName();

        /// <summary>
        /// Gets the name(s) of the product(s) with the lowest price.
        /// </summary>
        /// <returns>The name or names of the cheapest product(s).</returns>
        /// <remarks>
        /// This method queries the products collection to find the product(s) with the minimum price and returns their name(s).
        /// If multiple products share the same minimum price, all their names may be returned, separated by commas or line breaks.
        ///
        /// Example usage:
        /// string minPriceProductName = await statisticService.GetMinPriceProductsName();
        /// Console.WriteLine($"Cheapest product(s): {minPriceProductName}");
        /// </remarks>
        Task<string> GetMinPriceProductsName();
    }
}
