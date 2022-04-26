using DYLHS5_HFT_2021221.Data;

namespace DYLHS5_HFT_2021221.Repository
{
    public class ShopRepository :IShopRepository
    {
        XYZDbContext ctx;
        public ShopRepository(XYZDbContext ctx)
        {
            this.ctx = ctx;
        }
    }
}
