using System.Collections.ObjectModel;
using System.Linq;

namespace CollectionObserve;

internal static class ObservableCollectionAddition
{
    public static bool Rm(this ObservableCollection<Animal> ok, string arg)
    {
        return ok.Remove(ok.SingleOrDefault(r => r.Title == arg));
    }

    public static bool Exist(this ObservableCollection<Animal> ok, string arg)
    {
        return ok.Contains(ok.SingleOrDefault(r => r.Title == arg));
    }

    public static int Index(this ObservableCollection<Animal> ok, string arg)
    {
        return ok.IndexOf(ok.SingleOrDefault(r => r.Title == arg));
    }
}