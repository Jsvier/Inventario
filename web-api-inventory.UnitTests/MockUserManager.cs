// using System;
// using api_inventory.Models;
// using Microsoft.Extensions.Options;
// using Microsoft.Extensions.Logging;
// using NSubstitute;

// namespace api_inventory.UnitTests
// {
//     public static class MockUserManager
//     {
//         public static UserManager Create()
//         {
//             return Substitute.For<UserManager<ApplicationUser>>(
//                 Substitute.For<IUserStore<ApplicationUser>>(),
//                 Substitute.For<IOptions<IdentityOptions>>(),
//                 Substitute.For<IPasswordHasher<ApplicationUser>>(),
//                 new IUserValidator<ApplicationUser>[0],
//                 new IPasswordValidator<ApplicationUser>[0],
//                 Substitute.For<ILookupNormalizer>(),
//                 Substitute.For<IdentityErrorDescriber>(),
//                 Substitute.For<IServiceProvider>(),
//                 Substitute.For<ILogger<UserManager<ApplicationUser>>>());
//         }
//     }
// }
