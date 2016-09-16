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

namespace SpinnerControlLibrary
{
    /// <summary>
    /// Interaction logic for EightDotsSpinner.xaml
    /// </summary>
    public partial class EightDotsSpinner : UserControl
    {
        public EightDotsSpinner()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Foreground (fill) color of the dots will animate TO.
        /// </summary>
        public Color DotsForegroundColor
        {
            get { return (Color)GetValue(DotsForegroundColorProperty); }
            set { SetValue(DotsForegroundColorProperty, value); }
        }
        public static readonly DependencyProperty DotsForegroundColorProperty = DependencyProperty.Register(
            "DotsForegroundColor"
            , typeof(Color)
            , typeof(EightDotsSpinner)
            , new PropertyMetadata(Color.FromArgb(64, 0, 0, 0)));

        /// <summary>
        /// Background (fill) color of the dots will be at rest.
        /// </summary>
        public Color DotsBackgroundColor
        {
            get { return (Color) GetValue(DotsBackgroundColorProperty); }
            set { SetValue(DotsBackgroundColorProperty, value); }
        }
        public static readonly DependencyProperty DotsBackgroundColorProperty = DependencyProperty.Register(
            "DotsBackgroundColor"
            , typeof(Color)
            , typeof(EightDotsSpinner)
            , new PropertyMetadata(Colors.Transparent));


        /// <summary>
        /// Outline (stroke) color of the dots.
        /// </summary>
        public Brush DotsStroke
        {
            get { return (Brush)GetValue(DotsStrokeProperty); }
            set { SetValue(DotsStrokeProperty, value); }
        }
        public static readonly DependencyProperty DotsStrokeProperty = DependencyProperty.Register(
            "DotsStroke"
            , typeof(Brush)
            , typeof(EightDotsSpinner)
            , new PropertyMetadata(Brushes.Transparent));

        /// <summary>
        /// Increases or decreases the speed the spin.
        /// </summary>
	    public double RotateSpeed
        {
            get { return (double)GetValue(RotateSpeedProperty); }
            set { SetValue(RotateSpeedProperty, value); }
        }
        public static readonly DependencyProperty RotateSpeedProperty = DependencyProperty.Register(
            "RotateSpeed"
            , typeof(double)
            , typeof(EightDotsSpinner)
            , new PropertyMetadata(1D));
    }
}
