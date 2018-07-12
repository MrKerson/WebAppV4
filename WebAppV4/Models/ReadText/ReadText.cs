using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppV4.Models.Interface;
using WebAppV4.Models.Mass;
using WebAppV4.Models.Text;

namespace WebAppV4.Models.ReadText
{
    public class ReadText : IGet
    {
        public List<string> StringMass { get; set; }
        public int LengthMass { get; set; }
        public int LengthAllMass { get; set; }

        //public string File { get { return _s; } set {
        //        TextModel filemodel = new TextModel();
        //        _s = filemodel.Text;
        //    } }
        public int Num { get; set; }
        public void Open(string s)
        {
            TextModel filemodel = new TextModel();
            MassClass massclass = new MassClass(Num, s);
            StringMass = massclass.StringMass();
            LengthMass = massclass.LengthMass();
            LengthAllMass = massclass.LengthAllMass();
        }
    }
}
