window.addEventListener('DOMContentLoaded', event => {
    // Simple-DataTables
    // https://github.com/fiduswriter/Simple-DataTables/wiki

    const datatablesSimple = document.getElementById('datatablesSimple');
    if (datatablesSimple) {
        new simpleDatatables.DataTable(datatablesSimple);
    }

    const datatablesPersAssetList = document.getElementById('datatablesPersAssetList');
    if (datatablesPersAssetList) {
        new simpleDatatables.DataTable(datatablesPersAssetList);
    }

    const datatablesAllAsset = document.getElementById('datatablesAllAsset');
    if (datatablesAllAsset) {
        new simpleDatatables.DataTable(datatablesAllAsset);
    }
    const datatablesTeamassetList = document.getElementById('datatablesTeamassetList');
    if (datatablesTeamassetList) {
        new simpleDatatables.DataTable(datatablesTeamassetList);
    }

});
