export interface Author {
    Id: string,
    FirstName: string,
    LastName: string,
    BirthDate: any,
    Country: string,
    Articles?: Article[]
}

export interface Article {
    Id: string,
    Title: string,
    ShortDescription: string,
    Year: number,
    Link: string,
    Authors: { [id: number]: string; }[]
}