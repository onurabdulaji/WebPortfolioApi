using WebPortfolioApi.Domain.Commons.Concretes;

namespace WebPortfolioApi.Domain.Entities;

class Service : EntityBase
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Icon { get; set; }
    public Service()
    {

    }
    public Service(string title, string description, string icon)
    {
        Title = title;
        Description = description;
        Icon = icon;
    }
}
