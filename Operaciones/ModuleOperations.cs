using Microsoft.EntityFrameworkCore;
using P_Asignación_de_Tareas.Dto;
using P_Asignación_de_Tareas.Models;

namespace P_Asignación_de_Tareas.Operaciones
{
    public class ModuleOperations
    {
        public ApplicationDbcontext _context;
        public ModuleOperations(ApplicationDbcontext dbcontext)
        {
            _context = dbcontext;
        }

        public async Task<List<Module>> GetModules()
        {
            var result = await _context.Modules.AsNoTracking().ToListAsync();

            return result;
        }

        public async Task<Module> GetModule(int idModule)
        {
            var result = await _context.Modules.FindAsync(idModule);

            return result;
        }

        public async Task<Module> CreateModule(Module module)
        {
            var result = await _context.Modules.AddAsync(module);

            await _context.SaveChangesAsync();

            return module;
        }

        public async Task<bool> UpdateModule(ModuleDto moduleDto)
        {
            Module? module = await _context.Modules.FindAsync(moduleDto);
            if (module != null)
            {
                module.NameMod = moduleDto.NameMod;

                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> DeleteModule(int idModule)
        {
            var result = await _context.Modules.FindAsync(idModule);
            if (result != null)
            {
                return false;
            }
            _context.Modules.Remove(result);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
