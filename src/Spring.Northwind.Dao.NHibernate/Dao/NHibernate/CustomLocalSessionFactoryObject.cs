
using NHibernate.Bytecode;
using Spring.Data.NHibernate;
using Spring.Data.NHibernate.Bytecode;
using System;
using System.Configuration;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
namespace Spring.Northwind.Dao.NHibernate
{
    /// <summary>
    /// A custom version of <see cref="LocalSessionFactoryObject" /> that sets 
    /// bytecode provider to be Spring.NET's and FluentNHibernate<see cref="BytecodeProvider" />.
    /// </summary>
    public class CustomLocalSessionFactoryObject : LocalSessionFactoryObject
    {
        /// <summary>
        /// Overwritten to return Spring's bytecode provider for entity injection to work.
        /// </summary>
        public override IBytecodeProvider BytecodeProvider
        {
            get { return new BytecodeProvider(ApplicationContext); }
            set { }
        }

        /// <summary>
        /// Sets the assemblies to load that contain fluent nhibernate mappings.
        /// </summary>
        /// <value>The mapping assemblies.</value>
        public string[] MappingAssemblies
        {
            get;
            set;
        }

        protected override void PostProcessConfiguration(global::NHibernate.Cfg.Configuration config)
        {
            base.PostProcessConfiguration(config);
            FluentConfiguration fluentConfig = Fluently.Configure(config);
            Array.ForEach(MappingAssemblies, assembly => fluentConfig.Mappings(m => m.HbmMappings.AddFromAssembly(Assembly.Load(assembly))));
            Array.ForEach(MappingAssemblies, assembly => fluentConfig.Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load(assembly))));
            fluentConfig.BuildSessionFactory();


  //          var sessionFactory = Fluently.Configure(config).Mappings(m =>{
  //              m.HbmMappings.AddFromAssembly(Assembly.Load(assembly));
  //              m.FluentMappings.AddFromAssembly(Assembly.Load(assembly));
  //             m.AutoMappings.Add(AutoMap.AssemblyOf<YourEntity>(type => type.Namespace.EndsWith("Entities")));
  //})
  //.BuildSessionFactory();
        }
    }
}