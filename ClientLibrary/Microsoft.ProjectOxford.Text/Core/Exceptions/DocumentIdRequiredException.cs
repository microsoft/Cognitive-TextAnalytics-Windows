using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ProjectOxford.Text.Core
{
    public class DocumentIdRequiredException : ApplicationException
    {
        public override string Message
        {
            get
            {
                return "A document's Id property is required.";
            }
        }
    }
}
