class BookService {
    constructor(public urls: BookUrlModel) {
    }

    public CreateBook(data: BookItemModel): JQueryXHR {
        return $.post(this.urls.CreateBookUrl,
            {
                Title: data.Title(), PublicationDate: data.PublicationDate(), Rating: data.Rating(), PagesCount: data.PagesCount(), AuthorIds: data.SelectedAuthors()
            }
        );
    }

    public UpdateBook(data: BookItemModel): JQueryXHR {
        return $.post(this.urls.UpdateBookUrl,
            {
                BookId: data.BookId(), Title: data.Title(), PublicationDate: data.PublicationDate(), Rating: data.Rating(), PagesCount: data.PagesCount(), AuthorIds: data.SelectedAuthors()
            }
        );
    }

    public DeleteBook(id: number): JQueryXHR {
        return $.post(this.urls.DeleteBookUrl, { Id: id });
    }

    public GetAuthors(): JQueryXHR {
        return $.get(this.urls.GetAuthorsUrl);
    }
}