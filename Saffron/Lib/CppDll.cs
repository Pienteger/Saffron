using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Saffron.Lib
{
#pragma warning disable CA1401 // P/Invokes should not be visible
    public class CppDll
    {
        private const string MainDll = "./lib/SaffronCpp.dll";

        [DllImport(MainDll, CharSet = CharSet.Unicode)]
        public static extern int AddNumbers(int a, int b);
        [DllImport(MainDll, CharSet = CharSet.Unicode)]
        public static extern int WhatsMyName(string a, string b);
    }
#pragma warning restore CA1401 // P/Invokes should not be visible
}
