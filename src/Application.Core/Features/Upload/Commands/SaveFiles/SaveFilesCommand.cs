using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Upload.Commands.SaveFiles
{
    public class SaveFilesCommand : IRequest<IEnumerable<UploadResult>>
    {
        public SaveFilesCommand(IFormFileCollection files)
        {
            Files = files;
        }

        public IFormFileCollection Files { get; set; }
    }
}
