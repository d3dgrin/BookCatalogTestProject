class AuthorService {
    constructor(public urls: AuthorUrlModel) {
    }

    public GetAuthors(): JQueryXHR {
        return $.get(this.urls.GetAuthorsUrl);
    }

    public CreateAuthor(data: AuthorModel): JQueryXHR {
        return $.post(this.urls.CreateAuthorUrl, { Name: data.Name(), Surname: data.Surname() });
    }

    public UpdateAuthor(data: AuthorModel): JQueryXHR {
        return $.post(this.urls.UpdateAuthorUrl, { Id: data.AuthorId(), Name: data.Name(), Surname: data.Surname() });
    }

    public DeleteAuthor(id: number): JQueryXHR {
        return $.post(this.urls.DeleteAuthorUrl, { Id: id });
    }
}