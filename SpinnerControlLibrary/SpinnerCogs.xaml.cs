using System.Windows;
using System.Windows.Media;

namespace SpinnerControlLibrary;

public partial class DualCogs
{
    public static readonly DependencyProperty CogsForegroundProperty = DependencyProperty.Register(
        nameof(CogsForeground)
        , typeof(Brush)
        , typeof(DualCogs)
        , new PropertyMetadata(new SolidColorBrush(Color.FromArgb(64, 0, 0, 0)))
    );

    public static readonly DependencyProperty CogsStrokeProperty = DependencyProperty.Register(
        nameof(CogsStroke)
        , typeof(Brush)
        , typeof(DualCogs)
        , new PropertyMetadata(Brushes.Black)
    );

    public static readonly DependencyProperty CogsSpeedProperty = DependencyProperty.Register(
        nameof(CogsSpeed)
        , typeof(double)
        , typeof(DualCogs)
        , new PropertyMetadata(1D)
    );

    public DualCogs()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Foreground (fill) color of the cog wheels
    /// </summary>
    public Brush CogsForeground
    {
        get => (Brush)GetValue(CogsForegroundProperty);
        set => SetValue(CogsForegroundProperty, value);
    }

    /// <summary>
    /// Outline (stroke) color of the cog wheels
    /// </summary>
    public Brush CogsStroke
    {
        get => (Brush)GetValue(CogsStrokeProperty);
        set => SetValue(CogsStrokeProperty, value);
    }

    /// <summary>
    /// Increases or decreases the speed the cogs spin.
    /// </summary>
    public double CogsSpeed
    {
        get => (double)GetValue(CogsSpeedProperty);
        set => SetValue(CogsSpeedProperty, value);
    }
}