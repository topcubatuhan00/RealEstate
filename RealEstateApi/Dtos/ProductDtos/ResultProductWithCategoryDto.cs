﻿namespace RealEstateApi.Dtos.ProductDtos;

public class ResultProductWithCategoryDto
{
    public int ProductId { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public int ProductCategory { get; set; }
    public string CategoryName { get; set; }
}
