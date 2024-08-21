using Microsoft.EntityFrameworkCore;
using P_Asignación_de_Tareas.Dto;
using P_Asignación_de_Tareas.Models;

namespace P_Asignación_de_Tareas.Operaciones
{
    public class OperacionesOperation
    {
        public ApplicationDbcontext _context;
        public OperacionesOperation(ApplicationDbcontext dbcontext) 
        {
            _context = dbcontext;
        }
        public async Task<List<Models.Operaciones>> GetOperaciones()
        {
            var result = await _context.Operations.AsNoTracking().ToListAsync();    
            
            return result;
        }

        public async Task<Models.Operaciones> GetOperation(int idOperation)
        {
            var result = await _context.Operations.FindAsync(idOperation);

            return result;
        }

        public async Task<Models.Operaciones> CreateOperations(Models.Operaciones operations)
        {
            var result =  await _context.Operations.AddAsync(operations);

            await _context.SaveChangesAsync();

            return operations;
        }

        public async Task<bool> UpdateOperation(OperacionesDto operations)
        {
            Models.Operaciones? ope = await _context.Operations.FindAsync(operations);
            if (ope != null) 
            {
                ope.IdOperaciones = operations.IdOperaciones;
                ope.IdRol = operations.IdRol;

                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> DeleteOperaion(int idOperation)
        {
            var result = await _context.Operations.FindAsync(idOperation);
            if (result == null) 
            {
                return false;
            }
            _context.Operations.Remove(result);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
