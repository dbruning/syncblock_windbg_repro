using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Diagnostics.NETCore.Client;
using Path = System.IO.Path;

namespace WpfApp1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var dumpType = DumpType.Normal;
// var dumpType = DumpType.WithHeap;
        var diagnosticsClient = new DiagnosticsClient(Process.GetCurrentProcess().Id);
        var timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        var minidumpFilePath = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) , $"{dumpType}_wpf_dump_{timestamp}.dmp");
        diagnosticsClient.WriteDump(dumpType, minidumpFilePath, true);
    }
}