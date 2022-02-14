using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using TFT.Models.Models;

namespace TFT.Mapping
{
    public class FutureMapping : ClassMap<FutureModel>
    {
        public FutureMapping()
        {
            Table("tblFutures");
            Id(u => u.Id).GeneratedBy.Identity();
            Map(u => u.Name).Not.Nullable();
        }
    }
}
