using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAppV4.Models.File;
using WebAppV4.Models.Interface;
using WebAppV4.Models.Mass;

namespace WebAppV4.Models.ReadText
{
    public class ReadFile : IGet
    {
        public List<string> StringMass { get; set; }
        public int LengthMass { get; set; }
        public int LengthAllMass { get; set; }


        //public string File { get { return _file; }
        //    set {
        //        FileModel filemodel = new FileModel();
        //        _file = filemodel.Path;
        //    } }

        public int Num { get; set; }

        public void Open(string file)
        {
            string s = "";
            FileModel filemodel = new FileModel();
            StreamReader sr = new StreamReader(file);
            while (sr.EndOfStream != true)
            {
                s = sr.ReadLine();
            }
            MassClass massclass =  new MassClass(Num,s);
            StringMass = massclass.StringMass();
            LengthMass = massclass.LengthMass();
            LengthAllMass = massclass.LengthAllMass();
            sr.Close();
        }
    }
}
