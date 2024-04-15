using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FishingAssistant
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FishingAssistant());
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string name = new AssemblyName(args.Name).Name;
            if (name.EndsWith(".resources"))
            {
                return null;
            }
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("FishingAssistant." + name + ".dll"))
            {
                if (stream == null)
                {
                    return null;
                }
                byte[] array = new byte[stream.Length];
                stream.Read(array, 0, array.Length);
                return Assembly.Load(array);
            }
        }
    }
}
