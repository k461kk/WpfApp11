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
    
    public partial class Postavchiki
    {
        public Postavchiki()
        {
            this.Zakazy = new HashSet<Zakazy>();
        }
    
        public int Id_Postavchiki { get; set; }
        public string Naimenovanie { get; set; }
        public string Adres { get; set; }
        public Nullable<int> Telefon { get; set; }
        public string E_mail { get; set; }
    
        public virtual ICollection<Zakazy> Zakazy { get; set; }
    }
}
