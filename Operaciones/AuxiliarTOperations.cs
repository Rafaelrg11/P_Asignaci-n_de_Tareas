using Microsoft.EntityFrameworkCore;
using P_Asignación_de_Tareas.Dto;
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

        public async Task<List<AuxiliarT>> GetAuxiliars()
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


        public async Task<bool> UpdateAuxiliar(AuxiliarTDto auxiliarTDto)
        {
            AuxiliarT? auxiliarT = await _dbcontext.AuxiliarTs.FindAsync(auxiliarTDto.idAuxiliar);
            if (auxiliarT != null)
            {
                auxiliarT.idCommet = auxiliarTDto.idCommet;
                auxiliarT.idProyect = auxiliarTDto.idProyect;
                auxiliarT.idNotification = auxiliarTDto.idNotification;
                auxiliarT.idUser = auxiliarTDto.idUser;

                await _dbcontext.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> DeleteAuxiliar(int idAuxiliar)
        {
            var result = await _dbcontext.AuxiliarTs.FindAsync(idAuxiliar);
            if (result == null)
            {
                return false;
            }
            _dbcontext.AuxiliarTs.Remove(result);

            await _dbcontext.SaveChangesAsync();

            return true;
        }
    }
}
