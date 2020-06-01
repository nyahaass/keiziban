using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace keiziban.App_Start
{
    public class ClsUtils
    {
        public string NullChkString(object chkstr)
        {
            return chkstr?.ToString() ?? String.Empty;
        }

        public int NullChkToInt(object chkobj)
        {
            if (chkobj is null)
            {
                return 0;
            }

            int result = 0;
            int.TryParse(chkobj.ToString(), out result);
            return result;
        }
    }
}