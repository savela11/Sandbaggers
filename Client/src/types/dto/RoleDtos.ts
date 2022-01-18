export interface RemoveUserFromRoleDto {
  roleName: string;
  userId: string;
}

export interface AddUserToRoleDto {
  roleName: string;
  userId: string;
}

export interface CreateRoleDto {
  roleName: string;
}
