//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Produkti
    {
        public Produkti()
        {
            this.Sklad = new HashSet<Sklad>();
            this.Zakazy = new HashSet<Zakazy>();
        }
    
        public int Id_Produkti { get; set; }
        public string Naimenovanie { get; set; }
        public string Kategoriya { get; set; }
        public Nullable<int> Cena { get; set; }
        public Nullable<System.DateTime> Srok_godnosti { get; set; }
    
        public virtual ICollection<Sklad> Sklad { get; set; }
        public virtual ICollection<Zakazy> Zakazy { get; set; }
    }
}
