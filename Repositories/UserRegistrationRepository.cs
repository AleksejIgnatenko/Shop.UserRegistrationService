using Microsoft.EntityFrameworkCore;
using Shop.UserRegistrationService.Abstractions;
using Shop.UserRegistrationService.Entities;
using Shop.UserRegistrationService.Models;

namespace Shop.UserRegistrationService.Repositories
{
    public class UserRegistrationRepository : IUserRegistrationRepository
    {
        private readonly UserRegistrationDbContext _context;

        public UserRegistrationRepository(UserRegistrationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreatingUserRegistrationAsync(UserRegistrationModel userRegistrationModel)
        {
            var userRegistrationEntity = new UserRegistrationEntity
            {
                Id = userRegistrationModel.Id,
                Email = userRegistrationModel.Email,
                LocationRegistration = userRegistrationModel.LocationRegistration,
                DataRegistration = userRegistrationModel.DataRegistration
            };

            await _context.UserRegistrations.AddAsync(userRegistrationEntity);
            await _context.SaveChangesAsync();

            return userRegistrationEntity.Id;
        }

        public async Task<List<UserRegistrationEntity>> GetAllUserRegistrations()
        {
            var registeredUsers = await _context.UserRegistrations.ToListAsync();
            return registeredUsers;
        }

        public async Task<UserRegistrationEntity> GettingByIdUserRegistration(Guid id)
        {
            var registeredUsers = await _context.UserRegistrations.FirstOrDefaultAsync(u => u.Id == id);
            return registeredUsers;
        }

        public async Task<Guid> UpdateUserRegistrationAsync(UserRegistrationModel userRegistrationModel)
        {
            await _context.UserRegistrations
                .Where(u => u.Id == userRegistrationModel.Id)
                .ExecuteUpdateAsync(u => u
                .SetProperty(u => u.Email, userRegistrationModel.Email)
                );

            return userRegistrationModel.Id;
        }

        public async Task<Guid> DeleteUserRegistrationAsync(UserRegistrationModel userRegistrationModel)
        {
            await _context.UserRegistrations
                .Where(u => u.Id == userRegistrationModel.Id)
                .ExecuteDeleteAsync();

            return userRegistrationModel.Id;
        }
    }
}
