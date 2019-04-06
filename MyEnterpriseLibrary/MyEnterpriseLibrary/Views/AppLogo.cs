using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEnterpriseLibrary.Views
{
    public static class AppLogo
    {
        public static void PrintAppHeader(this Coordinator c)
        {
            Console.WriteLine(@"  ____              _                          
 |  _ \            | |       /\                
 | |_) | ___   ___ | | __   /  \   _ __  _ __  
 |  _ < / _ \ / _ \| |/ /  / /\ \ | '_ \| '_ \ 
 | |_) | (_) | (_) |   <  / ____ \| |_) | |_) |
 |____/ \___/ \___/|_|\_\/_/    \_\ .__/| .__/ 
                                  | |   | |    
                                  |_|   |_|    
");
        }
    }
}
