﻿using WebPortfolioApi.Domain.Commons.Concretes;

namespace WebPortfolioApi.Domain.Entities;

class Contact : EntityBase
{
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Map { get; set; }
    public Contact() { }
    public Contact(string? address, string? phone, string? email, string? map)
    {
        Address = address;
        Phone = phone;
        Email = email;
        Map = map;
    }
}
