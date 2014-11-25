﻿using System;
using System.Collections.Generic;

using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace NoiceVideoDownloader
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static SearchProvider searchProvider = new SearchProvider();
        public static SearchProvider SearchProvider
        {
            get { return searchProvider; }
        }

    }
}
