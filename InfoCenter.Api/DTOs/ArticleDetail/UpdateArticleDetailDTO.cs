﻿using System.ComponentModel.DataAnnotations;

namespace InfoCenter.Api.DTOs.ArticleDetail;

public class UpdateArticleDetailDTO
{
    [Required]
    public int Id { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public int ArticleId { get; set; }

    [Required]
    public int ContractId { get; set; }

    [Required]
    public int CurrencyId { get; set; }

    [Required]
    public bool IsActive { get; set; }
}