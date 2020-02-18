class BookBusiness {
    public Model: BooksModel = new BooksModel();

    constructor(public service: BookService) {
        this.Model.OnEditSave = this.OnEditSave;
        this.Model.OnAdd = this.OnAdd;
        this.Model.OnAddSave = this.OnAddSave;
    }

    public GetBooks = () => {
        this.service.GetBooks().done((result: any) => {
            if (result.IsSuccess) {
                this.Model.Books = ko.observableArray(this.ConvertResponse(result.Model));
                ko.applyBindings(this.Model);
            }
        });
    }

    private ConvertResponse = (books: Book[]): BookModel[] => {
        return books.map((book: Book) => {
            var result = this.MapModel(book);
            return result;
        });
    }

    private MapModel = (data: any): BookModel => {
        var newModel = ko.mapping.fromJS(data);
        newModel.PublicationDate(moment(newModel.PublicationDate()).format("DD/MM/YYYY"));
        newModel.OnEdit = this.OnEdit;
        newModel.OnDelete = this.OnDelete;

        return newModel;
    }

    private OnEdit = (model: BookModel, event: Event): void => {
        
    }

    private OnEditSave = (model: BooksModel, event: Event): void => {
        
    }

    private OnAdd = (model: BooksModel, event: Event): void => {
        $('#createBookModal').modal('show');
        $("#createBookDate").datepicker();
    }

    private OnAddSave = (model: BooksModel, event: Event): void => {
        debugger;
        this.service.CreateBook(model.Book).done((result: any) => {
            if (result.IsSuccess) {
                var newModel = this.MapModel(result.Model);
                this.Model.Books.push(newModel);
            }
        });
        $('#createBookModal').modal('hide');
    }

    private OnDelete = (model: BookModel, event: Event): void => {
        
    }









    //public Model: BooksModel = new BooksModel();

    //OnBooksReceive: (model: BooksModel) => void;

    //constructor(private service: BookService) { }

    //public ConvertResponse = (books: Book[]): BookModel[] => {
    //    return books.map((book: Book) => {
    //        var result = new BookModel(book);
    //        return result;
    //    });
    //}

    //public GetBooksUrl(): string {
    //    return this.service.urls.GetBooksUrl;
    //}

    //public GetBooks = () => {
    //    this.service.GetBooks().done((result: any) => {
    //        if (result.IsSuccess) {
    //            this.Model.Books = ko.observableArray(this.ConvertResponse(result.Model));
    //            this.OnBooksReceive(this.Model);
    //        }
    //    });
    //}

    

    //private InitBooks = () => {
    //    this.service.GetBooks().done((result: any) => {
    //        if (result.IsSuccess) {
    //            this.Model.Books = ko.observableArray(this.ConvertResponse(result.Model));
    //        }
    //    });
    //}
}