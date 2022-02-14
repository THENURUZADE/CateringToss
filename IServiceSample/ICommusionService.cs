using System;
using System.Collections.Generic;
using System.Text;
using TFT.Models.Models;

namespace IServiceSample
{
    public interface ICommusionService
    {
       void CommusionAdded(CommusionModel model);
       IList<CommusionModel> Get();
    }
}
