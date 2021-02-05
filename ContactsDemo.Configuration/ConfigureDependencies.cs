using AutoMapper;
using ContactsDemo.Domain.Interfaces;
using ContactsDemo.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ContactsDemo.Configuration
{
    public static class ConfigureDependencies
    {
        public static void BuildDependencies(IServiceCollection services)
        {
            services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));

            services.AddSingleton(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddSingleton(typeof(IContactRepository), typeof(ContactRepository));
        }
    }
}
