using Cooperchip.ITDeveloper.Data.ORM;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Cooperchip.ITDeveloper.Mvc.Extentions.ViewComponents.Helpers
{
    public static class Util
    {
        public static int TotReg(ITDeveloperDbContext ctx)
        {
            var paciente = from pac in ctx.Paciente.AsNoTracking() select pac;
            //return (from pac in ctx.Paciente.AsNoTracking() select pac).Count();
            if (paciente.Any())
            {
                return paciente.Count();
            }
            return 1;
        }

        public static decimal GetNumRegEstado(ITDeveloperDbContext ctx, string estado)
        {
            return ctx.Paciente.AsNoTracking()
                .Count(x => x.EstadoPaciente.Descricao.Contains(estado));
        }

    }
}
