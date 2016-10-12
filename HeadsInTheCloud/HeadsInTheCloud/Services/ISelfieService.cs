using HeadsInTheCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadsInTheCloud.Services
{
    public interface ISelfieService
    {
        Task AddSelfieAsync(Selfie selfie);
        Task<List<Selfie>> GetAllAsync();
    }
}
