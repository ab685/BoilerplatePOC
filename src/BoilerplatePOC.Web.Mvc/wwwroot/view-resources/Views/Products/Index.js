(function ($) {
    var _productService = abp.services.app.products,
        l = abp.localization.getSource('BoilerplatePOC'),
        _$modal = $('#ProductCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#ProductsTable');

    var _$ProductsTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        listAction: {
            ajaxFunction: _productService.getAll,
            inputFilter: function () {
                return $('#ProductsSearchForm').serializeFormToObject(true);
            }
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$ProductsTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [
            {
                targets: 0, // Control column for row expansion
                className: 'control',
                defaultContent: '',
            },
            {
                targets: 1, // Product Name
                data: 'name',
                sortable: true
            },
            {
                targets: 2, // Description
                data: 'description',
                sortable: true,
                render: data => data ? data : '<i>No Description</i>'
            },
            {
                targets: 3, // Price
                data: 'price',
                sortable: true,
                render: data => `$${data.toFixed(2)}`
            },
            {
                targets: 4, // SKU
                data: 'sku',
                sortable: true
            },
            {
                targets: 5, // Stock Quantity
                data: 'stockQuantity',
                sortable: true,
                render: data => `<span>${data}</span>`
            },
            {
                targets: 6, // Is Active
                data: 'isActive',
                sortable: false,
                render: data => `<input type="checkbox" disabled ${data ? 'checked' : ''}>`
            },
            {
                targets: 7, // Action Buttons
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-Product" data-Product-id="${row.id}" data-toggle="modal" data-target="#ProductEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-Product" data-Product-id="${row.id}" data-product-name="${row.name}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>'
                    ].join('');
                }
            }
        ]

    });

    _$form.find('.save-button').click(function (e) {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var Product = _$form.serializeFormToObject();

        abp.ui.setBusy(_$modal);

        _productService
            .create(Product)
            .done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$ProductsTable.ajax.reload();
            })
            .always(function () {
                abp.ui.clearBusy(_$modal);
            });
    });

    $(document).on('click', '.delete-Product', function () {
        var ProductId = $(this).attr('data-Product-id');
        var tenancyName = $(this).attr('data-product-name');

        deleteProduct(ProductId, tenancyName);
    });

    $(document).on('click', '.edit-Product', function (e) {
        var ProductId = $(this).attr('data-Product-id');

        abp.ajax({
            url: abp.appPath + 'Products/EditModal?ProductId=' + ProductId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#ProductEditModal div.modal-content').html(content);
            },
            error: function (e) {
            }
        });
    });

    abp.event.on('product.edited', (data) => {
        _$ProductsTable.ajax.reload();
    });

    function deleteProduct(ProductId, tenancyName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                tenancyName
            ),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _productService
                        .delete({
                            id: ProductId
                        })
                        .done(() => {
                            abp.notify.info(l('SuccessfullyDeleted'));
                            _$ProductsTable.ajax.reload();
                        });
                }
            }
        );
    }

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', (e) => {
        _$ProductsTable.ajax.reload();
    });

    $('.btn-clear').on('click', (e) => {
        $('input[name=Keyword]').val('');
        $('input[name=IsActive][value=""]').prop('checked', true);
        _$ProductsTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$ProductsTable.ajax.reload();
            return false;
        }
    });
})(jQuery);
