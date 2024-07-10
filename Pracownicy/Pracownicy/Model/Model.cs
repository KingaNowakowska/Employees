using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pracownicy.Model
{
    class Model
    {
        private ListBoxText listBoxTmp;
        public ListBoxText ListBoxTmp
        {
            get => listBoxTmp;
            set 
            { 
                listBoxTmp = value; 
            }
        }
    }
}
