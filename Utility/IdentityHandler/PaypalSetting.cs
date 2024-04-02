using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.IdentityHandler
{
    // nếu làm paypal phải fix lại toàn bộ model, paypal access token, paypal create/ excute responsive...
    public class PaypalSettings
    {
        public string ClientId { get; set; }
        public string Secret { get; set; }
        public string Mode { get; set; }
    }
}
