export interface BookVM {
    [key: string]: any;
    id: number;
    title: string;
    isbn: string;
    authorId: number;
    authorName: string;
    readingStatus: number;
    isActive: boolean;
}