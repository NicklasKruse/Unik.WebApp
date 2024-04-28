﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontConnectLibrary.Interfaces
{
    public interface IGetContentType
    {
        string GetType(string path);
        Dictionary<string,string> GetMimeTypes();
    }
}
