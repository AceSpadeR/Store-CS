
$(document).ready(function () {
    loadList();
});

var dataTable;

function loadList() {
    dataTable = $('#DT_Categories').DataTable({
        "ajax": {
            "url": "/api/category",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "25%" },
            { "data": "displayOrder", render: $.fn.dataTable.render.number(',', '.', 2, '$'), "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center"> 
                                <a href="/Categories/Upsert?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width: 100px;">
                                    <i class="far fa-edit"></i> Edit </a>
                                <a href="/Categories/Delete?id=${data}" class="btn btn-danger text-white" style="cursor:pointer; width: 100px;">
                                    <i class="far fa-trash-alt"></i> Delete </a>   
                            </div>`;
                }
                ,
                "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "No data found."
        },
        "width": "100%",
        "order": [[2, "asc"]]
    });
}
