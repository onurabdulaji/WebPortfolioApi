using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPortfolioApi.Domain.Commons.Concretes;

namespace WebPortfolioApi.Domain.Entities;

public class Stat : EntityBase
{
    public int? Client { get; set; }
    public int? Project { get; set; }
    public int? Support { get; set; }
    public int? Worker { get; set; }
    public Stat()
    {

    }
    public Stat(int client, int project, int support, int worker)
    {
        Client = client;
        Project = project;
        Support = support;
        Worker = worker;
    }
}
