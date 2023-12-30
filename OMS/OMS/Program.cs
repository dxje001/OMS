using OMS.UIHandler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS
{
    class Program
    {
         private static readonly UIHandler uIHandler = new UIHandler();

        static void Main(string[] args)
        {
            uIHandler.HandleMainMenu();
        }
    }
}
