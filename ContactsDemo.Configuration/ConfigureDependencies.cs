using AutoMapper;
using ContactsDemo.Domain.Interfaces;
using ContactsDemo.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ContactsDemo.Configuration
{
    public static class ConfigureDependencies
    {
        public static void BuildDependencies(IServiceCollection services)
        {
            services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));

            services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddTransient(typeof(IContactRepository), typeof(ContactRepository));

            services.AddDbContext<ApplicationContext>(opt => opt.UseInMemoryDatabase("databaseName"));
        }
    }
}
