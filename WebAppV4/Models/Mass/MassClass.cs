using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppV4.Models.Mass
{
    public class MassClass
    {
        private int _num;
        private string _s;
        string[] textmass;
        public MassClass(int num, string s)
        {
            _num = num;
            _s = s;
        }
        
        public List<string> StringMass()
        {
            textmass = _s.Split(new Char[] { ' ', '\n', '\r', ',', '.', ':', ';', '!', '?', '-', ')', '(', '"', '*', '\'', '|' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> arraymass = new List<string>();
            var selectedmass = textmass.Where(m => m.Length > _num);

            //return selectedmass;
            foreach (string mass in selectedmass)
            {
                arraymass.Add(mass);
            }
            return arraymass;
        }

        public int LengthMass()
        {
            int arrmass = 0;
            textmass = _s.Split(new Char[] { ' ', '\n', '\r', ',', '.', ':', ';', '!', '?', '-', ')', '(', '"', '*', '\'', '|' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string mass in textmass)
            {
                if (mass.Length < _num)
                {
                    arrmass = mass.Length;
                }
            }
            return arrmass;
        }

        public int LengthAllMass()
        {
            textmass = _s.Split(new Char[] { ' ', '\n', '\r', ',', '.', ':', ';', '!', '?', '-', ')', '(', '"', '*', '\'', '|' }, StringSplitOptions.RemoveEmptyEntries);
            return textmass.Length;
        }
    }
}
