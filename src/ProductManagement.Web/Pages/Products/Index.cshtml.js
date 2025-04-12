$(function () {
    var l = abp.localization.getResource('ProductManagement');
    var dataTable = $('#ProductsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[0, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(
                productManagement.products.product.getList),
            columnDefs: [
                /* TODO: Column definitions */
                {
                    title: l('Name'),
                    data: "name"
                },
                {
                    title: l('Category'),
                    data: "categoryName",
                    orderable: false
                },
                {
                    title: l('Price'),
                    data: "price"
                },
                {
                    title: l('Stock-State'),
                    data: "stockState",
                    render: function (data) {
                        return l('Enum:stockState.' + data);
                    }

                },
                {
                    title: l('Creation-Time'),
                    data: "creationTime",
                    dataFormat: 'date'
                }

            ]
        })
    );

    var createModal = new abp.ModalManager(abp.appPath + 'Products/CreateProductModal');
    createModal.onResult(function () {
        dataTable.ajax.reload();
    });
    $('#NewProductButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
