class BookService {
    constructor(public urls: BookUrlModel) {
    }

    public CreateBook(data: BookItemModel): JQueryXHR {
        return $.post(this.urls.CreateBookUrl,
            {
                Title: data.Title(), PublicationDate: data.PublicationDate(), Rating: data.Rating(), PagesCount: data.PagesCount()
            }
        );
    }

    public UpdateBook(data: BookItemModel): JQueryXHR {
        return $.post(this.urls.UpdateBookUrl,
            {
                BookId: data.BookId(), Title: data.Title(), PublicationDate: data.PublicationDate(), Rating: data.Rating(), PagesCount: data.PagesCount()
            }
        );
    }

    public DeleteBook(id: number): JQueryXHR {
        return $.post(this.urls.DeleteBookUrl, { Id: id });
    }
}