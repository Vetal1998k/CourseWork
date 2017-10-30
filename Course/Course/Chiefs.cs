using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Course {
    class Chiefs {
        StreamWriter sw;      

        public Chiefs(string name, int pos)
        {
            if (pos == 0)
            {
                sw = new StreamWriter("Руководители отделов.txt", true, Encoding.Default);                            
                sw.WriteLine(name);
                sw.Close();
            }
            else if (pos == 1)
            {
                sw = new StreamWriter("Руководители секторов.txt", true, Encoding.Default);
                sw.WriteLine(name);
                sw.Close();
            }
            else if(pos == 2) { }
        }
    }
}