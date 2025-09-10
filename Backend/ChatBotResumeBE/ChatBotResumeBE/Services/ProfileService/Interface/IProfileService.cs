using ChatBotResumeBE.Util.Model;

namespace ChatBotResumeBE.Services.ProfileService.Interface
{
    public interface IProfileService
    {
        Task<Profile> GetAsync(Guid profileId);
        Task<Profile> CreateAsync(Profile profile);
        Task<Profile> UpdateAsync(Guid profileId, Profile profile);
        Task<bool> DeleteAsync(Guid profileId);
    }
}
