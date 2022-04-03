using AssetManagement.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace AssetManagement.DAL
{
    public class AssetActionDAL : IAssetActionDAL
    {
        private readonly IAssetDAL _assetDAL;
        private readonly IAssetStatusDAL _assetstatusDAL;
        private readonly IPersonnelDAL _persDAL;
        private readonly IStatusDAL _statusDAL;
        private readonly IAssetOwnerDAL _assetownerDAL;
        private readonly ICustomerDAL _customerDAL;
        private readonly IAssetCustomerDAL _assetCusDAL;
        private readonly IActionStatusDAL _actionstatusDAL;
        private readonly IMapper _map;
        public AssetActionDAL(IAssetDAL assetDAL, IAssetStatusDAL assetstatusDAL, IPersonnelDAL persDAL, IStatusDAL statusDAL, IAssetOwnerDAL assetownerDAL, ICustomerDAL customerDAL, IAssetCustomerDAL assetcusDAL, IActionStatusDAL actionstatusDAL,IMapper map)
        {
            _assetDAL = assetDAL;
            _assetstatusDAL = assetstatusDAL;
            _persDAL = persDAL;
            _statusDAL = statusDAL;
            _assetownerDAL = assetownerDAL;
            _customerDAL = customerDAL;
            _assetCusDAL = assetcusDAL;
            _actionstatusDAL = actionstatusDAL;
            _map = map;
        }
        public async Task<AssetActionDetailDTO> AssetActionDetailGET(int registrationNumber)
        {
            AssetActionDetailDTO assetActionDetailDTO = new AssetActionDetailDTO()
            {
                AssetActionListDTO = new AssetActionListDTO(),
                ActionStatusDTO = new List<ActionStatusDTO>()
            };
            try
            {

                int AssetID = _assetDAL.Get(x => x.RegistrationNumber == registrationNumber).ID;
                var AssetStatus = await _assetstatusDAL.GetAllAsync();
                var Personnel = await _persDAL.GetAllAsync();
                var Status = await _statusDAL.GetAllAsync();
                var AssetOwner = await _assetownerDAL.GetAllAsync();
                var AssetCustomer = await _assetCusDAL.GetAllAsync();
                var Customer = await _customerDAL.GetAllAsync();

                var AssetStatusTarih = AssetStatus.OrderBy(x => x.Date).First().Date;

                var query = (from ass in AssetStatus
                             join pers in Personnel on ass.PersonnelID equals pers.ID
                             join sta in Status on ass.StatusID equals sta.ID
                             join aso in AssetOwner on ass.AssetID equals aso.AssetID into asoo
                             from leftAso in asoo.DefaultIfEmpty()
                             join pers1 in Personnel on leftAso?.PersonnelID equals pers1.ID into pers11
                             from leftpers1 in pers11.DefaultIfEmpty()
                             join ascus in AssetCustomer on ass.AssetID equals ascus.AssetID into ascuss
                             from leftascus in ascuss.DefaultIfEmpty()
                             join cus in Customer on leftascus?.CustomerID equals cus.ID into cuss
                             from leftcus in cuss.DefaultIfEmpty()
                             where ass.AssetID == AssetID

                             select new AssetActionListDTO
                             {
                                 StatusID = ass.StatusID,
                                 EntryDate = AssetStatusTarih,
                                 RegisteringRerson = pers.FirstName + " " + pers.LastName,
                                 LastStatus = sta.Description,
                                 LastOperationDate = ass.Date,
                                 ActionTeam = leftpers1.MasterID == leftpers1.ID ? (leftpers1.FirstName + " " + leftpers1.LastName) : " ",
                                 ActionPersonnel = leftpers1.MasterID != leftpers1.ID ? (leftpers1.FirstName + " " + leftpers1.LastName) : " ",
                                 ActionCustomer = leftcus?.FirstName ?? " ",
                                 Note = ass.Note

                             }).ToList().OrderByDescending(x => x.LastOperationDate).First();


                assetActionDetailDTO.AssetActionListDTO = query;
                var statusTable= await _actionstatusDAL.GetAllAsync(x => x.StatusID == query.StatusID);
                assetActionDetailDTO.ActionStatusDTO = _map.Map<IEnumerable<ActionStatusDTO>>(statusTable);
                assetActionDetailDTO.RegistrationNumber = registrationNumber;
                assetActionDetailDTO.AssetID = AssetID;


            }
            catch (Exception)
            {

                throw;
            }
            return assetActionDetailDTO;

        }
    }
}
