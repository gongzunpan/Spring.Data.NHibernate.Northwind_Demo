using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate;
using FluentNHibernate.Mapping;
using Spring.Northwind.Domain;
namespace Spring.Northwind.Mappings
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Table("Orders");
            Id(m => m.Id).Column("OrderID").CustomSqlType("int").Not.Nullable().Index("PK_Orders").Unique();
            Map(m => m.OrderDate).Column("OrderDate").CustomSqlType("datetime").Index("OrderDate");
            Map(m => m.RequiredDate).Column("RequiredDate").CustomSqlType("datetime");
            Map(m => m.ShippedDate).Column("ShippedDate").CustomSqlType("datetime").Index("ShippedDate");
            Map(m => m.ShipName).Column("ShipName").CustomSqlType("nvarchar").Length(40);
            Map(m => m.ShipAddress).Column("ShipAddress").CustomSqlType("nvarchar").Length(60);
            Map(m => m.ShipCity).Column("ShipCity").CustomSqlType("nvarchar").Length(15);
            Map(m => m.ShipRegion).Column("ShipRegion").CustomSqlType("nvarchar").Length(15);
            Map(m => m.ShipPostalCode).Column("ShipPostalCode").CustomSqlType("nvarchar").Length(10).Index("ShipPostalCode");
            Map(m => m.ShipCountry).Column("ShipCountry").CustomSqlType("nvarchar").Length(15);

            HasMany<OrderDetail>(m => m.OrderDetails).KeyColumn("OrderID").LazyLoad().Inverse().Cascade.All();
        }
    }
}