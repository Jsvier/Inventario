using Microsoft.AspNetCore.Identity;

namespace api_inventory.Model {
  public class AppUser : IdentityUser {
    public string Name { get; set; }
    public string NickName { get; set; }
    public string FamilyName { get; set; }
    public long? FacebookId { get; set; }
    public long? GoogleId { get; set; }
    public string PictureUrl { get; set; }

  }
}