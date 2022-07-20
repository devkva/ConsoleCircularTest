using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleCircularTest.Model.Configurations
{
    internal class InvoiceModelConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {

            //The navigation property where the ClientSetNull is defined must be auto-include
            //else the set null operation will not be triggered and a foreign key constraint will be thrown that the invoice id on the achievements must be null 
           builder.Navigation(i => i.Achievements).AutoInclude(); 




        }
    }
}
