using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Timers;
using System.Windows.Threading;
using Microsoft.Win32;

namespace lottery_tool
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {       
       
        string[] content;
        string path;
        DispatcherTimer timer = new DispatcherTimer(); //计时器 位于System.Windows.Threading命名空间下
        public MainWindow()
        {
            
            InitializeComponent();
            timer.Tick += new EventHandler(timer_Tick); //事件注册 tick类比于unity中的update方法 一秒执行一次
            this.Title = "点名工具";
        }

        
       
        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {

           
            path = pathTextBox.Text;
          
            if (sender == StartBtn)
            {
                if (path == null || path == "")
                {
                    MessageBox.Show("请输入文件路径");
                }
                else
                {
                    content = File.ReadAllLines(path, Encoding.Default);//防止中文变成乱码 和编码方式有关
                  
                        if ((string)StartBtn.Content=="开始")
                        {
                            //isStart = true;
                            StartBtn.Content = "停止";
                            timer.Start();
                        }
                        else
                        {
                            //isStart = false;
                            StartBtn.Content = "开始";
                            timer.Stop();
                        }
                        //isStart = true;
                                            
                }
               }
        }

        void timer_Tick(object sender,EventArgs e)      //timer的事件处理函数
        {
            Random b = new Random();
            int i = b.Next(0, content.Length); //相当于unity中的random.range
            ShowLabel.Content = content[i];
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void FindFileBtn_Click(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog fileDialog = new OpenFileDialog(); //位于Microsoft.win32命名空间下
            if (fileDialog.ShowDialog()==true)
            {
                path = fileDialog.FileName;
                pathTextBox.Text = path;
            }
           
        }
    }
}
