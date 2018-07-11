using OtpNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BN.S160.IToken.Controllers
{
    public class TokenController : ApiController
    {
        byte [] base32Bytes = Base32Encoding.ToBytes("TESTANDOCHAVEBASE32KEY");
        public string Get (string token)
        {

            return
        }
    }
}