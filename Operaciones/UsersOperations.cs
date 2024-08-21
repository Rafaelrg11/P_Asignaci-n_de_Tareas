using Microsoft.EntityFrameworkCore;
using P_Asignación_de_Tareas.Dto;
using P_Asignación_de_Tareas.Models;

namespace P_Asignación_de_Tareas.Operaciones
{
    public class UsersOperations
    {
        public ApplicationDbcontext _dbcontext;
        public UsersOperations(ApplicationDbcontext dbContext) 
        {
            _dbcontext = dbContext;
        }

        public async Task<List<Users>> GetUsers()
        {
            var user = await _dbcontext.Users.AsNoTracking().ToListAsync();

            return user;
        }

        public async Task<Users> GetUser(int iduser)
        {
            var user = await _dbcontext.Users.FindAsync(iduser);

            return user;
        }

        public async Task<Users> CreateUser(Users users)
        {
            var user = await _dbcontext.Users.AddAsync(users);

            await _dbcontext.SaveChangesAsync();

            return users;
        }

        public async Task<AuxiliarT> CreateAuxiliarT(AuxiliarT AuxiliarT)
        {
            var user = await _dbcontext.AuxiliarTs.AddAsync(AuxiliarT);

            await _dbcontext.SaveChangesAsync();

            return AuxiliarT;
        }

        public async Task<bool> UpdateUser(UsersDto usersDto)
        {
            Users? users = await _dbcontext.Users.FindAsync(usersDto);

            if (users != null) 
            {
                users.nameUser = usersDto.nameUser;
                users.emailUser = usersDto.emailUser;
                users.password = usersDto.password;

                await _dbcontext.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> DeleteUser(int iduser)
        {
            var result = await _dbcontext.Users.FindAsync(iduser);
            if (result == null)
            {
                return false;
            }

            _dbcontext.Users.Remove(result);

            await _dbcontext.SaveChangesAsync();

            return true;

        }
    }
}
