using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SpinnerControlDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
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
            , new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.AffectsMeasure, GridRowsPropertyChanged));

        private static void GridRowsPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var sender = dependencyObject as Grid;
            if (sender == null)
                throw new ArgumentException($"GridRows property could not get the Grid object from type '{dependencyObject.GetType()}'");

            DefineGridRows(sender);
        }

        public static void SetGridRows(DependencyObject element, string value)
        {
            element.SetValue(GridRowsProperty, value);
        }
        public static string GetGridRows(DependencyObject element)
        {
            return (string) element.GetValue(GridRowsProperty);
        }

        private static void DefineGridRows(Grid grid)
        {
            var rows = GetGridRows(grid).Split(Convert.ToChar(","));
            grid.RowDefinitions.Clear();

            foreach (var row in rows)
            {
                var lengths = row.Replace(" ", string.Empty).Trim().ToLower();
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
            , new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.AffectsMeasure, GridColumnsPropertyChanged));

        private static void GridColumnsPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var sender = dependencyObject as Grid;
            if (sender == null)
                throw new ArgumentException($"GridColumns property could not get the Grid object from type '{dependencyObject.GetType()}'");

            DefineGridColumns(sender);
        }

        public static void SetGridColumns(DependencyObject element, string value)
        {
            element.SetValue(GridColumnsProperty, value);
        }
        public static string GetGridColumns(DependencyObject element)
        {
            return (string)element.GetValue(GridColumnsProperty);
        }

        private static void DefineGridColumns(Grid grid)
        {
            var columns = GetGridColumns(grid).Split(Convert.ToChar(","));
            grid.ColumnDefinitions.Clear();

            foreach (var column in columns)
            {
                var lengths = column.Replace(" ", string.Empty).Trim().ToLower();
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
