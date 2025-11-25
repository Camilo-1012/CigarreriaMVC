var dataTable;

$(document).ready(function () {
    cargarTablaProductos();
});

function cargarTablaProductos() {
    dataTable = $('#tblProductos').DataTable({
        "ajax": {
            "url": "/Admin/Producto/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "codigoBarra", "width": "10%" },
            { "data": "nombre", "width": "20%" },
            { "data": "categoria", "width": "10%" },
            {
                "data": "precioCompra",
                "render": function (data) {
                    return "$ " + data.toFixed(0);
                },
                "width": "10%"
            },
            {
                "data": "precioVenta",
                "render": function (data) {
                    return "$ " + data.toFixed(0);
                },
                "width": "10%"
            },
            { "data": "stockActual", "width": "10%" },
            { "data": "stockMinimo", "width": "10%" },
            {
                "data": "activo",
                "render": function (data) {
                    return data
                        ? '<span class="badge bg-success">Sí</span>'
                        : '<span class="badge bg-secondary">No</span>';
                },
                "width": "5%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="text-center">
                            <a href="/Admin/Producto/Edit/${data}" 
                               class="btn btn-sm btn-warning">
                                <i class="fa-solid fa-pen-to-square"></i>
                            </a>
                            <a onclick=Delete("/Admin/Producto/Delete/${data}") 
                               class="btn btn-sm btn-danger">
                                <i class="fa-solid fa-trash"></i>
                            </a>
                        </div>`;
                },
                "width": "10%"
            }
        ],
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.13.1/i18n/es-ES.json"
        },
        "width": "100%"
    });
}

function Delete(url) {
    Swal.fire({
        title: '¿Está seguro?',
        text: "No podrá revertir esto",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sí, borrar'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        Swal.fire('Borrado', data.message, 'success');
                    } else {
                        Swal.fire('Error', data.message, 'error');
                    }
                }
            });
        }
    });
}
