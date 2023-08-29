using Application.Core.Features.Upload.Commands.SaveFiles;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Abstractions
{
    public interface IFileService
    {
        public Task<List<UploadResult>> SaveFile(IFormFileCollection files);
    }
}
