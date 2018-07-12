using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppV4.Models.Interface
{
    interface IGet
    {
        int Num { get; set; }
        void Open(string file);
    }
}
