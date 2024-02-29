using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public partial class Postavchiki
    {
        public override string ToString()
        {
            //return base.ToString();
            return Naimenovanie + "- " + Adres + "- " + Telefon + "";
        }
    }

    public partial class Produkti
    {
        public override string ToString()
        {
            //return base.ToString();
            return Naimenovanie + " - " + Cena + " Руб " + Kategoriya + "" + Id_Produkti + "";
        }
    }

    public partial class Sklad
    {
        public override string ToString()
        {
            //return base.ToString();
            return Id_Produktii+ "" + Kolichestvo + "Шт " + Data_postupleniya + "";
        }
    }

    public partial class Zakazy
    {
        public override string ToString()
        {
            //return base.ToString();
            return Id_Produkti + "" + Data_zakaza + " " + Id_Produkti + " " + Stoimost + "Руб";
        }
    }

    public partial class Login
    {
        public override string ToString()
        {
            //return base.ToString();
            return Name + "- " + Roli + "";
        }
    }
}
