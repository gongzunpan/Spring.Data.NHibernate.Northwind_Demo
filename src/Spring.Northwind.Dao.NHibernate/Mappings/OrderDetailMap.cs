using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate;
using FluentNHibernate.Mapping;
using Spring.Northwind.Domain;
namespace Spring.Northwind.Mappings
{
    public class OrderDetailMap : ClassMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            Table("[Order Details]");
            CompositeId().KeyProperty(x => x.ProductId).KeyReference(x => x.Order);
            Map(m => m.UnitPrice).Column("UnitPrice").CustomSqlType("money");
            Map(m => m.Quantity).Column("Quantity").CustomSqlType("int");
            Map(m => m.Discount).Column("Discount").CustomSqlType("real");

        }
    }
}
