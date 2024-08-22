using Microsoft.EntityFrameworkCore;
using P_Asignación_de_Tareas.Models;

namespace P_Asignación_de_Tareas.Operaciones
{
    public class AuxiliarTOperations
    {
        public ApplicationDbcontext _dbcontext;

        public AuxiliarTOperations(ApplicationDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<AuxiliarT>> GetAuxiliarT()
        {
            var result = await _dbcontext.AuxiliarTs.AsNoTracking().ToListAsync();

            return result;
        }

        public async Task<AuxiliarT> GetAuxiliar(int idAuxiliar)
        {
            var result = await _dbcontext.AuxiliarTs.FindAsync(idAuxiliar);

            return result;
        }

        public async Task<AuxiliarT> CreateAuxiliarT(AuxiliarT AuxiliarT)
        {
            var user = await _dbcontext.AuxiliarTs.AddAsync(AuxiliarT);

            await _dbcontext.SaveChangesAsync();

            return AuxiliarT;
        }
    }
}
