using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WorkOrderSite.Models;

namespace WorkOrderSite.DAL
{
    public class WorkOrderInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<WorkOrderContext>
    {
        protected override void Seed(WorkOrderContext context)
        {
            base.Seed(context);
        }

    }
}