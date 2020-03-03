class BookGridController {
    private rowTemplate: string;
    private grid: any;
    private gridRowTemplateMarkupSelector: string = '#books-grid-row-template';
    private gridSelector: string = "#books_data_table";
    private gridBodySelector: string = "#books_tbody";
    private defaultOrdering = { columnIndx: 2, direction: 'asc' };

    public DrawCallback: (data: any) => void;

    constructor(public business: BookBusiness) {
    }

    public Initialize() {
        this.business.GetAuthors();
        this.rowTemplate = $(this.gridRowTemplateMarkupSelector + "> table > tbody > tr").html();
        this.InitializeGrid();
    }

    public InitializeGrid(): void {
        var self = this;
        $.fn.dataTable.ext.errMode = function (settings, helpPage, message) {
        };
        this.grid = $(this.gridSelector).DataTable({
            proccessing: true,
            serverSide: true,
            ajax: {
                url: this.business.GetBooksUrl(),
                //dataSrc: 'Model',
                type: 'POST'
            },
            columnDefs: [
                { targets: 'sorting', orderable: true },
                { targets: 'non-sorting', orderable: false },
            ],
            ordering: true,
            order: [this.defaultOrdering.columnIndx, this.defaultOrdering.direction],
            createdRow: function (row, data, index) {
                $(row).html(self.rowTemplate.format(index));
            },
            preDrawCallback: function (settings) {
                ko.cleanNode($(self.gridBodySelector)[0]);
            },
            drawCallback: function (settings) {
                self.DrawCallback(settings.aoData.map(function (obj) { return obj._aData }));
            }
        });

        this.InitializeSubscriptions();
    }

    private InitializeSubscriptions(): void {
        $(document).off('grid.reload', this.GridReload).on('grid.reload', this.GridReload);
    }

    private GridReload = () => {
        this.grid.ajax.reload();
    }
}