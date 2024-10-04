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

        public async Task<List<UserRegistrationModel>> GetAllUserRegistrationsAsync()
        {
            var userRegistrationEntity = await _context.UserRegistrations.ToListAsync();

            var userRegistrationModel = userRegistrationEntity.Select(u => UserRegistrationModel.Create(
                u.Id,
                u.LocationRegistration,
                u.DataRegistration
                )).ToList();

            return userRegistrationModel;
        }

        public async Task<UserRegistrationModel> GetByIdUserRegistrationAsync(Guid id)
        {
            var userRegistrationEntity = await _context.UserRegistrations.FirstOrDefaultAsync(u => u.Id == id);
            if(userRegistrationEntity != null)
            {
                var userRegistrationModel = UserRegistrationModel.Create(
                userRegistrationEntity.Id,
                userRegistrationEntity.LocationRegistration,
                userRegistrationEntity.DataRegistration
                );

                return userRegistrationModel;
            }
            throw new Exception("Error retrieving user registration information");
        }
    }
}
