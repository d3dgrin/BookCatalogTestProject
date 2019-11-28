declare var Datatable: any;

class BookController {
    private grid: any;
    private gridSelector: string = "#bookDataTable";

    public InitializeGrid(): void {
        this.grid = new Datatable();
    }
}