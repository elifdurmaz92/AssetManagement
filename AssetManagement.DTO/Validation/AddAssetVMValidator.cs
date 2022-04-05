using AssetManagement.DTO.VM;
using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.DTO.Validation
{
    public class AddAssetVMValidator: AbstractValidator<AddAssetVM>
    {
        public AddAssetVMValidator()
        {
            RuleFor(x => x.AssetGroupID).GreaterThan(0).WithMessage("Ürün Grubunu seçiniz");
            RuleFor(x => x.AssetTypeID).GreaterThan(0).WithMessage("Ürün tipini seçiniz");
            RuleFor(x => x.AssetBrandID).GreaterThan(0).WithMessage("Marka seçiniz");
            RuleFor(x => x.AssetModelID).GreaterThan(0).WithMessage("Model seçiniz");
            RuleFor(x => x.CurrencyID).GreaterThan(0).WithMessage("Para birimini giriniz");
            RuleFor(x => x.Description).NotNull().WithMessage("Açıklama giriniz");
            RuleFor(x => x.Cost).GreaterThan(0).WithMessage("Maliyeti giriniz");
        }
    }
}
