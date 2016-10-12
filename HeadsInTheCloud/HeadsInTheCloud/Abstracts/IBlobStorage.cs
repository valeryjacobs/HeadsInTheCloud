using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadsInTheCloud.Abstracts
{
    public interface IBlobStorage
    {
        Task SaveMediaFile(Stream stream, string name);
    }
}
