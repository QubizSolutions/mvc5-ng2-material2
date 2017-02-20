export interface Author {
    Id: number,
    FirstName: string,
    LastName: string,
    BirthDate: Date,
    Country: string,
    Articles: Article[]
}

export interface Article {
    Id: number,
    Title: string,
    ShortDescription: string,
    Year: number,
    Link: string,
    AuthorIds: number[]
}