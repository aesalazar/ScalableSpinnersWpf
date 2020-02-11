using System.Windows;
using System.Windows.Media;

namespace SpinnerControlLibrary
{
    public partial class EightDotsSpinner
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
            get => (Color)GetValue(DotsForegroundColorProperty);
            set => SetValue(DotsForegroundColorProperty, value);
        }
        public static readonly DependencyProperty DotsForegroundColorProperty = DependencyProperty.Register(
            nameof(DotsForegroundColor)
            , typeof(Color)
            , typeof(EightDotsSpinner)
            , new PropertyMetadata(Color.FromArgb(64, 0, 0, 0))
        );

        /// <summary>
        /// Background (fill) color of the dots will be at rest.
        /// </summary>
        public Color DotsBackgroundColor
        {
            get => (Color) GetValue(DotsBackgroundColorProperty);
            set => SetValue(DotsBackgroundColorProperty, value);
        }
        public static readonly DependencyProperty DotsBackgroundColorProperty = DependencyProperty.Register(
            nameof(DotsBackgroundColor)
            , typeof(Color)
            , typeof(EightDotsSpinner)
            , new PropertyMetadata(Colors.Transparent)
        );


        /// <summary>
        /// Outline (stroke) color of the dots.
        /// </summary>
        public Brush DotsStroke
        {
            get => (Brush)GetValue(DotsStrokeProperty);
            set => SetValue(DotsStrokeProperty, value);
        }
        public static readonly DependencyProperty DotsStrokeProperty = DependencyProperty.Register(
            nameof(DotsStroke)
            , typeof(Brush)
            , typeof(EightDotsSpinner)
            , new PropertyMetadata(Brushes.Transparent)
        );

        /// <summary>
        /// Increases or decreases the speed the spin.
        /// </summary>
	    public double RotateSpeed
        {
            get => (double)GetValue(RotateSpeedProperty);
            set => SetValue(RotateSpeedProperty, value);
        }
        public static readonly DependencyProperty RotateSpeedProperty = DependencyProperty.Register(
            nameof(RotateSpeed)
            , typeof(double)
            , typeof(EightDotsSpinner)
            , new PropertyMetadata(1D)
        );
    }
}
