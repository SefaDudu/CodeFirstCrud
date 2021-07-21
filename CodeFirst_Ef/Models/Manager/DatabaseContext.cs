using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirst_Ef.Models.Manager
{
    public class DatabaseContext:DbContext
    {
        //Bu propertyler ile crud işlemleri yapılacak
        public DbSet<Kisiler> Kisiler { get; set; }
        public DbSet<Adresler> Adresler { get; set; }
        public DatabaseContext()
        {
            //Veri tabanı yoksa veri tabanı oluşturucak
            Database.SetInitializer(new VeriTabanıOlusturucu());
        }
    }
    public class VeriTabanıOlusturucu : CreateDatabaseIfNotExists<DatabaseContext>
    {
        //yoksa oluşturucak
        
        //Db oluşmuşsa örnek data basma ManaNuget--> Fake Data
        protected override void Seed(DatabaseContext context)
        {
            //Kişiler insert ediliyor

            for (int i = 0; i < 10; i++)
            {
                Kisiler kisi = new Kisiler();
                kisi.Ad = FakeData.NameData.GetFirstName();
                kisi.Soyad = FakeData.NameData.GetSurname();
                kisi.Yas = FakeData.NumberData.GetNumber(10, 60);
                context.Kisiler.Add(kisi);
            }
            context.SaveChanges();
            //adresler insert ediliyor
            List<Kisiler> tumKisiler = context.Kisiler.ToList();
            foreach (Kisiler kisi in tumKisiler)
            {
                for (int i = 0; i < FakeData.NumberData.GetNumber(1,5); i++)
                {
                    Adresler adres = new Adresler();
                    adres.AdresTanım = FakeData.PlaceData.GetAddress();
                    adres.Kisi = kisi;
                    context.Adresler.Add(adres);
                }
            }
            context.SaveChanges();
        }
    }
}