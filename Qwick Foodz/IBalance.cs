using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  QwickFoodz
{
    public interface IBalance
    {
        /*Properties: WalletBalance
Method: WalletRecharge, DeductBalance
*/
    
        public double WalletBalance { get;  }

        public double WalletRecharge(double amoumnt);

        
        public double DeductBalance(double amoumnt);
    }
}