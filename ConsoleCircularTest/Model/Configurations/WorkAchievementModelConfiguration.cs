using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCircularTest.Model.Configurations
{
    internal class WorkAchievementModelConfiguration : IEntityTypeConfiguration<WorkAchievement>
    {
        public void Configure(EntityTypeBuilder<WorkAchievement> builder)
        {
         
           

            //EF will set the achievment invoice property id to null on delete of the invoice 
            builder.HasOne<Invoice>().WithMany(x => x.Achievements).OnDelete(DeleteBehavior.ClientSetNull).IsRequired(false);
            builder.HasOne(x=>x.Customer).WithMany(x => x.Achievements).OnDelete(DeleteBehavior.Cascade).IsRequired(true);


        }
    }
}
