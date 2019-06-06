using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FX_Exchange.Library
{
    public class BusinessLogic : IBusinessLogic
    {
        public int GetValues(int input)
        {
            return 2;
        }
    }

    public interface IBusinessLogic
    {
       int  GetValues(int input);
    }



}
