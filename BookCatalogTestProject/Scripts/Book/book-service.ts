﻿class BookService {
    constructor(public urls: BookUrlModel) {
    }

    public GetBooks(): JQueryXHR {
        return $.get(this.urls.GetBooksUrl);
    }

    public CreateBook(data: BookModel): JQueryXHR {
        return $.post(this.urls.CreateBookUrl,
            {
                Title: data.Title(), PublicationDate: data.PublicationDate(), Rating: data.Rating(), PagesCount: data.PagesCount()
            }
        );
    }

    public UpdateBook(data: BookModel): JQueryXHR {
        return $.post(this.urls.UpdateBookUrl,
            {
                Id: data.Id(), Title: data.Title(), PublicationDate: data.PublicationDate(), Rating: data.Rating(), PagesCount: data.PagesCount()
            }
        );
    }

    public DeleteBook(id: number): JQueryXHR {
        return $.post(this.urls.DeleteBookUrl, { Id: id });
    }
}