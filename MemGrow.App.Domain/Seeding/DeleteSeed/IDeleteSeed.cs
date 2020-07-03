using System;
using System.Collections.Generic;
using System.Text;

namespace MemGrow.App.Domain.Seeding.DeleteSeed
{
    public interface IDeleteSeed
    {
        void DeleteSeed(int seedId);
    }
}