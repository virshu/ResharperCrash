using System;
using System.Linq;
using System.Threading.Tasks;
using GenerateTables.Models;
using Microsoft.EntityFrameworkCore;

namespace DataHandler
{
    public interface IDataHandlerService
    {
        Task Run();
    }

    public class DataHandlerService : IDataHandlerService
    {
        private readonly AAtims _db;

        public DataHandlerService(AAtims db) => _db = db;

        public async Task Run()
        {
            int loaded = await (from x in _db.AoWizard select x.AoWizardId).FirstAsync();
            Console.WriteLine($"Completed {loaded}");

            Console.WriteLine(DataAoLookupHandler.Handlers.Count);

        }
    }
}
