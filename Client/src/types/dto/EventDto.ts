export interface CreateEventDto {
  name: string;
  year: string;
}

export interface RegisterUserForEventDto {
  eventId: number,
  userId: string
}

export interface AddRemoveTeamFromEvent {
 eventId: number,
 teamName: string
}
