export interface IIdea {
    id: number
    title: string
    description: string
    createdBy: ICreatedBy
    updatedOn: string
    createdOn: string
}


export interface ICreatedBy {
    id: string
    fullName: string
}


export interface AddIdeaDto {

    title: string
    description: string
    userId: string
}
export interface GetIdeaDto {
    userId: string;
    ideaId: number
}
