using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Observer_Design_Pattern.DAL.Entities;
using System;

namespace Observer_Design_Pattern.ObserverDesignPattern
{
    public class UserObserverWriterToConsole : IUserObserver
    {
        private readonly IServiceProvider _serviceProvider;
        public UserObserverWriterToConsole(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public void CreateUser(AppUser appUser)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverWriterToConsole>>();
            logger.LogInformation($"{appUser.Id + " nolu" + appUser.Name + " " + appUser.Surname} isimli kullanıcı sisteme kayıt edildi");
            //1 nolu Mustafa Tuç isimli kullanıcı sisteme kayıt edildi
        }

    }
}
