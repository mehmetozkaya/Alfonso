using ApplicationCore.Entities.FeatureAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IFeatureService
    {
        Task<IReadOnlyCollection<Feature>> GetFeatures(int catalogItemId);

    }
}
