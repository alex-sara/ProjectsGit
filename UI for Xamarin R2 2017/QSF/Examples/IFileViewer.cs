using System.IO;
using System.Threading.Tasks;

namespace Examples
{
    public interface IFileViewer
    {
        Task View(Stream stream, string filename);
    }
}