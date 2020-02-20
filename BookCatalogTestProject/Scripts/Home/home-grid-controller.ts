declare var DataTable: any;

class HomeGridController {
    private rowTemplate: string;
    private grid: any;
    private gridRowTemplateMarkupSelector: string = '#books-grid-row-template';
    private gridSelector: string = "#books_data_table";
    private gridBodySelector: string = "#books_tbody";
    private defaultOrdering = { columnIndx: 2 /* Time of Submission */, direction: 'asc' };

    public DrawCallback: (data: any) => void;

    constructor(public business: HomeBusiness) {
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
        $(this.gridSelector).DataTable({
            ajax: {
                url: this.business.GetBooksUrl(),
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
            //columns: [
            //    { data: 'BookId' },
            //    { data: 'Title' },
            //    { data: 'PublicationDate' },
            //    { data: 'Rating' },
            //    { data: 'PagesCount' }
            //],
            columnDefs: [
                { targets: 'sorting', orderable: true },
                { targets: 'non-sorting', orderable: false },
            ]
        });


        //ko.options.deferUpdates = true;
        //var self = this;
        //this.grid = new Datatable();
        //this.grid.resetFilter = () => { return this.ResetGrid() };
        //$.fn.dataTable.ext.errMode = function (settings, helpPage, message) {
        //};

        //this.grid.init({
        //    src: $(self.gridSelector),
        //    dataTable: {
        //        "deferLoading": 0,
        //        "fnDrawCallback": (oSettings) => {
        //            self.DrawCallback(oSettings.aoData.map(function (obj) { return obj._aData }));
        //        },
        //        "fnPreDrawCallback": () => {
        //            ko.cleanNode($(self.gridBodySelector)[0]);
        //        },
        //        "responsive": true,
        //        "lengthMenu": [
        //            [10, 20, 50, 100],
        //            [10, 20, 50, 100]
        //        ],
        //        "pageLength": 20,
        //        "ajax": {
        //            "url": this.business.GetBooksUrl()
        //        },
        //        "ordering": true,
        //        //"order": [this.defaultOrdering.columnIndx, this.defaultOrdering.direction],
        //        "createdRow": (row, data, index) => {
        //            $(row).html(self.rowTemplate.format(index));
        //        },
        //        "columnDefs": [
        //            { targets: 'sorting', orderable: true },
        //            { targets: 'non-sorting', orderable: false },
        //        ]
        //    }
        //});
    }
}