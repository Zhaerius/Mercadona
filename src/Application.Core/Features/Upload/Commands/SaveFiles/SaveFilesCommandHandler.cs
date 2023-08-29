using Application.Core.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Upload.Commands.SaveFiles
{
    public class SaveFilesCommandHandler : IRequestHandler<SaveFilesCommand, IEnumerable<UploadResult>>
    {
        private readonly IFileService _fileService;

        public SaveFilesCommandHandler(IFileService fileService)
        {
            _fileService = fileService;
        }

        public async Task<IEnumerable<UploadResult>> Handle(SaveFilesCommand request, CancellationToken cancellationToken)
        {
            return await _fileService.SaveFile(request.Files);
        }
    }
}
