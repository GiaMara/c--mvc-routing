using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Web;

namespace eRoutingSlip.Models
{
    public class ERoutingSlipDB : DbContext
    {
        public ERoutingSlipDB() : base("name=DefaultConnection")
        {

        }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<RoutingSlip> RoutingSlips { get; set; }
        public DbSet<Signature> Signatures { get; set; }
        public DbSet<LinkedListSignature> LinkedListSignatures { get; set; }
        public DbSet<LinkedListSignatureNode> LinkedListSignatureNodes { get; set; }
        //public DbSet<AspNetRoles> AspNetRolesList { get; set; }
        public DbSet<AspNetUser> AspNetUsersList { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<LinkedListSignatureNode>()
            //    .HasOptional(f => f.NextSNode)
            //    .WithOptionalPrincipal(f => f.PrevSNode)
            //    .Map(c => c.MapKey("PreviousNodeId"));
            //modelBuilder.Entity<AspNetUsers>()
            //    .HasMany(c => c.Roles)
            //    .WithMany(i => i.Users)
            //    .Map(t => t.MapLeftKey("UserId").MapRightKey("RoleId").ToTable("AspNetUserRoles"));
            base.OnModelCreating(modelBuilder);
        }







    }
}