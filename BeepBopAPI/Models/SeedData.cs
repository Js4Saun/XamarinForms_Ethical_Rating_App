using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BeepBopAPI.Data;
using System;
using System.Linq;

namespace BeepBopAPI.Models
{
    public static class SeedData
    {
        public static void Initialise(IServiceProvider serviceProvider)
        {
            using (var context = new BeepBopAPIContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<BeepBopAPIContext>>()))
            {
                // Items List
                if (context.User.Any())
                {
                    return;
                }
                context.User.AddRange(

                // User attributes
                new User
                {
                    Username = "Joe",
                    Password = "Comedy",
                    Email = "joe"
                });

                if (context.Items.Any())
                {
                    return; 
                }
                context.Items.AddRange(
                
                // Item attributes
                new Items
                {
                    
                    ItemName = "Xbox One X",
                    ItemSummary = "The next generation of gaming",
                    ItemType = "Games Console"


                });
                context.SaveChanges();
            }
        }
    }
}
