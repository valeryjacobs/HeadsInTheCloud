using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadsInTheCloud.Models;
using Microsoft.WindowsAzure.MobileServices;

namespace HeadsInTheCloud.Services
{
    public class SelfieService : ISelfieService
    {
        public static string ApplicationURL = @"https://headsinthecloud.azurewebsites.net";

        MobileServiceClient _client;
        private IMobileServiceTable<Selfie> _selfieTable;

        public SelfieService()
        {
            _client = new MobileServiceClient(ApplicationURL);
            _selfieTable = _client.GetTable<Selfie>();
        }

        public Task AddSelfieAsync(Selfie selfie)
        {
            return _selfieTable.InsertAsync(selfie);
        }

        public Task<List<Selfie>> GetAllAsync()
        {
            return _selfieTable.ToListAsync();
        }
    }
}
