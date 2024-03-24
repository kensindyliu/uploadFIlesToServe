using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ReturnResult
{
    public class ReturnUploadFiles
    {
        public List<string> allFiles { get; set; }

        public ReturnUploadFiles()
        {
            allFiles = new List<string>();
        }
    }
}
