using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using InteractiveDataDisplay.WPF;

namespace PerformanceCounter
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private List<float> mPointsX;
    private List<float> mPointsY;
    private LineGraph mLineGraph;
    private DispatcherTimer mTimer;
    private System.Diagnostics.PerformanceCounter mCounter;
    private float mX = 0;

    public MainWindow()
    {
      InitializeComponent();
      Loaded += MainWindowLoaded;
    }

    private void MainWindowLoaded(object sender, RoutedEventArgs e)
    {
      //var mCounter = new System.Diagnostics.PerformanceCounter("Processor", @"% Processor Time", @"_Total",true);
      //var mCounter = new System.Diagnostics.PerformanceCounter("Memory", @"% Processor Time", @"_Total",true);
      mCounter = new System.Diagnostics.PerformanceCounter("Processor", "% Processor Time", "_Total");
      //var mCounter = new System.Diagnostics.PerformanceCounter("Processor", "% Privileged Time", "_Total");
      //var mCounter = new System.Diagnostics.PerformanceCounter("Processor", "% Interrupt Time", "_Total");
      //var mCounter = new System.Diagnostics.PerformanceCounter("Processor", "% DPC Time", "_Total");
      //var mCounter = new System.Diagnostics.PerformanceCounter("Memory", "Available MBytes", null);
      //var mCounter = new System.Diagnostics.PerformanceCounter("Memory", "Committed Bytes", null);
      //var mCounter = new System.Diagnostics.PerformanceCounter("Memory", "Commit Limit", null);
      //var mCounter = new System.Diagnostics.PerformanceCounter("Memory", "% Committed Bytes In Use", null);
      //var mCounter = new System.Diagnostics.PerformanceCounter("Memory", "Pool Paged Bytes", null);
      //var mCounter = new System.Diagnostics.PerformanceCounter("Memory", "Pool Nonpaged Bytes", null);
      //var mCounter = new System.Diagnostics.PerformanceCounter("Memory", "Cache Bytes", null);
      //var mCounter = new System.Diagnostics.PerformanceCounter("Paging File", "% Usage", "_Total");
      //var mCounter = new System.Diagnostics.PerformanceCounter("PhysicalDisk", "Avg. Disk Queue Length", "_Total");
      //var mCounter = new System.Diagnostics.PerformanceCounter("PhysicalDisk", "Disk Read Bytes/sec", "_Total");
      //var mCounter = new System.Diagnostics.PerformanceCounter("PhysicalDisk", "Disk Write Bytes/sec", "_Total");
      //var mCounter = new System.Diagnostics.PerformanceCounter("PhysicalDisk", "Avg. Disk sec/Read", "_Total");
      //var mCounter = new System.Diagnostics.PerformanceCounter("PhysicalDisk", "Avg. Disk sec/Write", "_Total");
      //var mCounter = new System.Diagnostics.PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total");
      //var mCounter = new System.Diagnostics.PerformanceCounter("Process", "Handle Count", "_Total");
      //var mCounter = new System.Diagnostics.PerformanceCounter("Process", "Thread Count", "_Total");
      //var mCounter = new System.Diagnostics.PerformanceCounter("System", "Context Switches/sec", null);
      //var mCounter = new System.Diagnostics.PerformanceCounter("System", "System Calls/sec", null);
      //var mCounter = new System.Diagnostics.PerformanceCounter("System", "Processor Queue Length", null);

      InitGraph();

      mTimer = new DispatcherTimer();
      mTimer.Tick += TimerTick;
      mTimer.Interval = TimeSpan.FromMilliseconds(1000);
      mTimer.Start();
    }

    private void InitGraph()
    {
      mLineGraph = new LineGraph();
      lines.Children.Add(mLineGraph);
      mLineGraph.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
      mLineGraph.StrokeThickness = 1;
      mLineGraph.IsAutoFitEnabled = true;

      mPointsX = new List<float>();
      mPointsY = new List<float>();
    }

    private void TimerTick(object sender, EventArgs e)
    {

    //if (!PerformanceCounterCategory.Exists("Processor"))
      //{
      //  Console.WriteLine("Object Processor does not exist!");
      //  return;
      //}

      //if (!PerformanceCounterCategory.CounterExists(@"% Processor Time", "Processor"))
      //{
      //  Console.WriteLine(@"Counter % Processor Time does not exist!");
      //  return;
      //}



      //while (true)
      //{
      //  Debug.WriteLine("@");

      //try
      //{
      //  Debug.WriteLine(@"Current value of Processor, %Processor Time, _Total= " + mCounter.NextValue().ToString());
      //}

      //catch
      //{
      //  Debug.WriteLine(@"_Total instance does not exist!");
      //  return;
      //}
      mPointsX.Add(mX++);
      var wY = mCounter.NextValue();
      Debug.WriteLine(@"_Total= " + wY);
      mPointsY.Add(wY);
      mLineGraph.Plot(mPointsX, mPointsY);

      //  Thread.Sleep(10000);
      //}
    }

    //private void UpdateGraph()
    //{
    //  //double[] x = new double[200];
    //  //for (int i = 0; i < x.Length; i++)
    //  //  x[i] = 3.1415 * i / (x.Length - 1);

    //  double[] x = new double[10]{25,23,36,48,54,58,56,84,21,25};
    //  var lg = new LineGraph();
    //  lines.Children.Add(lg);
    //  lg.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
    //  //lg.Description = String.Format("Data series {0}", 1);
    //  lg.StrokeThickness = 2;
    //  lg.Plot(x, x);
    //}

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
    
      mLineGraph.IsAutoFitEnabled = true;
    }
  }
 
}
