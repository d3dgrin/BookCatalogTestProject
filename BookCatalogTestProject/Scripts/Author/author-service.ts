class AuthorService {
    constructor(public urls: AuthorUrlModel) {
    }

    public CreateAuthor(data: AuthorItemModel): JQueryXHR {
        return $.post(this.urls.CreateAuthorUrl, { Name: data.Name(), Surname: data.Surname() });
    }

    public UpdateAuthor(data: AuthorItemModel): JQueryXHR {
        return $.post(this.urls.UpdateAuthorUrl, { AuthorId: data.AuthorId(), Name: data.Name(), Surname: data.Surname() });
    }

    public DeleteAuthor(id: number): JQueryXHR {
        return $.post(this.urls.DeleteAuthorUrl, { Id: id });
    }
}