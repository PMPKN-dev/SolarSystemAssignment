using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SolarSystem._0_Planets
{
    internal class Planet
    {
        double Radius;
        double PositionOffset;
        double angle;
        double LeftPos;
        double TopPos;
        Ellipse ellipse;
        Canvas canvas;


        public Planet(double Radius, double PositionOffset, Canvas universe, Brush color) { 
            this.Radius = Radius;
            this.PositionOffset = PositionOffset;
            ellipse = new Ellipse();
            ellipse.Width = this.Radius*2;
            ellipse.Height = this.Radius*2;
            this.canvas = universe;
            this.angle = 0;
            ellipse.Fill = color;

            universe.Children.Add(ellipse);
            render();


        }
        


        public void move()
        {
            angle += 1 / (PositionOffset + 0.01);
            render();
        }

        public void render()
        {
            LeftPos = canvas.Width / 2 - PositionOffset * Math.Cos(angle) - Radius;
            TopPos = canvas.Height / 2 - PositionOffset * Math.Sin(angle) - Radius;
            Canvas.SetLeft(ellipse,LeftPos);
            Canvas.SetTop(ellipse,TopPos);
        }


    }
}
