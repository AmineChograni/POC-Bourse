using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payment.Models;

namespace Payment.Context
{
    public class PaymentDbContext:DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options):base(options)
        {

        }

        public DbSet<Paiement> paiement { get; set; }

        
    }
}
