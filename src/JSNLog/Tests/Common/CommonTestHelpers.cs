﻿#if !DNXCORE50
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

/// <summary>
/// This testing related code lives in the main JSNLog project, so it can be shared by 
/// the DNX JSNLog.Tests project and the non-DNX JSNLog.Testsite project.
/// Tried to create a separate DNX class library to house this common code, but VS doesn't seem
/// to give you that option.
/// </summary>

namespace JSNLog.Tests.Common
{
    public class CommonTestHelpers
    {
        public static void SetConfigCache(string configXml, ILoggingAdapter logger = null)
        {
            // Set config cache in JavascriptLogging to contents of xe
            XmlElement xe = ConfigToXe(configXml);
            JavascriptLogging.SetJsnlogConfiguration(null, logger);
            JavascriptLogging.GetJsnlogConfiguration(() => xe);
        }

        public static XmlElement ConfigToXe(string configXml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(configXml);
            XmlElement xe = (XmlElement)doc.DocumentElement;

            return xe;
        }
    }
}
#endif