using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate;
using FluentNHibernate.Mapping;
using Spring.Northwind.Domain;
namespace Spring.Northwind.Mappings
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Table("Customers");
            Id(m => m.Id).Column("CustomerID").CustomSqlType("nchar").Length(5).Not.Nullable().Index("PK_Customers").Unique().GeneratedBy.Assigned().UnsavedValue(null);
            Map(m => m.CompanyName).Column("CompanyName").CustomSqlType("nvarchar").Length(40).Not.Nullable().Index("CompanyName");
            Map(m => m.ContactName).Column("ContactName").CustomSqlType("nvarchar").Length(30);
            Map(m => m.ContactTitle).Column("ContactTitle").CustomSqlType("nvarchar").Length(30);
            Map(m => m.Address).Column("Address").CustomSqlType("nvarchar").Length(60);
            Map(m => m.City).Column("City").CustomSqlType("nvarchar").Length(15).Index("City");
            Map(m => m.Region).Column("Region").CustomSqlType("nvarchar").Length(15).Index("Region");
            Map(m => m.PostalCode).Column("PostalCode").CustomSqlType("nvarchar").Length(10).Index("PostalCode");
            Map(m => m.Country).Column("Country").CustomSqlType("nvarchar").Length(15);
            Map(m => m.Phone).Column("Phone").CustomSqlType("nvarchar").Length(24);
            Map(m => m.Fax).Column("Fax").CustomSqlType("nvarchar").Length(24);
            HasMany<Order>(m => m.Orders).KeyColumn("CustomerID").LazyLoad().Inverse().Cascade.All();
        }
    }
}