using Alfonso.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alfonso.Interfaces
{
    public interface IFeatureRazorService
    {
        Task<IEnumerable<FeatureViewModel>> GetFeatures(int catalogItemId);
    }
}
