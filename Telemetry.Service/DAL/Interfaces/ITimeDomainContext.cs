using System.Data.Entity;
using Telemetry.Service.DAL.Models;

namespace Telemetry.Service.DAL
{
    public interface ITimeDomainContext
    {
        DbSet<Temperature> Temperatures { get; set; }
    }
}