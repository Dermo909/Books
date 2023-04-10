export interface ReadingListItemVM {
    [key: string]: any;
    id: number;
    bookId: number;
    title:string;
    readingStatus: number;
    isActive: boolean;
}