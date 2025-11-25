var dataTable;

$(document).ready(function () {
    cargarTablaMovimientos();
});

function cargarTablaMovimientos() {
    dataTable = $('#tblMovimientos').DataTable({
        "ajax": {
            "url": "/Admin/MovimientosInventario/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "5%" },
            {
                "data": "fecha",
                "render": function (data) {
                    return new Date(data).toLocaleString();
                },
                "width": "20%"
            },
            { "data": "producto.nombre", "width": "25%" },
            { "data": "tipo", "width": "10%" },
            { "data": "cantidad", "width": "10%" },
            { "data": "observacion", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="text-center">
                            <a href="/Admin/MovimientosInventario/Edit/${data}" 
                               class="btn btn-sm btn-warning">
                                <i class="fa-solid fa-pen-to-square"></i>
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
