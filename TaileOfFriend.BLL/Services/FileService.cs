using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TaileOfFriend.BLL.Interfaces;
using TaileOfFriend.DAL.Enteties;
using TaileOfFriend.DAL.Interfaces;

namespace TaileOfFriend.BLL.Services
{
    public class FileService:IFileService
    {
        private IHostingEnvironment fileHost;
        public IUnitOfWork Database { get; set; }

        public FileService(IUnitOfWork uow, IHostingEnvironment _fileHost)
        {
            Database = uow;
            fileHost = _fileHost;
        }

        public async Task<Image> AddImage(IFormFile uploadedFile)
        {
            if (uploadedFile == null)
            {
                throw (new Exception("Файл не знайдено"));

            }

            string path = "/Files/" + uploadedFile.FileName;
            using (var fileStream = new FileStream(fileHost.WebRootPath + path, FileMode.Create))
            {
                await uploadedFile.CopyToAsync(fileStream);
            }

            Image image = new Image { Url = path };
            Database.Images.Insert(image);

            await Database.SaveAsync();

            return image;
        }

        public async Task Delete(int id)
        {
            var photo = Database.Images.GetById(id);
            if (photo != null)
            {
                File.Delete(fileHost + photo.Url);
                Database.Images.Delete(photo);
                await Database.SaveAsync();
            }

        }


    }
}
