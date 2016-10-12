using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadsInTheCloud.Models;

namespace HeadsInTheCloud.Services
{
    public class SelfieService : ISelfieService
    {
        public Task AddSelfieAsync(Selfie selfie)
        {
            // TODO
            return Task.Run(() => { });
        }

        public Task<List<Selfie>> GetAllAsync()
        {
            return Task.Run<List<Selfie>>(() => { return new List<Selfie>(); });
        }
    }
}
