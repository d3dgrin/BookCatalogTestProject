class BookGridController {
    private rowTemplate: string;
    private gridRowTemplateMarkupSelector: string = '#book-grid-row-template';

    public DrawCallback: (data: any) => void;

    constructor(public business: BookBusiness) {
        business.OnBooksReceive = this.OnBookReceive;
    }

    public Initialize = () => {
        this.InitGridRowTemplate();
        this.InitializeGrid();
    }
    
    public InitGridRowTemplate = (): void => {
        this.rowTemplate = $(this.gridRowTemplateMarkupSelector + "> table > tbody > tr").html();
    }

    public InitializeGrid(): void {

        this.business.GetBooks();

        //$("#book-data-table").DataTable({
        //    //deferLoading: 0,
        //    //preDrawCallback: () => {
        //    //    ko.cleanNode($("book-tbody")[0]);
        //    //},
        //    //drawCallback: (oSettings) => {
        //    //    this.DrawCallback(oSettings.aoData.map(function (obj) { return obj._aData }));
        //    //},
        //    ajax: {
        //        url: this.business.GetBooksUrl(),
        //        dataSrc: 'Model'
        //    },
        //    columns: [
        //        {
        //            name: "Model",
        //            data: "Id"
        //        },
        //        {
        //            name: "Model",
        //            data: "Title"
        //        },
        //        {
        //            name: "Model",
        //            data: "PublicationDate"
        //        },
        //        {
        //            name: "Model",
        //            data: "Rating"
        //        },
        //        {
        //            name: "Model",
        //            data: "PagesCount"
        //        },
        //        {
        //            name: "Model",
        //            data: null,
        //            visible: false
        //        }
        //    ]
        //    //ordering: true,
        //    //order: [0, 'desc'],
        //    //createdRow: (row, data, index) => {
        //    //    $(row).html(this.rowTemplate.format(index));
        //    //    console.log("createdRow");
        //    //},
        //    //columnDefs: [
        //    //    { targets: 'sorting', orderable: true },
        //    //    { targets: 'non-sorting', orderable: false },
        //    //]
        //});
    }

    private OnBookReceive = (model: BooksModel): void => {
        $("#book-data-table").DataTable({
            //deferLoading: 0,
            //preDrawCallback: () => {
            //    ko.cleanNode($("book-tbody")[0]);
            //},
            //drawCallback: (oSettings) => {
            //    this.DrawCallback(oSettings.aoData.map(function (obj) { return obj._aData }));
            //},
            data: model.Books,
            //columns: [
            //    {
            //        name: "Model",
            //        data: "Id"
            //    },
            //    {
            //        name: "Model",
            //        data: "Title"
            //    },
            //    {
            //        name: "Model",
            //        data: "PublicationDate"
            //    },
            //    {
            //        name: "Model",
            //        data: "Rating"
            //    },
            //    {
            //        name: "Model",
            //        data: "PagesCount"
            //    },
            //    {
            //        name: "Model",
            //        data: null,
            //        visible: false
            //    }
            //],
            //ordering: true,
            //order: [0, 'desc'],
            createdRow: (row, data, index) => {
                $(row).html(this.rowTemplate.format(index));
                console.log("createdRow");
            },
            //columnDefs: [
            //    { targets: 'sorting', orderable: true },
            //    { targets: 'non-sorting', orderable: false },
            //]
        });
    }
}