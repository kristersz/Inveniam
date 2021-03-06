﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Inveniam.Infrastructure.Extensions
{
	public static class ObjectExtensions
	{
		public static string Serialize<T>(this T value)
		{
			if (value == null)
			{
				return string.Empty;
			}
			try
			{
				var xmlserializer = new XmlSerializer(typeof(T));
				var stringWriter = new StringWriter();
				using (var writer = XmlWriter.Create(stringWriter))
				{
					xmlserializer.Serialize(writer, value);
					return stringWriter.ToString();
				}
			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred", ex);
			}
		}

		public static string AsString(this XmlDocument xmlDoc)
		{
			if (xmlDoc == null)
			{
				throw new ArgumentNullException("XmlDocument");
			}

			return xmlDoc.OuterXml;
		}
	}
}
