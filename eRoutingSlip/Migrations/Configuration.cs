namespace eRoutingSlip.Migrations
{
    using eRoutingSlip.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<eRoutingSlip.Models.ERoutingSlipDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "eRoutingSlip.Models.ERoutingSlipDB";
        }

        protected override void Seed(eRoutingSlip.Models.ERoutingSlipDB context)
        {
            context.Divisions.AddOrUpdate(d => d.DivisionName,
                new Division { DivisionName = "C", DivisionHead = "C. Evans" },
                new Division { DivisionName = "D", DivisionHead = "F. Muniz" },
                new Division
                {
                    DivisionName = "E",
                    DivisionHead = "D. Radcliffe",
                    RoutingSlips =
                    new List<RoutingSlip> {
                        new RoutingSlip { DocumentName="ASDF", RequestingEmployee="N. Gaiman", ForwardTo="M. Shyamalan" }
                        }
                });
        }
    }
}
