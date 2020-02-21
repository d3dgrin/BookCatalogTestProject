class AuthorGridController {
    private rowTemplate: string;
    private grid: any;
    private gridRowTemplateMarkupSelector: string = '#authors-grid-row-template';
    private gridSelector: string = "#authors_data_table";
    private gridBodySelector: string = "#authors_tbody";
    private defaultOrdering = { columnIndx: 2 /* Time of Submission */, direction: 'asc' };

    public DrawCallback: (data: any) => void;

    constructor(public business: AuthorBusiness) {
    }

    public Initialize() {
        this.rowTemplate = $(this.gridRowTemplateMarkupSelector + "> table > tbody > tr").html();
        this.InitializeGrid();
    }

    public InitializeGrid(): void {
        debugger;
        var self = this;
        $.fn.dataTable.ext.errMode = function (settings, helpPage, message) {
        };
        this.grid = $(this.gridSelector).DataTable({
            ajax: {
                url: this.business.GetAuthorsUrl(),
                dataSrc: 'Model'
            },
            deferLoading: 0,
            createdRow: function (row, data, index) {
                $(row).html(self.rowTemplate.format(index));
            },
            preDrawCallback: function (settings) {
                ko.cleanNode($(self.gridBodySelector)[0]);
            },
            drawCallback: function (settings) {
                self.DrawCallback(settings.aoData.map(function (obj) { return obj._aData }));
            },
            columnDefs: [
                { targets: 'sorting', orderable: true },
                { targets: 'non-sorting', orderable: false },
            ]
        });
    }
}