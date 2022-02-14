using System;
using System.Collections.Generic;
using System.Text;

namespace TFT.Models.Models
{
    public class CommusionModel
    {
        public CommusionModel()
        {
            //EffectiveDate = new DateTime(Year, Month, Day);
        }
        public virtual int Id { get; set; }
        public virtual int FutureId { get; set; }
        public virtual string  FutureTypeName { get; set; }
        public virtual int Day { get; set; }
        public virtual int Month { get; set; }
        public virtual int Year { get; set; }
        public virtual DateTime EffectiveDate { get; } 
        public virtual int Sequence { get; set; }
        public virtual int Correction { get; set; }
    }
}
