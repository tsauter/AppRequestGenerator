using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRequestGenerator
{
    public class RequestControl : System.Windows.Forms.UserControl
    {
        private string _Title;

        public string GetTitle()
        {
            return this._Title;
        }

        public void SetTitle(string fullTitleString)
        {
            this._Title = fullTitleString;
        }

    }
}
