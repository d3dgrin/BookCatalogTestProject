class BookGridController {
    private rowTemplate: string;
    private gridRowTemplateMarkupSelector: string = '#book-grid-row-template';

    public DrawCallback: (data: any) => void;

    constructor(public business: BookBusiness) {
    }

    public Initialize = () => {
        this.InitGridRowTemplate();
        this.InitializeGrid();
    }
    
    public InitGridRowTemplate = (): void => {
        this.rowTemplate = $(this.gridRowTemplateMarkupSelector + "> table > tbody > tr").html();
    }

    public InitializeGrid(): void {
        $("#book-data-table").DataTable({
            deferLoading: 0,
            preDrawCallback: () => {
                //ko.cleanNode($("book-tbody")[0]);
            },
            drawCallback: (oSettings) => {
                this.DrawCallback(oSettings.aoData.map(function (obj) { return obj._aData }));
            },
            ajax: {
                url: this.business.GetBooksUrl()
            },
            ordering: true,
            order: [0, 'desc'],
            createdRow: (row, data, index) => {
                $(row).html(this.rowTemplate.format(index));
            },
            columnDefs: [
                { targets: 'sorting', orderable: true },
                { targets: 'non-sorting', orderable: false },
            ]
        });
    }
}