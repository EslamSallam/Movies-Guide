using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp7
{
    [Serializable]
    public class movie
    {
        public string id { set; get; }
        public string title { set; get; }
        public string director { set; get; }
        public string year { set; get; }
        public string genres { set; get; }
        public string rating { set; get; }
        public string poster { set; get; }
    }
}
