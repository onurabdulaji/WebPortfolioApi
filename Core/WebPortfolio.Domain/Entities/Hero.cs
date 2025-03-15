using WebPortfolioApi.Domain.Commons.Concretes;

namespace WebPortfolioApi.Domain.Entities;

class Hero : EntityBase
{
    public string? Title { get; set; }
    public string? SubTitle { get; set; }
    public string? BackgroundImageUrl { get; set; }
    public Hero() { }
    public Hero(string? title, string? subTitle, string? backgroundImageUrl)
    {
        Title = title;
        SubTitle = subTitle;
        BackgroundImageUrl = backgroundImageUrl;
    }
}
