namespace InfoCenter.Api.DTOs.ArticleDetail;

public class ArticleDetailDTO
{
    public int Id { get; set; }

    public decimal Price { get; set; }
    public bool IsActive { get; set; }

    public int ArticleId { get; set; }

    public int ContractId { get; set; }

    public int CurrencyId { get; set; }
}