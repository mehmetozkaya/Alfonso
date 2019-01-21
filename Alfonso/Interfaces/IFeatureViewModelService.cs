using Alfonso.ViewModels;
using System.Threading.Tasks;

namespace Alfonso.Interfaces
{
    public interface IFeatureViewModelService
    {
        Task<FeatureViewModel> GetFeatures(int catalogItemId);
    }
}
