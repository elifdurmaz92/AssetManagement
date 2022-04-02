using AssetManagement.Core.Entity;
using AssetManagement.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.DAL
{
    public interface ITeamAssetDAL : IEntityRepository<TeamAssetList>
    {
    }
}
