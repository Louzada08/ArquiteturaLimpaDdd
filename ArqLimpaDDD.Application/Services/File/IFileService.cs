using ArqLimpaDDD.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace ArqLimpaDDD.Application.Services.File;

public interface IFileService
{
    public byte[] GetFile(string filename);
    public Task<FileDetailVO> SaveFileToDisk(IFormFile file);
    public Task<Dictionary<string, string>> SaveFilesToDisk(IList<IFormFile> file);
}
