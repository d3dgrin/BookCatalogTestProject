var BookGridController = /** @class */ (function () {
    function BookGridController(business) {
        var _this = this;
        this.business = business;
        this.gridRowTemplateSelector = '#book_grid_row_template';
        this.gridRowTemplateMarkupSelector = '#book-grid-row-template';
        this.gridSelector = "#book_data_table";
        this.gridBodySelector = "#book_tbody";
        this.InitGridRowTemplate = function () {
            _this.rowTemplate = $(_this.gridRowTemplateMarkupSelector + "> table > tbody > tr").html();
            $(_this.gridRowTemplateSelector).append(_this.rowTemplate);
            _this.rowTemplate = $(_this.gridRowTemplateSelector)[0].innerHTML;
        };
    }
    BookGridController.prototype.Initialize = function () {
        this.InitGridRowTemplate();
        this.InitializeGrid();
    };
    BookGridController.prototype.InitializeGrid = function () {
        var _this = this;
        this.grid = new DataTable();
        this.grid.init({
            src: $(this.gridSelector),
            dataTable: {
                "deferLoading": 0,
                "drawCallback": function (settings) {
                    _this.DrawCallback(settings.aoData.map(function (obj) { return obj._aData; }));
                },
                "preDrawCallback": function () {
                    ko.cleanNode($(_this.gridBodySelector)[0]);
                },
                "responsive": true,
                "lengthMenu": [
                    [10, 20, 50, 100],
                    [10, 20, 50, 100]
                ],
                "pageLength": 20,
                "ajax": {
                    "url": this.business.GetBooksUrl()
                },
                "createdRow": function (row, data, index) {
                    $(row).html(_this.rowTemplate.format(index));
                },
            }
        });
    };
    return BookGridController;
}());
//# sourceMappingURL=book-grid-controller.js.map