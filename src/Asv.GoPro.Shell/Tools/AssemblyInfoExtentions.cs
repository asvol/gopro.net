﻿using System;
using System.Reflection;

namespace Dm734.Core
{
    public static class AssemblyInfoExtentions
    {
        public static Version GetVersion(this Assembly src)
        {
            return src.GetName().Version;
        }

        public static string GetInformationalVersion(this Assembly src)
        {
            var attributes = src.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false);
            return attributes.Length == 0 ? "" : ((AssemblyInformationalVersionAttribute)attributes[0]).InformationalVersion;
        }

        public static string GetTitle(this Assembly src)
        {
            var attributes = src.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            if (attributes.Length > 0)
            {
                var titleAttribute = (AssemblyTitleAttribute)attributes[0];
                if (titleAttribute.Title.Length > 0) return titleAttribute.Title;
            }
            return System.IO.Path.GetFileNameWithoutExtension(src.CodeBase);
        }

        public static string GetProductName(this Assembly src)
        {
            var attributes = src.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
            return attributes.Length == 0 ? "" : ((AssemblyProductAttribute)attributes[0]).Product;
        }

        public static string GetDescription(this Assembly src)
        {
            var attributes = src.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
            return attributes.Length == 0 ? "" : ((AssemblyDescriptionAttribute)attributes[0]).Description;
        }

        public static string GetCopyrightHolder(this Assembly src)
        {
            var attributes = src.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            return attributes.Length == 0 ? "" : ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
        }

        public static string GetCompanyName(this Assembly src)
        {
            var attributes = src.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
            return attributes.Length == 0 ? "" : ((AssemblyCompanyAttribute)attributes[0]).Company;
        }
    }

}
