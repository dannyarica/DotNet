using System;
using System.Diagnostics;

namespace MyRemoteObject
{
    public class CreateFolder : MarshalByRefObject
    {
        public CreateFolder()
        {
            Console.WriteLine("Calling Create Folder Service...");
        }

        public void Run(int enterprise, int store)
        {
            try
            {
                Console.WriteLine("Run: start");
                var startInfo = new ProcessStartInfo
                {
                    CreateNoWindow = false,
                    UseShellExecute = false,
                    FileName = @"D:\InfoGenesis\SYS_EXE\CreateDir.exe", //any exe program to be executed by command line
                    Arguments = string.Format(@"/ENT={0} /STORE={1}", enterprise, store)
                };

                // Start the process with the info we specified.
                // Call WaitForExit and then the using-statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }

                Console.WriteLine("Run: finish");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}