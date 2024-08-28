﻿using Microsoft.EntityFrameworkCore;
using P_Asignación_de_Tareas.Dto;
using P_Asignación_de_Tareas.Models;

namespace P_Asignación_de_Tareas.Operaciones
{
    public class ProyectsOperations
    {
        public ApplicationDbcontext _context;

        public ProyectsOperations(ApplicationDbcontext context)
        {
            _context = context;
        }

        public async Task<List<Proyects>> GetProyects()
        {
            var result = await _context.Proyects.AsNoTracking().ToListAsync();

            return result;
        }

        public async Task<Proyects> GetProyect(int idproyect)
        {
            var result = await _context.Proyects.FindAsync(idproyect);

            return result;
        }

        public async Task<Proyects> CreateProyect(Proyects proyects)
        {
            var result = await _context.Proyects.AddAsync(proyects);

            await _context.SaveChangesAsync();

            return proyects;
        }

        public async Task<bool> UpdateProyect(ProyectsDto proyectsDto)
        {
            Proyects? proyects = await _context.Proyects.FindAsync(proyectsDto.idProyect);
            if (proyects != null)
            {
                proyects.nameProyect = proyectsDto.nameProyect;
                proyects.idTasks = proyectsDto.idTasks;

                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> DeleteProyect(int idproyect)
        {
            var result = await _context.Proyects.FindAsync(idproyect);
            if (result == null)
            {
                return false;
            }
            _context.Proyects.Remove(result);

            await _context.SaveChangesAsync();

            return true;

        }
    }
}
