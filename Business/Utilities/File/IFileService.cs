﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.File
{
    public interface IFileService
    {
        string FileSaveToServer(IFormFile file, string filePath);
        string FileSaveToFtp(IFormFile file);
        byte[] FileSaveToDatabase(IFormFile file);
        void FileDeleteToServer(string path);
        void FileDeleteToFtp(string path);  
    }
}
