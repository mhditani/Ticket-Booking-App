using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Repositories.Interfaces;

namespace TicketBooking.Repositories.Implementations
{
    public class UtilityRepo : IUtiltyRepo
    {
        private readonly IWebHostEnvironment env;
        private readonly IHttpContextAccessor contextAccessor;

        public UtilityRepo(IWebHostEnvironment env, IHttpContextAccessor contextAccessor)
        {
            this.env = env;
            this.contextAccessor = contextAccessor;
        }

        public Task DeleteFile(string filePath, string DirName)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return Task.CompletedTask;
            }
            var filename = Path.GetFileName(filePath);
            var completedFilePath = Path.Combine(env.WebRootPath, DirName, filename);
            if (File.Exists(completedFilePath))
            {
                File.Delete(completedFilePath);
            }
            return Task.CompletedTask;
        }

        public async Task<string> EditFilePath(string DirName, IFormFile file, string fullPath)
        {
            await DeleteFile(fullPath, DirName);
            return await SaveImagePath(DirName, file);
        }

        public async Task<string> SaveImagePath(string DirName, IFormFile file)
        {
            string dir = Path.Combine(env.WebRootPath, DirName);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            var extension = Path.GetExtension(file.FileName);
            var filename = $"{Guid.NewGuid()} {extension}";
            string completeFilePath = Path.Combine(dir, filename);
            using(var memoryStream =  new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var content = memoryStream.ToArray();
                await File.WriteAllBytesAsync(completeFilePath, content);
            }
            var basePath = $"{contextAccessor.HttpContext.Request.Scheme}://{contextAccessor.HttpContext}";
            var fullPath = Path.Combine(basePath, DirName, filename).Replace("\\", "/");
            return fullPath;
        }
    }
}
