using AssetManagement.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

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
        public void AddNewAsset(AddNewAssetDTO newassetDTO)
        {
            using (TransactionScope scope=new TransactionScope())
            {
                try
                {

                }
                catch (Exception)
                {

                    throw;
                }

                scope.Complete();
            }
            throw new NotImplementedException();
        }
    }
}
