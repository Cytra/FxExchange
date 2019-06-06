using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using FX_Exchange.Helpers;
using FX_Exchange.Models;
using Microsoft.Practices.Unity;
    
namespace FX_Exchange
{
    
    class Program
    {
        // The container from which dependencies will be resolved.
        public static IContainer Container;

        static void Main(string[] args)
        {
            //Set app container
            Container = ConfigureDependencies();

            // Start listening for input.
            ListenForInput();
        }

        private static void ListenForInput()
        {
            IBusinessLogicHelper businessLogic;
            IDataWriter dataWriter;
            IDataParser dataParser;
            ICurrencyHelper currencyHelper;

            //Initialize business Logic
            using (var scope = Container.BeginLifetimeScope())
            {
                dataWriter = scope.Resolve<IDataWriter>();
                dataParser = scope.Resolve<IDataParser>();
                currencyHelper = scope.Resolve<ICurrencyHelper>();
                businessLogic = scope.Resolve<IBusinessLogicHelper>();
                do
                {
                    // Explain what you're looking at.
                    dataWriter.WriteInstructions();

                    string input = Console.ReadLine();
                    Console.WriteLine();

                    var currencyPair = dataParser.ParseData(input, dataWriter, currencyHelper);
                    businessLogic.CurrencyPair = currencyPair;
                    var result = businessLogic.ExchangeCurrencies();

                    if(result != null)
                    {
                        dataWriter.WriteResult(result);
                    } 
                    
                } while (true);
            }
        }

        private static IContainer ConfigureDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Currency>();
            builder.RegisterType<CurrencyPair>().SingleInstance();
            builder.RegisterType<BusinessLogicHelper>().As<IBusinessLogicHelper>();
            builder.RegisterType<DataWriter>().As<IDataWriter>().SingleInstance();
            builder.RegisterType<CurrencyHelper>().As<ICurrencyHelper>().SingleInstance();
            builder.RegisterType<DataParser>().As<IDataParser>().SingleInstance();
            return Container = builder.Build();
        }
    }
}
