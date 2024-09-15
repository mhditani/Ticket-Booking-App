﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.Repositories.Interfaces
{
    public interface IUtiltyRepo
    {
        Task<string> SaveImagePath(string DirName, IFormFile file);

        Task<string> EditFilePath(string DirName, IFormFile file, string fullPath);

        Task DeleteFile(string filePath,  string DirName);
    }
}
