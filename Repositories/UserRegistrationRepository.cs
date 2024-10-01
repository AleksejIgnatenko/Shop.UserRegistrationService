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

        public async Task<UserRegistrationEntity> GetByIdUserRegistration(Guid id)
        {
            var registeredUsers = await _context.UserRegistrations.FirstOrDefaultAsync(u => u.Id == id);
            if(registeredUsers != null)
            {
                return registeredUsers;
            }
            throw new Exception("Error retrieving user registration information");
        }
    }
}
