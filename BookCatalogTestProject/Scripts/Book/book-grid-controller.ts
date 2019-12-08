//declare var DataTable: any;

class BookGridController {
    private rowTemplate: string;
    private grid: any;

    private gridRowTemplateSelector: string = '#book_grid_row_template';
    private gridRowTemplateMarkupSelector: string = '#book-grid-row-template';

    private gridSelector: string = "#book_data_table";
    private gridBodySelector: string = "#book_tbody";

    public DrawCallback: (data: any) => void;

    //constructor(public business: BookBusiness) {
    //}

    public Initialize = () => {
        $("#books-table").DataTable();
        //this.InitGridRowTemplate();
        //this.InitializeGrid();
    }

    public InitGridRowTemplate = (): void => {
        this.rowTemplate = $(this.gridRowTemplateMarkupSelector + "> table > tbody > tr").html();
        $(this.gridRowTemplateSelector).append(this.rowTemplate);
        this.rowTemplate = $(this.gridRowTemplateSelector)[0].innerHTML;
    }

    public InitializeGrid(): void {
        $(this.gridSelector).DataTable();
        //this.grid = new DataTable();
        this.grid.init({
            src: $(this.gridSelector),
            dataTable: {
                "deferLoading": 0,
                "drawCallback": (settings) => {
                    this.DrawCallback(settings.aoData.map(function (obj) { return obj._aData }));
                },
                "preDrawCallback": () => {
                    ko.cleanNode($(this.gridBodySelector)[0]);
                },
                "responsive": true,
                "lengthMenu": [
                    [10, 20, 50, 100],
                    [10, 20, 50, 100]
                ],
                "pageLength": 20,
                "ajax": {
                    "url": ""//this.business.GetBooksUrl()
                },
                "createdRow": (row, data, index) => {
                    $(row).html(this.rowTemplate.format(index));
                },
            }
        });
    }
}