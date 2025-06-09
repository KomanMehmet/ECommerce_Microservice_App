using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.IdentityStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/Statistic")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;
        private readonly ICommentStatisticService _commentStatisticService;
        private readonly IDiscountStatisticService _discountStatisticService;
        private readonly IMessageStatisticService _messageStatisticService;
        private readonly IIdentityStatisticService _identityStatisticService;

        public StatisticController(ICatalogStatisticService catalogStatisticService,
            ICommentStatisticService commentStatisticService, IDiscountStatisticService discountStatisticService,
            IMessageStatisticService messageStatisticService, IIdentityStatisticService identityStatisticService)
        {
            _catalogStatisticService = catalogStatisticService;
            _commentStatisticService = commentStatisticService;
            _discountStatisticService = discountStatisticService;
            _messageStatisticService = messageStatisticService;
            _identityStatisticService = identityStatisticService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            #region Catalog Statistics
            var totalBrandsCount = await _catalogStatisticService.GetTotalBrandsAsync();

            ViewBag.TotalBrands = totalBrandsCount;

            var maxPriceProductName = await _catalogStatisticService.GetMaxPriceProductsName();

            ViewBag.MaxPriceProductName = maxPriceProductName;

            var minPriceProductName = await _catalogStatisticService.GetMinPriceProductsName();

            ViewBag.MinPriceProductName = minPriceProductName;

            var productAvgPrice = await _catalogStatisticService.GetProductAvgPriceAsync();

            ViewBag.ProductAvgPrice = productAvgPrice;

            var totalCategoriesCount = await _catalogStatisticService.GetTotalCategoriesAsync();

            ViewBag.TotalCategories = totalCategoriesCount;

            var totalProductsCount = await _catalogStatisticService.GetTotalProductsAsync();

            ViewBag.TotalProducts = totalProductsCount;

            #endregion

            #region Comment Statistics
            var activeCommentCount = await _commentStatisticService.GetActiveCommentCountAsync();

            ViewBag.ActiveCommentCount = activeCommentCount;

            var passiveCommentCount = await _commentStatisticService.GetPassiveCommentCountAsync();

            ViewBag.PassiveCommentCount = passiveCommentCount;

            var totalCommentCount = await _commentStatisticService.GetTotalCommentCountAsync();

            ViewBag.TotalCommentCount = totalCommentCount;
            #endregion

            #region Discount Statistics
            var totalDiscountCouponCount = await _discountStatisticService.GetDiscountCouponCountAsync();

            ViewBag.TotalDiscountCouponCount = totalDiscountCouponCount;
            #endregion

            #region Message Statistics
            var totalMessageCount = await _messageStatisticService.GetTotalMessageCountAsync();

            ViewBag.TotalMessageCount = totalMessageCount;
            #endregion

            #region Identity Statistics
            var totalUserCount = await _identityStatisticService.GetTotalUserCountAsync();

            ViewBag.TotalUserCount = totalUserCount;
            #endregion

            return View();
        }
    }
}
