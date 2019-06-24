using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaileOfFriend.DAL.Enteties;

namespace TaileOfFriend.BLL.Interfaces
{
    public interface IFileService
    {
        Task<Image> AddImage(IFormFile uploadedFile);
        Task Delete(int id);
    }
}
