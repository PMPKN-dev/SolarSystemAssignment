using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using SolarSystem._0_Planets;

namespace SolarSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Planet sun;
        Planet mercury;
        Planet venus;
        Planet earth;
        Planet mars;
        Planet jupiter;
        static Timer Timer;
        
        public MainWindow()
        {
            
            InitializeComponent();
            PlanetSetUp();
            
        }

        private void PlanetSetUp()
        {

            sun = new Planet(35, 0, Universe, new SolidColorBrush(Color.FromRgb(255, 255, 255)));

            mercury = new Planet(3, 46, Universe, new SolidColorBrush(Color.FromRgb(140, 140, 148)));

            venus = new Planet(6, 108, Universe, new SolidColorBrush(Color.FromRgb(249, 194, 26)));

            earth = new Planet(6, 149, Universe, new SolidColorBrush(Color.FromRgb(131, 153, 183)));

            mars = new Planet(3, 219, Universe, new SolidColorBrush(Color.FromRgb(193, 68, 14)));

            jupiter = new Planet(69, 741, Universe, new SolidColorBrush(Color.FromRgb(165, 145, 134)));

        }


        private void MovePlanetsWithDispatcher()
        {
            //Dispatcher timer Setup
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(100000);
            dispatcherTimer.Start();


        }

        private void dispatcherTimer_Tick(object? sender, EventArgs e)
        {
            earth.move();
            mercury.move();
            venus.move();
            mars.move();
            jupiter.move();
        }

        private void MovePlanetsWithThreading()
        {
            Timer = new Timer(new TimerCallback(TickTimer), null, 1000, 100);
        }

        private void movePlanets()
        {
            earth.move();
            mercury.move();
            venus.move();
            mars.move();
            jupiter.move();

        }
        void TickTimer(object state)
        {
            movePlanets();
            Thread.Sleep(10);
        }

        private void Starter_Click(object sender, RoutedEventArgs e)
        {
            //MovePlanetsWithDispatcher();
            //MovePlanetsWithThreading();
        }

        
    }
}
