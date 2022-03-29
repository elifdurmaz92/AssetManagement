using AssetManagement.Core.Entity;
using AssetManagement.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Transactions;

namespace AssetManagement.DAL
{
    public class AddNewAssetDAL : IAddNewAssetDAL
    {
        #region Fields
        IAssetDAL _assetDAL;
        IAssetBarcodeDAL _barcodeDAL;
        IAssetWithoutBarcodeDAL _withoutBarcodeDAL;
        IPriceDAL _priceDAL;
        IAssetDocumentDAL _documentDAL;
        IAssetStatusDAL _assetStatusDAL;
        #endregion

        public AddNewAssetDAL(IAssetDAL assetDAL, IAssetBarcodeDAL barcodeDAL, IAssetWithoutBarcodeDAL withoutBarcodeDAL, IPriceDAL priceDAL, IAssetDocumentDAL documentDAL, IAssetStatusDAL assetStatusDAL)
        {
            _assetDAL = assetDAL;
            _barcodeDAL = barcodeDAL;
            _withoutBarcodeDAL = withoutBarcodeDAL;
            _priceDAL = priceDAL;
            _documentDAL = documentDAL;
            _assetStatusDAL = assetStatusDAL;

        }
        public void AddNewAsset(AddNewAssetDTO newassetDTO)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {

                    var asset = AddNewAssetDTOToAsset(newassetDTO);

                    _assetDAL.Add(asset);

                    int lastRecord = _assetDAL.GetAll().OrderByDescending(x => x.ID).First().ID;
                    if (newassetDTO.IsBarcode == true) //Barcodlu olma durumuna göre tabloya ekleme yapılacak
                    {
                        var bardoce = AddNewAssetDTOToAssetBarcode(newassetDTO, lastRecord);
                        _barcodeDAL.Add(bardoce);
                    }
                    else
                    {
                        var withoutBarcode = AddNewAssetDTOToAssetBarcodeWithout(newassetDTO, lastRecord);
                        _withoutBarcodeDAL.Add(withoutBarcode);
                    }
                    if (newassetDTO.FilePath != null)
                    {
                        var document = AddNewAssetDTOToAssetDocument(newassetDTO, lastRecord);
                        _documentDAL.Add(document);
                    }
                    if (newassetDTO.AssetPrice != 0)
                    {
                        var assetPrice = AddNewAssetDTOToAssetPrice(newassetDTO, lastRecord);
                        _priceDAL.Add(assetPrice);
                    }

                    var assetStatus = AddNewAssetDTOToAssetStatus(newassetDTO, lastRecord);
                    _assetStatusDAL.Add(assetStatus);



                }
                catch (Exception)
                {

                    throw;
                }

                scope.Complete();
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// Apiden aldığım model den ürün modele dönüştürür
        /// </summary>
        /// <param name="newassetDTO"></param>
        /// <returns></returns>
        public Asset AddNewAssetDTOToAsset(AddNewAssetDTO newassetDTO)
        {
            Asset asset = new Asset()
            {
                CompanyID = newassetDTO.CompanyID,
                AssetGroupID = newassetDTO.AssetGroupID,
                AssetBrandID = newassetDTO.AssetBrandID,
                AssetModelID = newassetDTO.AssetModelID,
                CurrencyID = newassetDTO.CurrencyID,
                Description = newassetDTO.Description,
                Cost = newassetDTO.Cost,
                IsBarcode = newassetDTO.IsBarcode,
                Guarantee = newassetDTO.Guarantee,
                EntryDate = newassetDTO.EntryDate,
                RetireDate = newassetDTO.RetireDate,
                CreatedBy = newassetDTO.CreatedBy,
                CreatedDate = newassetDTO.CreatedDate,
                ModifiedBy = newassetDTO.ModifiedBy,
                ModifiedDate = newassetDTO.ModifiedDate,
                IsActive = newassetDTO.IsActive
            };

            return asset;
        }

        public AssetBarcode AddNewAssetDTOToAssetBarcode(AddNewAssetDTO newassetDTO, int assetID)
        {
            AssetBarcode assetBarcode = new AssetBarcode()
            {
                AssetID = assetID,
                Barcode = newassetDTO.Barcode,
                CreatedBy = newassetDTO.CreatedBy,
                CreatedDate = newassetDTO.CreatedDate,
                ModifiedBy = newassetDTO.ModifiedBy,
                ModifiedDate = newassetDTO.ModifiedDate,
                IsActive = newassetDTO.IsActive
            };

            return assetBarcode;
        }

        public AssetWithoutBarcode AddNewAssetDTOToAssetBarcodeWithout(AddNewAssetDTO newassetDTO, int assetID)
        {
            AssetWithoutBarcode assetWithoutBarcode = new AssetWithoutBarcode()
            {
                AssetID = assetID,
                UnitID = newassetDTO.UnitID,
                Quantity = newassetDTO.Quantity,
                CreatedBy = newassetDTO.CreatedBy,
                CreatedDate = newassetDTO.CreatedDate,
                ModifiedBy = newassetDTO.ModifiedBy,
                ModifiedDate = newassetDTO.ModifiedDate,
                IsActive = newassetDTO.IsActive
            };

            return assetWithoutBarcode;
        }

        public AssetDocument AddNewAssetDTOToAssetDocument(AddNewAssetDTO newassetDTO, int assetID)
        {
            AssetDocument assetDocument = new AssetDocument()
            {
                AssetID = assetID,
                PageCode = newassetDTO.PageCode,
                FilePath = newassetDTO.FilePath,
                CreatedBy = newassetDTO.CreatedBy,
                CreatedDate = newassetDTO.CreatedDate,
                ModifiedBy = newassetDTO.ModifiedBy,
                ModifiedDate = newassetDTO.ModifiedDate,
                IsActive = newassetDTO.IsActive
            };

            return assetDocument;
        }

        public AssetStatus AddNewAssetDTOToAssetStatus(AddNewAssetDTO newassetDTO, int assetID)
        {
            AssetStatus assetStatus = new AssetStatus()
            {
                AssetID = assetID,
                PersonnelID = newassetDTO.PersonnelID,
                Note = newassetDTO.StatusNote,
                Date = newassetDTO.Date,
                CreatedBy = newassetDTO.CreatedBy,
                CreatedDate = newassetDTO.CreatedDate,
                ModifiedBy = newassetDTO.ModifiedBy,
                ModifiedDate = newassetDTO.ModifiedDate,
                IsActive = newassetDTO.IsActive
            };

            return assetStatus;
        }
        public AssetPrice AddNewAssetDTOToAssetPrice(AddNewAssetDTO newassetDTO, int assetID)
        {
            AssetPrice assetPrice = new AssetPrice()
            {
                AssetID = assetID,
                Price = newassetDTO.AssetPrice,
                CurrencyID = newassetDTO.AssetPriceCurrencyID,
                Date = newassetDTO.Date,
                CreatedBy = newassetDTO.CreatedBy,
                CreatedDate = newassetDTO.CreatedDate,
                ModifiedBy = newassetDTO.ModifiedBy,
                ModifiedDate = newassetDTO.ModifiedDate,
                IsActive = newassetDTO.IsActive
            };

            return assetPrice;
        }
    }
}
