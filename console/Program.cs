// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Microsoft.Diagnostics.NETCore.Client;

Console.WriteLine("Going to write dump");
// Console.ReadLine();

var dumpType = DumpType.Normal;
// var dumpType = DumpType.WithHeap;
var diagnosticsClient = new DiagnosticsClient(Process.GetCurrentProcess().Id);
var timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
var minidumpFilePath = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) , $"{dumpType}_console_dump_{timestamp}.dmp");
diagnosticsClient.WriteDump(dumpType, minidumpFilePath, true);

// Console.WriteLine("After writeDump, press any key to exit");
// var _= Console.ReadKey();