namespace Promotion.Repository
{
    public interface IPromotionRepository
    {
        decimal GetTotal(char[] product);
    }
}