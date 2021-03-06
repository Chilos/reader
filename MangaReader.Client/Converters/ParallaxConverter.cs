﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace MangaReader.Client.Converters
{
    public class ParallaxConverter : IValueConverter
    {
        const double _defaultFactor = -0.10;

        /// <summary>
        /// Parallax converter helper
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            double factor = _defaultFactor;


            if (parameter != null && parameter is string
                && double.TryParse((string)parameter, NumberStyles.Any, CultureInfo.InvariantCulture, out factor))
                factor = double.Parse((string)parameter, NumberStyles.Any, CultureInfo.InvariantCulture);

            if (value is double)
            {
                return (double)value * factor;
            }
            return 0;
        }

        /// <summary>
        /// NotImplementedException
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
