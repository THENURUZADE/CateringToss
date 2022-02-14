using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using TFT.Models.Models;

namespace TFT.Mapping
{
    public class CommusionMapping : ClassMap<CommusionModel>
    {
        public CommusionMapping()
        {
            Table("tblCommusion");
            Id(u => u.Id).GeneratedBy.Identity();
            Map(u => u.Sequence).Not.Nullable();
            Map(u => u.Correction).Not.Nullable();
            Map(u => u.EffectiveDate).Not.Nullable();
            Map(u => u.FutureTypeName).Not.Nullable();
        }
    }
}
