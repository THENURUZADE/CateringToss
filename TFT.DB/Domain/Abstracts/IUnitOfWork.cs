using System;
using System.Collections.Generic;
using System.Text;

namespace TFT.DB.Domain.Abstracts
{
    interface IUnitOfWork<T>
    {
        ICrudRepository<T> CrudRepository { get; }
    }
}
