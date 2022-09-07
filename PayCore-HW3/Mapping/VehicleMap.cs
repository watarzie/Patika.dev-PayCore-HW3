using FluentNHibernate.Mapping;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using PayCore_HW3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace PayCore_HW3.Mapping
{
    public class VehicleMap: ClassMapping<Vehicle>
    {
        // Vehicle nesnesi veritabanına kurucu metot içerisinde mapleniyor.
        public VehicleMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int64); // long veri tipinde
                x.UnsavedValue(0);
                x.Generator(Generators.Increment); // Id değeri auto increment yapılıyor.
            });

            Property(b => b.VehicleName, x =>
            {
                x.Length(50); // max 50 karakter uzunlugunda olabilir
                x.Type(NHibernateUtil.String); // String tipinde maplenir.
               
            });
            Property(b => b.VehiclePlate, x =>
            {
                x.Length(14); // max 14 karakter uzunlugunda olabilir
                x.Type(NHibernateUtil.String); // string tipinde maplenir
                
            });

            Table("Vehicle"); // veritabanında tablo adı vehicle'dır.

        }
    }
}
