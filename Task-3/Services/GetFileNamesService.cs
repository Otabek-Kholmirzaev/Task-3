using Microsoft.Extensions.Options;
using Task_3.Options;

namespace Task_3.Services
{
    public class GetFileNamesService 
    {
        private readonly FileNamesOption _fileNamesOption;
        public GetFileNamesService(IOptions<FileNamesOption> fileNamesOption) 
        {
            _fileNamesOption = fileNamesOption.Value;
        }

        public FileNamesOption GetFileNames()
        {
            return _fileNamesOption;
        }
    }
}
