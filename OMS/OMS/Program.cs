using OMS.Classes;
using OMS.Service;
using OMS.UIHandlerF;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OMS
{
    public class Program
    {
        private static readonly UIHandler uIHandlera = new UIHandler();

        static void Main(string[] args)
        {
            uIHandlera.HandleMainMenu();
        }
    }
}
