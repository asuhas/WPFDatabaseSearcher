using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test.Models
{
    // Always code to an interface. You can plug and play any data source;
    // Also can have 2 different data sources/ one for UI testing one for actual stuff/
    public interface IModel
    {
        List<ModelDataStructure> GetData(string key1, double key2, string key3);
    }
    class DummyModel : IModel
    {
        public List<ModelDataStructure> GetData(string key1, double key2, string key3)
        {

            // Simulating long running operation
           
            Thread.Sleep(900);
            return new List<ModelDataStructure>()
            {
                new ModelDataStructure("TestName",123456,987776254)
        };
          
        }
    }

    // Can test the functionality of this independently//

    class ProductionMoel : IModel
    {
        // Database connection goes here
        public List<ModelDataStructure> GetData(string key1, double key2, string key3)
        {
            throw new NotImplementedException();
        }
    }
}
