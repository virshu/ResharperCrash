using System.Collections.Generic;
using System.Linq;

namespace DataHandler
{
    public static class DataAoLookupHandler
    {
        public static readonly Dictionary<int, DataAoLookupHandlerBase> Handlers = new()
        {
            {
                29,
                new DataAoLookupHandlerBase
                {
                    InitializeQueryableFunc = context => context.PersonDescriptor.Select(s => new DataAoLookupResult
                    {
                        RefId = s.PersonDescriptorId,
                        RefOrderBy = $"{s.CreateDate}",
                        RefDate =$"{s.CreateDate}",
                        RefDetails=$"{s.ItemLocation} {s.DescriptorText} ",
                        RefIdentity = s.PersonId,
                        RefDateField = s.CreateDate
                    }),
                    UpdateEntityFunc = (context, toId, refId) =>
                    {
                        context.PersonDescriptor.First(w => w.PersonDescriptorId == refId).PersonId = toId;
                        return context.SaveChanges();
                    }
                }
            },
            {
                30,
                new DataAoLookupHandlerBase
                {
                    InitializeQueryableFunc = context => context.PersonDna.Select(s => new DataAoLookupResult
                    {
                        RefId = s.PersonDnaId,
                        RefOrderBy = $"{s.DnaDateRequired}",
                        RefDate =$"{s.CreateDate}",
                        RefDetails=$"[GATHER]:{s.DnaDateGathered};"
                        // + (s.DnaDisposition > 0 ? "[DISPO]:" : "")
                        ,
                        RefIdentity = s.PersonId,
                        RefDateField = s.CreateDate
                    }),
                    UpdateEntityFunc = (context, toId, refId) =>
                    {
                        context.PersonDna.First(w => w.PersonDnaId == refId).PersonId = toId;
                        return context.SaveChanges();
                    }
                }
            },

        };
    }
}
