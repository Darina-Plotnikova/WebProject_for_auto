//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Работа_на_объекте
    {
        public int ID { get; set; }
        public int ID_объекта { get; set; }
        public int ID_сотрудника { get; set; }
        public string Выполняемая_работа { get; set; }
    
        public virtual Объект Объект { get; set; }
        public virtual Сотрудник Сотрудник { get; set; }
    }
}
