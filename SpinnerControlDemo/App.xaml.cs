using System;
using System.Windows;
using System.Windows.Controls;

namespace SpinnerControlDemo
{
    public partial class App : Application
    {
        //*******
        //Create attached properties that allow for setting grid rows and columns in styles
        //*******

        /// <summary>
        /// Allows for setting grid rows in a style using a csv string of lengths.
        /// <example>Auto,1,*,2*,1.5*</example>
        /// </summary>
        public static readonly DependencyProperty GridRowsProperty = DependencyProperty.RegisterAttached(
            "GridRows"
            , typeof(string)
            , typeof(App)
            , new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.AffectsMeasure, OnGridRowsPropertyChanged));

        private static void OnGridRowsPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var grid = dependencyObject as Grid;
            if (grid == null)
                throw new ArgumentException($"GridRows property could not get the Grid object from type '{dependencyObject.GetType()}'");

            DefineGridRows(grid);
        }

        public static void SetGridRows(DependencyObject element, string value)
        {
            element.SetValue(GridRowsProperty, value);
        }
        public static string GetGridRows(DependencyObject element)
        {
            return (string) element.GetValue(GridRowsProperty);
        }

        protected static void DefineGridRows(Grid grid)
        {
            grid.RowDefinitions.Clear();

            var rows = GetGridRows(grid)
                .Replace(" ", string.Empty)
                .Trim()
                .ToLower()
                .Split(Convert.ToChar(","));

            foreach (var lengths in rows)
            {
                switch (lengths)
                {
                    case "auto":
                        grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                        break;

                    case "*":
                        grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                        break;

                    default:
                        double length;
                        var isStarred = lengths.EndsWith("*");
                        var isNumeric = double.TryParse(isStarred ? lengths.TrimEnd('*') : lengths, out length);

                        if (!isNumeric)
                            throw new ArgumentException("GridRows property must be a csv like: 'Auto,1,*,2*,1.5*'");

                        grid.RowDefinitions.Add(new RowDefinition
                        {
                            Height = new GridLength(length, isStarred ? GridUnitType.Star : GridUnitType.Pixel)
                        });

                        break;
                }
            }
        }

        /// <summary>
        /// Allows for setting grid columns in a style using a csv string of lengths.
        /// <example>Auto,*,2*,1.5*</example>
        /// </summary>
        public static readonly DependencyProperty GridColumnsProperty = DependencyProperty.RegisterAttached(
            "GridColumns"
            , typeof(string)
            , typeof(App)
            , new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.AffectsMeasure, OnGridColumnsPropertyChanged));

        private static void OnGridColumnsPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var grid = dependencyObject as Grid;
            if (grid == null)
                throw new ArgumentException($"GridColumns property could not get the Grid object from type '{dependencyObject.GetType()}'");

            DefineGridColumns(grid);
        }

        public static void SetGridColumns(DependencyObject element, string value)
        {
            element.SetValue(GridColumnsProperty, value);
        }
        public static string GetGridColumns(DependencyObject element)
        {
            return (string)element.GetValue(GridColumnsProperty);
        }

        protected static void DefineGridColumns(Grid grid)
        {
            grid.ColumnDefinitions.Clear();

            var columns = GetGridColumns(grid)
                .Replace(" ", string.Empty)
                .Trim()
                .ToLower()
                .Split(Convert.ToChar(","));

            foreach (var lengths in columns)
            {
                switch (lengths)
                {
                    case "auto":
                        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
                        break;

                    case "*":
                        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                        break;

                    default:
                        double length;
                        var isStarred = lengths.EndsWith("*");
                        var isNumeric = double.TryParse(isStarred ? lengths.TrimEnd('*') : lengths, out length);

                        if (!isNumeric)
                            throw new ArgumentException("GridColumns property must be a csv like: 'Auto,1,*,2*,1.5*'");

                        grid.ColumnDefinitions.Add(new ColumnDefinition
                        {
                            Width = new GridLength(length, isStarred ? GridUnitType.Star : GridUnitType.Pixel)
                        });

                        break;
                }
            }
        }
    }
}
