namespace InfoCenter.Api.Models;

public class ArticleDetail
{
    public int Id { get; set; }

    public decimal Price { get; set; } = 0;
    public bool IsActive { get; set; } = true;

    public int ArticleId { get; set; }
    public Article Article { get; set; } = null!;

    public int ContractId { get; set; }
    public Contract Contract { get; set; } = null!;

    public int CurrencyId { get; set; }
    public Currency Currency { get; set; } = null!;

}