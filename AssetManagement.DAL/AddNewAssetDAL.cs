using AssetManagement.DTO.VM;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.DAL
{
    public class AddNewAssetDAL : IAddNewAssetDAL
    {
        IAssetDAL _assetDAL;
        IAssetBarcodeDAL _barcodeDAL;
        IAssetWithoutBarcodeDAL _withoutBarcodeDAL;
        IPriceDAL _priceDAL;
        IAssetDocumentDAL _documentDAL;
        public AddNewAssetDAL(IAssetDAL assetDAL, IAssetBarcodeDAL barcodeDAL,IAssetWithoutBarcodeDAL withoutBarcodeDAL,IPriceDAL priceDAL,IAssetDocumentDAL documentDAL)
        {
            _assetDAL = assetDAL;
            _barcodeDAL = barcodeDAL;
            _withoutBarcodeDAL = withoutBarcodeDAL;
            _priceDAL = priceDAL;
            _documentDAL = documentDAL;

        }
        public void AddNewAsset(AddAssetVM assetVM)
        {
            throw new NotImplementedException();
        }
    }
}
