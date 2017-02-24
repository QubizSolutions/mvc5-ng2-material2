using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Tesseract.Infrastructure;

namespace Tesseract.Web
{
    public class Config : IConfig
    {
        private string _ConnectionString;
        public string ConnectionString
        {
            get
            {
                if (_ConnectionString == null)
                    _ConnectionString = ConfigurationManager.ConnectionStrings["AuthorContext"].ConnectionString;

                return _ConnectionString;
            }
        }
    }
}